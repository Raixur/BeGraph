using BeGraph.Visitor;

namespace BeGraph.GShape {
	public class Edge : Shape {
		public Edge(Vertex f, Vertex s, double w = 0.0) {
			First = f;
			Second = s;
			Weight = w;
		}

		public Vertex First { get; internal set; }

		public Vertex Second { get; internal set; }

		public double Weight { get; }


		public override string ToString() {
			return "[" + First + "]-[" + Second + "]=[" + Weight + "]";
		}

		public override void Accept(IGVisitor visitor) {
			visitor.Visit(this);
		}
	}
}