using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BeGraph.Visitor;

namespace BeGraph.GShape {
	public class Graph : Shape, IEnumerable<Shape> {
		private readonly List<Edge> edges;
		private readonly List<Vertex> vertexes;

		public Graph() {
			vertexes = new List<Vertex>();
			edges = new List<Edge>();
		}


		public IEnumerator<Shape> GetEnumerator() {
			foreach (var vertex in vertexes) {
				yield return vertex;
			}
			foreach (var edge in edges) {
				yield return edge;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public Vertex VertAt(Point p) {
			return vertexes.FirstOrDefault(v => v.IsInRange(p));
		}

		public override void Accept(IGVisitor visitor) {
			visitor.Visit(this);
		}

		public override string ToString() {
			var s = vertexes.Count + Environment.NewLine;

			s = vertexes.Aggregate(s, (current, v) => current + (v + Environment.NewLine));

			s += edges.Count + Environment.NewLine;

			return edges.Aggregate(s, (current, e) => current + (e + Environment.NewLine));
		}


		public static Graph operator +(Graph g, Vertex v) {
			if (g.vertexes.Contains(v)) return g;

			g.vertexes.Add(v);
			g.OnGraphChanged(new EventArgs());

			return g;
		}

		public static Graph operator +(Graph g, Edge e) {
			var index = g.vertexes.IndexOf(e.First);

			if (index == -1) {
				g.vertexes.Add(e.First);
			}
			else {
				e.First = g.vertexes[index];
			}

			index = g.vertexes.IndexOf(e.Second);

			if (index == -1) {
				g.vertexes.Add(e.Second);
			}
			else {
				e.Second = g.vertexes[index];
			}

			if (g.edges.Contains(e)) return g;

			g.edges.Add(e);
			g.OnGraphChanged(new EventArgs());

			return g;
		}

		protected virtual void OnGraphChanged(EventArgs e) {
			var handler = GraphChanged;
			handler?.Invoke(this, e);
		}

		public event EventHandler GraphChanged;
	}
}