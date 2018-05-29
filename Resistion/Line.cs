using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistion
{
	/// <summary>
	/// Got code from https://stackoverflow.com/questions/16028752/how-do-i-get-all-the-points-between-two-point-objects
	/// </summary>
	public class Line
	{
		public Point p1, p2;

		public Line(Point p1, Point p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		public int Length()
		{
			int ret = 0;

			int lineA = Math.Abs(p1.X - p2.X);
			int lineB = Math.Abs(p1.Y - p2.Y);
			
			ret = (int)Math.Sqrt(Math.Pow(lineA, 2) + Math.Pow(lineB, 2));

			return ret;
		}

		public Point[] getPoints(int quantity)
		{
			quantity = Math.Abs(quantity);

			var points = new Point[quantity];
			int ydiff = p2.Y - p1.Y, xdiff = p2.X - p1.X;
			double slope = (double)(p2.Y - p1.Y) / (p2.X - p1.X);
			double x, y;

			--quantity;

			for (double i = 0; i < quantity; i++)
			{
				y = slope == 0 ? 0 : ydiff * (i / quantity);
				x = slope == 0 ? xdiff * (i / quantity) : y / slope;
				points[(int)i] = new Point((int)Math.Round(x) + p1.X, (int)Math.Round(y) + p1.Y);
			}

			points[quantity] = p2;
			return points;
		}
	}
}
