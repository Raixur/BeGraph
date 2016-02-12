using System;
using System.Drawing;

namespace BeGraph
{
    class Edge:Figure{

		private Vertex first;
		private Vertex second;
        private double weight;

        public Edge(Vertex f, Vertex s, double w = 0.0){
            first = f;
            second = s;
            weight = w;
        }

		public Vertex GetFirst() {
			return first;
		}

		public Vertex GetSecond() {
			return second;
		}

		public override string ToString() {
			return first + "->" + second + " (" + weight + ")";
		}

		public override void Draw(Graphics gr) {
			// Calculation of begin and end points of edge. 
			double c = Math.Sqrt(Math.Pow(second.Position.X - first.Position.X, 2) + Math.Pow(second.Position.Y - first.Position.Y, 2));
			double sin = (second.Position.Y - first.Position.Y) / c;
			double cos = (second.Position.X - first.Position.X) / c;
			Point firstPoint = new Point(first.Position.X + (int)(cos * Vertex.r), first.Position.Y + (int)(sin * Vertex.r));
			Point secondPoint = new Point(second.Position.X - (int)(cos * Vertex.r), second.Position.Y - (int)(sin * Vertex.r));
			Pen edgePen = new Pen(Color.DarkBlue, 2);
			

			gr.DrawLine(edgePen, firstPoint, secondPoint);

			if (weight != 0) {
				string text = weight.ToString();
				Font textFont = new Font("Arial", 11);
				Brush textBrush = new SolidBrush(Color.Black);
				Brush textBackground = new SolidBrush(Color.White);
				Point textLocation = new Point((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2 - 6);

				SizeF textSize = new Size();
				textSize = gr.MeasureString(text, textFont);

				gr.FillEllipse(textBackground, textLocation.X, textLocation.Y, textSize.Width + 1, textSize.Height + 1);
				gr.DrawString(weight.ToString(), textFont, textBrush, textLocation);

				textBackground.Dispose();
				textBrush.Dispose();
				textFont.Dispose();
			}
			edgePen.Dispose();
		}
	}
}
