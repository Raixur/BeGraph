using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BeGraph {
	/// <summary>
	/// Represents a user control for displaying directed graph.
	/// </summary>
	class GraphBox : PictureBox {

		private Graph g;
		private Vertex last;
		private Point currentPos;

		private bool isMouseButtonLeftDown = false;

		public Graph G {
			get {
				return g;
			}

			set {
				g = value;
			}
		}

		public GraphBox() {
			g = new Graph();

			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Location = new System.Drawing.Point(12, 28);
			this.Name = "graphBox";
			this.Size = new System.Drawing.Size(563, 421);
			this.TabIndex = 3;
			this.TabStop = false;

			// Binding event handlers to events.
			MouseDown += new MouseEventHandler(pb_MouseDown);
			MouseUp += new MouseEventHandler(pb_MouseUp);
			MouseDoubleClick += new MouseEventHandler(pb_DoubleClick);
			MouseMove += new MouseEventHandler(pb_MouseMove);
			g.GraphChanged += new EventHandler(g_GraphChanged);
		}

		/// <summary>
		/// Checking if there is enought place at the mouse 
		/// cursor to create a vertex in GraphBox
		/// </summary>
		/// <param name="cursor"></param>
		/// <returns></returns>
		private bool HaveSpace(Point cursor) {
			int r = Vertex.r;
			Point rbBorder = new Point(base.Width - r, base.Height - r);
			if (!((cursor.X > r && cursor.X < rbBorder.X) && (cursor.Y > r && cursor.Y < rbBorder.Y)))
				return false;
			return true;
		}

		/// <summary>
		/// Generating vertex at cursor point. Display input 
		/// form which requires you to enter name of the vertex. 
		/// </summary>
		/// <param name="p">p is current position of the mouse cusror</param>
		/// <returns>Returns generated vertex</returns>
		private Vertex GenerateVert(Point p) {
			if (HaveSpace(p)) {

				//Display dialog which requires to enter name of vertex
				InputDialog.InputDialog inputDialog = new InputDialog.InputDialog("Enter name of a vertex", "Vertex generation");
				DialogResult dialogResult = inputDialog.ShowDialog(this);

				if (dialogResult == DialogResult.OK) {
					Vertex v = new Vertex(inputDialog.InputText, p);
					return v;
				}
			}
			// If there is not enough place to put a vertex displays error dialog
			else {
				MessageBox.Show("Invalid place to put a vertex!", "Error", MessageBoxButtons.OK);
			}
			return null;
		}

		/// <summary>
		/// Overriding the paint event for GraphBox
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);

			// Setting graphics quality to high
			pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

			//Draws grapgh
			g.Draw(pe.Graphics);

			//Draws a line from vertex to current position of mouse cursor
			if(isMouseButtonLeftDown && last != null && last.Position != currentPos) {
				using (Pen blackPen = new Pen(Color.Black, 2)) {
					AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
					blackPen.CustomEndCap = bigArrow;
			
					double c = Math.Sqrt(Math.Pow(currentPos.X - last.Position.X, 2) + Math.Pow(currentPos.Y - last.Position.Y, 2));
					double sin = (currentPos.Y - last.Position.Y) / c;
					double cos = (currentPos.X - last.Position.X) / c;
					Point startPoint = new Point(last.Position.X + (int)(cos * Vertex.r), last.Position.Y + (int)(sin * Vertex.r));

					pe.Graphics.DrawLine(blackPen, startPoint, currentPos);
				}
			}
		}

		#region Events


		private void g_GraphChanged(object sender, EventArgs e) {
			Invalidate();
		}

		private void pb_MouseDown(object sender, MouseEventArgs me) {
			switch (me.Button) {
				case MouseButtons.Left:
					if (me.Clicks == 1) {
						isMouseButtonLeftDown = true;
						last = g.VertAt(me.Location);
						currentPos = me.Location;
					}
					break;
				case MouseButtons.Right:
					// TODO: implement moving vertexes
					break;
			}
		}

		private void pb_MouseMove(object sender, MouseEventArgs me) {
			if (isMouseButtonLeftDown && last != null) {
				currentPos = me.Location;
				Invalidate();
			}
		}

		private void pb_MouseUp(object sender, MouseEventArgs me) {
			switch (me.Button) {
				case MouseButtons.Left:
					if (me.Clicks == 1) {
						isMouseButtonLeftDown = false;
						Vertex tempSecond = g.VertAt(me.Location);
						if (last != null && tempSecond != null) {
							Edge e = new Edge(last, tempSecond);
							g += e;
						}
						else {
							Invalidate();
						}
					}
					break;
			}
		}

		/// <summary>
		/// Creates a new vertex at the point of double click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pb_DoubleClick(object sender, EventArgs e) {
			MouseEventArgs me = (MouseEventArgs)e;
			if (g.VertAt(me.Location) == null) { 
				Vertex v = GenerateVert(me.Location);
				if (v != null)
					g += v;
			}
		}
		#endregion
	}
}
