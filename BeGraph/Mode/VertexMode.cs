using System.Windows.Forms;
using BeGraph.GShape;

namespace BeGraph.Mode {
	public class VertexMode : AbstractMouseState {
		private Graph graph;

		public VertexMode(Graph graph) {
			this.graph = graph;
		}

		public override void MouseClick(object sender, MouseEventArgs me) {
			if (!Active && me.Clicks != 2) return;

			var inputDialog = new InputDialog("Enter name of a vertex", "Vertex generation");
			var dialogResult = inputDialog.ShowDialog(null);

			if (dialogResult == DialogResult.OK) {
				graph += new Vertex(inputDialog.InputText, me.Location);
			}
		}

		public override void MouseDown(object sender, MouseEventArgs me) {
			if (!Active) return;

			base.MouseDown(sender, me);

			// TODO: start moving
		}

		public override void MouseDrag(object sender, MouseEventArgs me) {
			if (!Active && !Dragging) return;

			// TODO: display moving
		}

		public override void MouseUp(object sender, MouseEventArgs me) {
			if (!Active) return;

			base.MouseUp(sender, me);

			// TODO: finalize moving 
		}
	}
}