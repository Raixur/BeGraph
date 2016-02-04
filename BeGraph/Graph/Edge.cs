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
			double c = Math.Sqrt(Math.Pow(second.Pos.X - first.Pos.X, 2) + Math.Pow(second.Pos.Y - first.Pos.Y, 2));
			double sin = (second.Pos.Y - first.Pos.Y) / c;
			double cos = (second.Pos.X - first.Pos.X) / c;


			Point fRad = new Point(first.Pos.X + (int)(cos * Vertex.r), first.Pos.Y + (int)(sin * Vertex.r));
			Point sRad = new Point(second.Pos.X - (int)(cos * Vertex.r), second.Pos.Y - (int)(sin * Vertex.r));
			Pen p = new Pen(Color.DarkBlue,2);

			// Рисование линии между вершинам графа
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			gr.DrawLine(p, fRad, sRad);

			p.Dispose();
		}
	}
}
