using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace BeGraph
{
	class Graph : Figure {
        List<Vertex> vertexes = new List<Vertex>();
        List<Edge> edges = new List<Edge>();

		public Graph() {
		}

		//Not used
		public Graph(Graph other) {
			foreach (Vertex v in other.vertexes) {
				this.vertexes.Add(v);
			}
			foreach(Edge e in other.edges) {
				this.edges.Add(e);
			}
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

		public override string ToString() {
			string s = "";
			s += vertexes.Count + Environment.NewLine;
			foreach (Vertex v in vertexes) {
				s += v + Environment.NewLine;
			}
			s += edges.Count + Environment.NewLine;
			foreach (Edge e in edges) {
				s += e + Environment.NewLine;
			}
			return s;
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
