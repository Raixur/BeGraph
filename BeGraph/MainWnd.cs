using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BeGraph {
	public partial class MainWnd : Form {
		public MainWnd() {
			InitializeComponent();
		}

		private void MainWnd_Load(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Maximized;
			this.FormBorderStyle = FormBorderStyle.Sizable;
		}

		private void SaveToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement async
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = "Graph files (*.g)|*.g";
			saveDialog.RestoreDirectory = true;

			if (saveDialog.ShowDialog() == DialogResult.OK) {
				using (StreamWriter sw = new StreamWriter(saveDialog.OpenFile(), System.Text.Encoding.Unicode)) {
					if (sw != null)
						sw.WriteLine(graphBox.G);
				}
			}
		}

		private void NewToolbarItem_Click(object sender, EventArgs e) {
			if (graphBox != null)
				graphBox.Dispose();
			graphBox = new GraphBox();
			graphBox.Size = new Size(this.Size.Width - 40, this.Size.Height - 80);
			this.Controls.Add(graphBox);
		}

		private void OpenToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement
		}

		private void ExitToolbarItem_Click(object sender, EventArgs e) {
			//TODO: implement
		}
	}
}
