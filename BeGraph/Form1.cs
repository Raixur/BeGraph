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
			graphBox.Location = new Point(20, 20);
		}

		public static DialogResult InputBox(string title, string promptText, out string value) {
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = "";

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
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
			gr.Clear(Color.WhiteSmoke);
			g.draw(graphBox);
			gr.Dispose();
		}

		private Vertex generateVert(Point p) {
			if (haveSpace(p)) {
				string name;
				if (InputBox("Input", "Enter vertex name", out name) == DialogResult.OK) {
					Vertex v = new Vertex(name, p);
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



	}
}
