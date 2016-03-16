using System;
using System.Drawing;


namespace BeGraph{
	class Vertex : Figure {

		// Radius of the vertex
		public static readonly int r = 6;

		// Name of the vertex, which would be displayed (must be unique for graph)
		private string name;
		
		// Position on displaying element
		private Point position;

		public string Name {
			get {
				return name;
			}
		}
		
		public Point Position {
			get {
				return position;
			}
		}

		public Vertex(string n, Point p) {
			name = n;
			position = new Point(p.X, p.Y);
		}

		/// <summary>
		/// Checks whether point is located inside vertex
		/// </summary>
		/// <param name="p"></param>
		/// <returns>True if point in radius, otherwise - false</returns>
		public bool IsInRange(Point p) {
			return (Math.Pow(p.X - position.X, 2) + Math.Pow(p.Y - position.Y, 2) <= Math.Pow(4*r, 2));
		}

		public void MoveTo(Point p) {
			position = p;
		}

		public override string ToString() {
			return name + ">" + position.X + "," + position.Y;
		}

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType())
				return false;
			Vertex v = (Vertex)obj;
			return name == v.name;
		}

		public override int GetHashCode() {
			return ID;
		}

		/// <summary>
		/// Draws circle and name of the vertex
		/// </summary>
		/// <param name="gr"></param>
		public override void Draw(Graphics gr) {
			Pen outerRingPen = new Pen(Color.Blue, 2);
			SolidBrush innerCircleBrush = new SolidBrush(Color.Red);
			Font textFont = new Font("Arial", 11);

			gr.FillEllipse(innerCircleBrush, position.X-r, position.Y-r, 2*r, 2*r);
			gr.DrawEllipse(outerRingPen, position.X - r, position.Y - r, 2 * r, 2 * r);
			gr.DrawString(name, textFont, innerCircleBrush, position.X + 15, position.Y - 20);

			textFont.Dispose();
			innerCircleBrush.Dispose();
			outerRingPen.Dispose();
		}

		/// <summary>
		/// Creates an edge from existing vertexes
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Edge operator +(Vertex v1, Vertex v2) {
			return new Edge(v1, v2);
		}
	}
}
