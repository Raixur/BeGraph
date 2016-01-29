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

		public override void draw(System.Windows.Forms.PictureBox p) {
			foreach (Vertex v in vertexes)
				v.draw(p);
			foreach (Edge e in edges)
				e.draw(p);
		}

		public static Graph operator +(Graph g, Vertex v) {
			if(!g.vertexes.Contains(v))
				g.vertexes.Add(v);
            return g;
        }

        public static Graph operator +(Graph g, Edge e) {
			if (!g.vertexes.Contains(e.getFirst()))
				g.vertexes.Add(e.getFirst());
			if (!g.vertexes.Contains(e.getSecond()))
				g.vertexes.Add(e.getSecond());
			g.edges.Add(e);
            return g;
        }
    }
}
