using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistion
{
	public static class c_Trig
	{
		public enum trigModes
		{
			front,
			end,
			none
		}

		public static List<Line> getParallelLines(Line lOriginal, double offset)
		{
			List<Line> ret = new List<Line>();

			int x1 = lOriginal.p1.X, 
				x2 = lOriginal.p2.X, 
				y1 = lOriginal.p1.Y, 
				y2 = lOriginal.p2.Y;

			double Length = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

			double offsetPixels = offset;

			ret.Add(new Line(
				new Point((int)(x1 + offsetPixels * (y2 - y1) / Length), (int)(y1 + offsetPixels * (x1 - x2) / Length)),
				new Point((int)(x2 + offsetPixels * (y2 - y1) / Length), (int)(y2 + offsetPixels * (x1 - x2) / Length))
				)
			);

			ret.Add(new Line(
				new Point((int)(x1 - offsetPixels * (y2 - y1) / Length), (int)(y1 - offsetPixels * (x1 - x2) / Length)),
				new Point((int)(x2 - offsetPixels * (y2 - y1) / Length), (int)(y2 - offsetPixels * (x1 - x2) / Length))
				)
			);

			return ret;
		}

		/* === BS i don't need but still worked hard on so I don't want to throw it out... === */
		/*
		public static Line getPerpendicularLine(Point pStart, Point pEnd, trigModes mode)
		{
			double slope = getNegativeReciprocalSlope(pStart, pEnd);
			Point midpoint;

			if(mode == trigModes.front)
			{
				midpoint = pStart;//getMidPoint(pStart, pEnd);
			}
			else
			{
				midpoint = pEnd;
			}

			double Intercept = getYIntercept((int)slope, midpoint);
			Point ret = new Point();
			ret.X = midpoint.X + 8;
			ret.Y = (int)((slope * (midpoint.X + 8)) + Intercept);

			Line l = new Line(midpoint, ret);
			return l;
		}

		public static double getSlope(Point pStart, Point pEnd)
		{
			return (((double)pEnd.Y - (double)pStart.Y) / ((double)pEnd.X - (double)pStart.X));
		}

		public static double getNegativeReciprocalSlope(Point pStart, Point pEnd)
		{
			return -1 / getSlope(pStart, pEnd);
		}

		public static Point getMidPoint(Point pStart, Point pEnd)
		{
			Point ret = new Point();

			ret.X = (pStart.X + pEnd.X) / 2;
			ret.Y = (pStart.Y + pEnd.Y) / 2;

			return ret;
		}

		public static int getYIntercept(int slope, Point midpoint)
		{
			return -slope * midpoint.X + midpoint.Y;
		}
		*/
	}
}
