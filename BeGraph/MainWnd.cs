using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BeGraph {
	public partial class MainWnd : Form {

		string graphBuffer = "";
		public MainWnd() {
			InitializeComponent();
		}

		private void MainWnd_Load(object sender, EventArgs e) {
			WindowState = FormWindowState.Maximized;
			FormBorderStyle = FormBorderStyle.Sizable;
		}

		#region Toolbar events
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
				graphBuffer = graphBox.G.ToString();
			}
		}

		private void NewToolbarItem_Click(object sender, EventArgs e) {
			if (graphBox != null)
				graphBox.Dispose();

			graphBox = new GraphBox();
			graphBox.Size = new Size(this.Size.Width - 40, this.Size.Height - 80);

			Controls.Add(graphBox);
		}

		private void OpenToolbarItem_Click(object sender, EventArgs e) {

			// GraphBox initialization
			if (graphBox != null)
				graphBox.Dispose();
			graphBox = new GraphBox();
			graphBox.Size = new Size(this.Size.Width - 40, this.Size.Height - 80);
			this.Controls.Add(graphBox);

			// Opening file
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "Graph files (*.g)|*.g";
			openDialog.RestoreDirectory = true;

			try {
				if (openDialog.ShowDialog() == DialogResult.OK) {
					using (StreamReader sr = new StreamReader(openDialog.OpenFile(), System.Text.Encoding.Unicode)) {
						if (sr != null) {

							// Parsing Vertexes
							int vertCount = int.Parse(sr.ReadLine());
							for (int i = 0; i < vertCount; i++) {
								graphBox.G += ToVetex(sr.ReadLine());
							}

							// Parsing Edges
							int edgeCount = int.Parse(sr.ReadLine());
							for (int i = 0; i < edgeCount; i++) {
								graphBox.G += ToEdge(sr.ReadLine()); 					
							}

						}
					}
					graphBuffer = graphBox.G.ToString();
				}
			}
			catch (FormatException) {
				MessageBox.Show("File corrupted!" + Environment.NewLine + "Empty file will be opened.", "Error", MessageBoxButtons.OK);
			}
		}

		private void ExitToolbarItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void MainWnd_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (graphBox != null && graphBuffer != graphBox.G.ToString()) {
				if (MessageBox.Show("Save latest changes?", "BeGraph", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					e.Cancel = true;
					SaveToolbarItem_Click(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Creates Vertex object from string
		/// </summary>
		/// <param name="parseVertex">String type: name(x,y)</param>
		/// <returns></returns>
		private Vertex ToVetex(string parseVertex) {
			//Spliting string to string array [name,x,y]
			string delimeter = ">,";
			string[] splitedString = parseVertex.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			// Invalid format of vertex 
			if (splitedString.Length != 3)
				throw new FormatException();

			// Adding vertex to graph
			return new Vertex(splitedString[0], new Point(int.Parse(splitedString[1]), int.Parse(splitedString[2])));
		}

		/// <summary>
		/// Creates Edge object from string
		/// </summary>
		/// <param name="parseEdge">String type: [name(x,y)]>[name(x,y)](weight)</param>
		/// <returns></returns>
		private Edge ToEdge(string parseEdge) {
			string delimeter = "[]=-"; 
			string[] splitedString = parseEdge.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			if (splitedString.Length != 3)
				throw new FormatException();
			 
			return new Edge(ToVetex(splitedString[0]), ToVetex(splitedString[1]), int.Parse(splitedString[2]) );
		}

		#endregion Tool
	}
}