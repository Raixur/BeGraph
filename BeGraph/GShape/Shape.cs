using BeGraph.Visitor;

namespace BeGraph.GShape {
	public abstract class Shape {
		private static int _nextId;

		protected Shape() {
			Id = _nextId++;
		}

		public int Id { get; }

		public abstract void Accept(IGVisitor visitor);
	}
}