using System;
using System.Drawing;
using BeGraph.Visitor;

namespace BeGraph.GShape {
	public class Vertex : Shape {
		// Radius of the vertex
		public static readonly int Radius = 6;
		public Vertex(string n, Point p) {
			Name = n;
			Position = new Point(p.X, p.Y);
		}

		public string Name { get; }

		public Point Position { get; private set; }

		public int X => Position.X;

		public int Y => Position.Y;

		/// <summary>
		///     Checks whether point is located inside vertex
		/// </summary>
		/// <param name="p"></param>
		/// <returns>True if point in radius, otherwise - false</returns>
		public bool IsInRange(Point p) {
			return Math.Pow(p.X - Position.X, 2) + Math.Pow(p.Y - Position.Y, 2) <= Math.Pow(4*Radius, 2);
		}

		public void MoveTo(Point p) {
			Position = p;
		}

		public override string ToString() {
			return Name + ">" + Position.X + "," + Position.Y;
		}

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType())
				return false;
			var v = (Vertex) obj;
			return Name == v.Name;
		}

		public override int GetHashCode() {
			return Id;
		}

		public override void Accept(IGVisitor visitor) {
			visitor.Visit(this);
		}

		/// <summary>
		///     Creates an edge from existing vertexes
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Edge operator +(Vertex v1, Vertex v2) {
			return new Edge(v1, v2);
		}
	}
}