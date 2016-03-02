using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeGraph {
	public partial class MainWnd : Form {
		public MainWnd() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Maximized;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			graphBox.Size = new System.Drawing.Size(this.Size.Width - 60, this.Size.Height - 80);
		}

		private void toolStripDropDownButton1_Click(object sender, EventArgs e) {
			//TODO implement
		}

		private void saveToolbarItem_Click(object sender, EventArgs e) {
			Stream s;
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			sfd.FilterIndex = 2;
			sfd.RestoreDirectory = true;
		}
	}
}
