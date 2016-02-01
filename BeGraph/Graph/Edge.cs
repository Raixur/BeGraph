using System;
using System.Drawing;

namespace BeGraph
{
    class Edge:Figure{

		Vertex first;
		Vertex second;
        double weight;

        public override string ToString(){
            return first + "->" + second + " (" + weight + ")";
        }

        public Edge(Vertex f, Vertex s, double w = 0.0){
            first = f;
            second = s;
            weight = w;
        }

		public Vertex getFirst() {
			return first;
		}

		public Vertex getSecond() {
			return second;
		}

		public override void draw(Graphics gr) {
			// Висчитавание координат начала и конца вершины
			double c = Math.Sqrt(Math.Pow(second.position.X - first.position.X, 2) + Math.Pow(second.position.Y - first.position.Y, 2));
			double sin = (second.position.Y - first.position.Y) / c;
			double cos = (second.position.X - first.position.X) / c;


			Point fRad = new Point(first.position.X + (int)(cos * Vertex.r), first.position.Y + (int)(sin * Vertex.r));
			Point sRad = new Point(second.position.X - (int)(cos * Vertex.r), second.position.Y - (int)(sin * Vertex.r));
			Pen p = new Pen(Color.DarkBlue,2);

			// Рисование линии между вершинам графа
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.DrawLine(p, fRad, sRad);

			p.Dispose();
		}
	}
}
