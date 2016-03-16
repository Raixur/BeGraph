using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BeGraph
{
    class Edge:Figure{

		private Vertex first;
		private Vertex second;
        private double weight;

		public Vertex First {
			get {
				return first;
			}
		} 
		public Vertex Second {
			get {
				return second;
			}
		}

		public double Weight {
			get {
				return weight;
			}
		}

        public Edge(Vertex f, Vertex s, double w = 0.0){
            first = f;
            second = s;
            weight = w;
        }
		

		public override string ToString() {
			return "[" + first + "]-[" + second + "]=[" + weight + "]";
		}

		public override void Draw(Graphics gr) {
			//Tools for painting
			AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
			Pen edgePen = new Pen(Color.Black, 2);
			edgePen.CustomEndCap = bigArrow;

			Point textLocation;

			if (first.Position != second.Position) {
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

				// Calculation of start and end points of edge. 
				double c = Math.Sqrt(Math.Pow(second.Position.X - first.Position.X, 2) + Math.Pow(second.Position.Y - first.Position.Y, 2));
				double sin = (second.Position.Y - first.Position.Y) / c;
				double cos = (second.Position.X - first.Position.X) / c;
				Point firstPoint = new Point(first.Position.X + (int)(cos * Vertex.r), first.Position.Y + (int)(sin * Vertex.r));
				Point secondPoint = new Point(second.Position.X - (int)(cos * Vertex.r), second.Position.Y - (int)(sin * Vertex.r));

				gr.DrawLine(edgePen, firstPoint, secondPoint);

				textLocation = new Point((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2 - 6);
			}
			else {
				int radius = 24;
				gr.DrawArc(edgePen, first.Position.X - radius, first.Position.Y - radius, radius, radius, 65, 320);
				textLocation = new Point(first.Position.X - radius - 2, first.Position.Y - radius - 1);
			}

			if (weight != 0) {
				string text = weight.ToString();
				Font textFont = new Font("Arial", 11);
				Brush textBrush = new SolidBrush(Color.Black);
				Brush textBackground = new SolidBrush(Color.White);
				
				SizeF textSize = gr.MeasureString(text, textFont);

				gr.FillEllipse(textBackground, textLocation.X - 1, textLocation.Y, textSize.Width, textSize.Height);
				gr.DrawString(text, textFont, textBrush, textLocation);

				textBackground.Dispose();
				textBrush.Dispose();
				textFont.Dispose();
			}


			edgePen.Dispose();
		}
	}
}
