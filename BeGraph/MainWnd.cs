using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using BeGraph.GShape;

namespace BeGraph {
	public partial class MainWnd : Form {
		private string graphBuffer = "";

		private OleDbConnection connection;

		public MainWnd() {
			InitializeComponent();

			connection = new OleDbConnection {
				ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
							   + @"Data Source=C:\Users\Anatoliy\Source\Repos\BeGraph\BeGraph\TestDB.accdb"
			};

			try {
				connection.Open();
			}
			catch (Exception) {
				MessageBox.Show(this, @"Error has occured during connection", @"Error");
			}
		}

		private void MainWnd_Load(object sender, EventArgs e) {
			WindowState = FormWindowState.Maximized;
			FormBorderStyle = FormBorderStyle.Sizable;
		}

		#region Toolbar events

		private void SaveToolbarItem_Click(object sender, EventArgs e) {
			var saveDialog = new SaveFileDialog {
				Filter = @"Graph files (*.g)|*.g",
				RestoreDirectory = true
			};
			
			if (saveDialog.ShowDialog() == DialogResult.OK) {
				using (var sw = new StreamWriter(saveDialog.OpenFile(), Encoding.Unicode)) {
					sw.WriteLine(graphBox.G);
				}
				graphBuffer = graphBox.G.ToString();
			}
		}

		private void NewToolbarItem_Click(object sender, EventArgs e) {
			graphBox?.Dispose();

			graphBox = new GraphBox {Size = new Size(Size.Width - 40, Size.Height - 80)};

			Controls.Add(graphBox);
		}

		private void OpenToolbarItem_Click(object sender, EventArgs e) {
			// GraphBox initialization
			graphBox?.Dispose();
			graphBox = new GraphBox {Size = new Size(Size.Width - 40, Size.Height - 80)};
			Controls.Add(graphBox);

			// Opening file
			var openDialog = new OpenFileDialog {
				Filter = @"Graph files (*.g)|*.g",
				RestoreDirectory = true
			};

			try {
				if (openDialog.ShowDialog() != DialogResult.OK) return;

				using (var sr = new StreamReader(openDialog.OpenFile(), Encoding.Unicode)) {
					{
						// Parsing Vertexes
						var vertCount = int.Parse(sr.ReadLine());
						for (var i = 0; i < vertCount; i++) {
							graphBox.G += ToVetex(sr.ReadLine());
						}

						// Parsing Edges
						var edgeCount = int.Parse(sr.ReadLine());
						for (var i = 0; i < edgeCount; i++) {
							graphBox.G += ToEdge(sr.ReadLine());
						}
					}
				}
				graphBuffer = graphBox.G.ToString();
			}
			catch (FormatException) {
				MessageBox.Show(@"File corrupted!" + Environment.NewLine + @"Empty file will be opened.", @"Error",
					MessageBoxButtons.OK);
			}
		}

		private void ExitToolbarItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void MainWnd_Closing(object sender, CancelEventArgs e) {
			if (graphBox == null || graphBuffer == graphBox.G.ToString()) return;

			if (MessageBox.Show(@"Save latest changes?", @"BeGraph", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				e.Cancel = true;
				SaveToolbarItem_Click(this, new EventArgs());
			}

			connection?.Close();
		}

		/// <summary>
		///     Creates Vertex object from string
		/// </summary>
		/// <param name="parseVertex">String type: name(x,y)</param>
		/// <returns></returns>
		private static Vertex ToVetex(string parseVertex) {
			//Spliting string to string array [name,x,y]
			const string delimeter = ">,";
			var splitedString = parseVertex.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			// Invalid format of vertex 
			if (splitedString.Length != 3)
				throw new FormatException();

			// Adding vertex to graph
			return new Vertex(splitedString[0], new Point(int.Parse(splitedString[1]), int.Parse(splitedString[2])));
		}

		/// <summary>
		///     Creates Edge object from string
		/// </summary>
		/// <param name="parseEdge">String type: [name(x,y)]>[name(x,y)](weight)</param>
		/// <returns></returns>
		private static Edge ToEdge(string parseEdge) {
			const string delimeter = "[]=-";
			var splitedString = parseEdge.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			if (splitedString.Length != 3)
				throw new FormatException();

			return new Edge(ToVetex(splitedString[0]), ToVetex(splitedString[1]), int.Parse(splitedString[2]));
		}

		#endregion Tool
	}
}