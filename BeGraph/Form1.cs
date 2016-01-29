using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeGraph {
	public partial class Form1 : Form {

		private Graph g;
		private Vertex tempFirst;

		public Form1() {
			g = new Graph();
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Maximized;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			graphBox.Size = new System.Drawing.Size(this.Size.Width - 60, this.Size.Height - 80);
		}

		private void Form1_Resize(object sender, EventArgs e) {
			redraw();
		}

		private bool haveSpace(Point cursor) {
			int r = Vertex.r;
			Point rbBorder = new Point(graphBox.Width - r, graphBox.Height - r);
			if (!((cursor.X > r && cursor.X < rbBorder.X) && (cursor.Y > r && cursor.Y < rbBorder.Y)))
				return false;
			return true;
		}

		private void redraw() {
			Graphics gr = graphBox.CreateGraphics();
			gr.Clear(Color.White);
			g.draw(graphBox);
			gr.Dispose();
		}

		private Vertex generateVert(Point p) {
			if (haveSpace(p)) {
				InputDialog.InputDialog id = new InputDialog.InputDialog("Enter name of a vertex", "Vertex generation");
				DialogResult dResult = id.ShowDialog(this);
				if (dResult == DialogResult.OK) {
					Vertex v = new Vertex(id.getInput(), p);
					v.draw(graphBox);
					g += v;
					redraw();
					return v;
				}
			}
			else
				MessageBox.Show("Invalid place to put a vertex!", "Error", MessageBoxButtons.OK);
			return null;
		}

		private void graphBox_Click(object sender, EventArgs e) {

			//MouseEventArgs me = (MouseEventArgs)e;
			//switch (me.Button) {
			//	case MouseButtons.Left:
			//		break;
			//	case MouseButtons.Right:
			//		MessageBox.Show("Rigth", "Error", MessageBoxButtons.OK);
			//		break;
			//}

		}

		private void graphBox_MouseDown(object sender, MouseEventArgs me) {
			switch (me.Button) {
				case MouseButtons.Left:
					tempFirst = g.vertAt(me.Location);
					break;
			}
		}

		private void graphBox_MouseUp(object sender, MouseEventArgs me) {
			switch (me.Button) {
				case MouseButtons.Left:
					Vertex tempSecond = g.vertAt(me.Location);
					if (tempFirst != null && tempSecond != null) {
						Edge e = new Edge(tempFirst, tempSecond);
						g += e;
						redraw();
					}
					break;
			}
		}

		private void graphBox_DoubleClick(object sender, EventArgs e) {
			MouseEventArgs me = (MouseEventArgs)e;

			//Проверка на валидность положения новой вершины
			if (g.vertAt(me.Location) == null) {
				generateVert(me.Location);
				redraw();
			}

		}

		private void toolStripDropDownButton1_Click(object sender, EventArgs e) {

		}

		
	}
}
