using System.Collections.Generic;

namespace BeGraph
{
    class Graph : Figure {
        List<Vertex> vertexes;
        List<Edge> edges;

		public Graph() {
			vertexes = new List<Vertex>();
			edges = new List<Edge>();
		}

		public Vertex vertAt(System.Drawing.Point p) {
			foreach (Vertex v in vertexes) {
				if (v.isInRange(p))
					return v;
			}
			return null;
		}

		public override void draw(System.Drawing.Graphics gr) {
			foreach (Vertex v in vertexes)
				v.draw(gr);
			foreach (Edge e in edges)
				e.draw(gr);
		}

		public static Graph operator +(Graph g, Vertex v) {
			if (!g.vertexes.Contains(v)) {
				g.vertexes.Add(v);
				g.OnGraphChanged(new System.EventArgs());
			}
            return g;
        }

        public static Graph operator +(Graph g, Edge e) {
			if (!g.vertexes.Contains(e.getFirst()))
				g.vertexes.Add(e.getFirst());
			if (!g.vertexes.Contains(e.getSecond()))
				g.vertexes.Add(e.getSecond());
			if (!g.edges.Contains(e)) {
				g.edges.Add(e);
				g.OnGraphChanged(new System.EventArgs());
			}
            return g;
        }

		protected virtual void OnGraphChanged(System.EventArgs e) {
			System.EventHandler handler = GraphChanged;
			if (handler != null)
				handler(this, e);
		}

		public event System.EventHandler GraphChanged;

	}
}
