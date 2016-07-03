using BeGraph.GShape;

namespace BeGraph.Visitor {
	public interface IGVisitor {
		void Visit(Graph graph);
		void Visit(Edge edge);
		void Visit(Vertex vertex);
	}
}