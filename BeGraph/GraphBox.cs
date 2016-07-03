using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BeGraph.GShape;
using BeGraph.Visitor;

namespace BeGraph {
	/// <summary>
	///     Represents a user control for displaying directed graph.
	/// </summary>
	internal class GraphBox : PictureBox {
		private Point currentPos;

		private bool isMouseButtonLeftDown;
		private bool isMouseButtonRightDown;
		private Vertex last;

		public GraphBox() {
			G = new Graph();

			BackColor = Color.White;
			BackgroundImageLayout = ImageLayout.None;
			BorderStyle = BorderStyle.FixedSingle;
			Location = new Point(12, 28);
			Name = "graphBox";
			Size = new Size(563, 421);
			TabIndex = 3;
			TabStop = false;

			MouseDown += pb_MouseDown;
			MouseUp += pb_MouseUp;
			MouseDoubleClick += pb_DoubleClick;
			MouseMove += pb_MouseMove;
			G.GraphChanged += g_GraphChanged;
		}

		public Graph G { get; set; }

		public Shape TempShape { get; set; }

		/// <summary>
		///     Checking if there is enought place at the mouse
		///     cursor to create a vertex in GraphBox
		/// </summary>
		/// <param name="cursor"></param>
		/// <returns></returns>
		private bool HaveSpace(Point cursor) {
			var r = Vertex.Radius;
			var rbBorder = new Point(Width - r, Height - r);
			return cursor.X > r && cursor.X < rbBorder.X && cursor.Y > r && cursor.Y < rbBorder.Y;
		}

		/// <summary>
		///     Generating vertex at cursor point. Display input
		///     form which requires you to enter name of the vertex.
		/// </summary>
		/// <param name="p">p is current position of the mouse cusror</param>
		/// <returns>Returns generated vertex</returns>
		private Vertex GenerateVert(Point p) {
			if (HaveSpace(p)) {
				//Display dialog which requires to enter name of vertex
				var inputDialog = new InputDialog("Enter name of a vertex", "Vertex generation");
				var dialogResult = inputDialog.ShowDialog(this);

				if (dialogResult == DialogResult.OK) {
					var v = new Vertex(inputDialog.InputText, p);
					return v;
				}
			}
			// If there is not enough place to put a vertex displays error dialog
			else {
				MessageBox.Show(@"Invalid place to put a vertex!", @"Error", MessageBoxButtons.OK);
			}
			return null;
		}

		/// <summary>
		///     Overriding the paint event for GraphBox
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);

			// Setting graphics quality to high
			pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			pe.Graphics.InterpolationMode = InterpolationMode.High;
			pe.Graphics.CompositingQuality = CompositingQuality.HighQuality;

			var drawer = new GDrawer(pe.Graphics);
			G.Accept(drawer);
			TempShape?.Accept(drawer);

			//Draws a line from vertex to current position of mouse cursor
			if (isMouseButtonLeftDown && last != null && last.Position != currentPos) {
				using (var blackPen = new Pen(Color.Black, 2)) {
					var bigArrow = new AdjustableArrowCap(5, 5);
					blackPen.CustomEndCap = bigArrow;

					var c = Math.Sqrt(Math.Pow(currentPos.X - last.Position.X, 2)
					                  + Math.Pow(currentPos.Y - last.Position.Y, 2));
					var sin = (currentPos.Y - last.Position.Y)/c;
					var cos = (currentPos.X - last.Position.X)/c;
					var startPoint = new Point(last.Position.X + (int) (cos*Vertex.Radius),
						last.Position.Y + (int) (sin*Vertex.Radius));

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
						last = G.VertAt(me.Location);
						currentPos = me.Location;
					}
					break;
				case MouseButtons.Right:
					if (me.Clicks == 1) {
						isMouseButtonRightDown = true;
						last = G.VertAt(me.Location);
					}
					break;
			}
		}

		private void pb_MouseMove(object sender, MouseEventArgs me) {
			if (isMouseButtonLeftDown && last != null) {
				currentPos = me.Location;
				Invalidate();
			}
			if (isMouseButtonRightDown && last != null) {
				if (HaveSpace(me.Location)) {
					last.MoveTo(me.Location);
					Invalidate();
				}
			}
		}

		private void pb_MouseUp(object sender, MouseEventArgs me) {
			switch (me.Button) {
				case MouseButtons.Left:
					if (me.Clicks == 1) {
						isMouseButtonLeftDown = false;
						var tempSecond = G.VertAt(me.Location);
						if (last != null && tempSecond != null) {
							var e = new Edge(last, tempSecond);
							G += e;
						}
						else {
							Invalidate();
						}
					}
					break;

				case MouseButtons.Right:
					if (me.Clicks == 1) {
						isMouseButtonRightDown = false;
					}
					break;
			}
		}

		/// <summary>
		///     Creates a new vertex at the point of double click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pb_DoubleClick(object sender, EventArgs e) {
			var me = (MouseEventArgs) e;
			if (G.VertAt(me.Location) == null) {
				var v = GenerateVert(me.Location);
				if (v != null)
					G += v;
			}
		}

		#endregion
	}
}