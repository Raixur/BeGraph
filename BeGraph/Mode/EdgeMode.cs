using System.Windows.Forms;
using BeGraph.GShape;

namespace BeGraph.Mode {
	public class EdgeMode : AbstractMouseState {
		private Graph graph;

		public EdgeMode(Graph graph) {
			this.graph = graph;
		}

		/// <summary>
		///     Creates loop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="me"></param>
		public override void MouseClick(object sender, MouseEventArgs me) {
			if (!Active) return;

			var v = graph.VertAt(me.Location);
			if (v != null) {
				graph += new Edge(v, v, InputWeight());
			}
		}

		public override void MouseDown(object sender, MouseEventArgs me) {
			if (!Active) return;
			base.MouseDown(sender, me);

			var graphBox = sender as GraphBox;
			if (graphBox != null) graphBox.TempShape = new Edge(graph.VertAt(me.Location), new Vertex("", me.Location));
		}

		public override void MouseDrag(object sender, MouseEventArgs me) {
			if (!Active && !Dragging) return;

			var graphBox = sender as GraphBox;
			var tempEdge = graphBox?.TempShape as Edge;

			tempEdge?.Second.MoveTo(me.Location);
		}

		public override void MouseUp(object sender, MouseEventArgs me) {
			if (!Active && !Dragging) return;

			base.MouseUp(sender, me);

			var graphBox = sender as GraphBox;
			var tempEdge = graphBox?.TempShape as Edge;

			if (tempEdge == null) return;

			var end = graph.VertAt(me.Location);
			graph += new Edge(tempEdge.First,
				end ?? new Vertex("", me.Location),
				InputWeight());
		}

		private static double InputWeight() {
			var weightDlg = new InputDialog("Enter weight of the vertex", "Weight");
			double weight;
			double.TryParse(weightDlg.InputText, out weight);

			return weight;
		}
	}
}