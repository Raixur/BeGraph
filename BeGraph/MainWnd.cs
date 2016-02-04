using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BeGraph {
	public partial class MainWnd : Form {
		public MainWnd() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Maximized;
			this.FormBorderStyle = FormBorderStyle.Sizable;
		}

		private void saveToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement async
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = "Graph files (*.g)|*.g";
			saveDialog.RestoreDirectory = true;

			if (saveDialog.ShowDialog() == DialogResult.OK) {
				using (StreamWriter sw = new StreamWriter(saveDialog.OpenFile(), System.Text.Encoding.Unicode)) {
					if (sw != null)
						sw.WriteLine(graphBox.g);
				}
			}
		}

		private void newToolbarItem_Click(object sender, EventArgs e) {
			if (graphBox != null)
				graphBox.Dispose();
			graphBox = new GraphBox();
			graphBox.Size = new Size(this.Size.Width - 40, this.Size.Height - 80);
			this.Controls.Add(graphBox);
		}

		private void openToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement
		}

		private void exitToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement
		}
	}
}
