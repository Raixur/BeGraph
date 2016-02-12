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

		public Vertex VertAt(System.Drawing.Point p) {
			foreach (Vertex v in vertexes) {
				if (v.IsInRange(p))
					return v;
			}
			return null;
		}

		public override void Draw(System.Drawing.Graphics gr) {
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			gr.Clear(System.Drawing.Color.White);
			foreach (Vertex v in vertexes)
				v.Draw(gr);
			foreach (Edge e in edges)
				e.Draw(gr);
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
			if (!g.vertexes.Contains(e.GetFirst()))
				g.vertexes.Add(e.GetFirst());
			if (!g.vertexes.Contains(e.GetSecond()))
				g.vertexes.Add(e.GetSecond());
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
