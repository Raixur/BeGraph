using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using BeGraph.GShape;

namespace BeGraph.Visitor {
	public class GDrawer : IGVisitor {
		private const int VertexRadius = 8;

		private readonly Graphics graphics;


		public GDrawer(Graphics graphics) {
			this.graphics = graphics;
		}

		public void Visit(Graph graph) {
			foreach (var element in graph) {
				element.Accept(this);
			}
		}

		public void Visit(Edge edge) {
			//Tools for painting
			var edgePen = new Pen(Color.Black, 2) { CustomEndCap = new AdjustableArrowCap(5, 5) };

			Point textLocation;

			if (edge.First.Position != edge.Second.Position) {
				// Calculation of start and end points of edge. 
				var c = Math.Sqrt(Math.Pow(edge.Second.X - edge.First.X, 2)
				                  + Math.Pow(edge.Second.Y - edge.First.Y, 2));
				var sin = (edge.Second.Y - edge.First.Y)/c;
				var cos = (edge.Second.X - edge.First.X)/c;

				var firstPoint = new Point(edge.First.X + (int)(cos * VertexRadius),
					edge.First.Y + (int)(sin * VertexRadius));
				var secondPoint = new Point(edge.Second.X - (int)(cos * VertexRadius),
					edge.Second.Position.Y - (int)(sin * VertexRadius));

				graphics.DrawLine(edgePen, firstPoint, secondPoint);

				textLocation = new Point((firstPoint.X + secondPoint.X)/2, (firstPoint.Y + secondPoint.Y)/2 - 6);
			}
			else {
				const int radius = 24;
				graphics.DrawArc(edgePen, edge.First.Position.X - radius,
					edge.First.Position.Y - radius, radius, radius, 65, 320);
				textLocation = new Point(edge.First.Position.X - radius - 2,
					edge.First.Position.Y - radius - 1);
			}

			if (edge.Weight != .0) {
				var text = edge.Weight.ToString(CultureInfo.CurrentCulture);
				var textFont = new Font("Arial", 11);
				Brush textBrush = new SolidBrush(Color.Black);
				Brush textBackground = new SolidBrush(Color.White);

				var textSize = graphics.MeasureString(text, textFont);

				graphics.FillEllipse(textBackground, textLocation.X - 1, textLocation.Y, textSize.Width, textSize.Height);
				graphics.DrawString(text, textFont, textBrush, textLocation);

				textBackground.Dispose();
				textBrush.Dispose();
				textFont.Dispose();
			}


			edgePen.Dispose();
		}

		public void Visit(Vertex vertex) {
			var outerRingPen = new Pen(Color.Blue, 2);
			var innerCircleBrush = new SolidBrush(Color.Red);
			var textFont = new Font("Arial", 11);

			var x = vertex.X - VertexRadius;
			var y = vertex.Y - VertexRadius;

			const int d = 2 * VertexRadius;

			graphics.FillEllipse(innerCircleBrush, x, y, d, d);
			graphics.DrawEllipse(outerRingPen, x, y, d, d);
			graphics.DrawString(vertex.Name, textFont, innerCircleBrush, vertex.X + 15, vertex.Y - 20);

			textFont.Dispose();
			innerCircleBrush.Dispose();
			outerRingPen.Dispose();
		}
	}
}