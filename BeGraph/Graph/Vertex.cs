using System;
using System.Drawing;
using System.Windows.Forms;

namespace BeGraph{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
	class Vertex : Figure {
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
		string name;
		public Point position;

		public static readonly int r = 8;

        public Vertex(string n) {
            name = n;
        }

		public Vertex(string n, Point p) {
			name = n;
			position = new Point(p.X, p.Y);
		}

		public bool isInRange(Point p) {
			return (Math.Pow(p.X - position.X, 2) + Math.Pow(p.Y - position.Y, 2) <= Math.Pow(4*r, 2));
		}

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType())
				return false;
			Vertex v = (Vertex)obj;
			return name == v.name;
		}

		public override void draw(PictureBox pb) {
			Graphics gr = pb.CreateGraphics();
			SolidBrush b = new SolidBrush(Color.Red);
			Font f = new Font("Arial", 11);

			// Рисование элипса и названия точки
			gr.FillEllipse(b, position.X-r, position.Y-r, 2*r, 2*r);
			gr.DrawString(name, f, b, position.X + 15, position.Y - 10);

			f.Dispose();
			b.Dispose();
			gr.Dispose();
		}

		public static Edge operator +(Vertex v1, Vertex v2) {
			return new Edge(v1, v2);
		}
	}
}
