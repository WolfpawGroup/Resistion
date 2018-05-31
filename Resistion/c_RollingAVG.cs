using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistion
{
	public class rollingColorAVG
	{
		private int Length;
		private int Tolerance;
		private List<Color> Colors = new List<Color>();

		public rollingColorAVG(int length, int tolerance)
		{
			Length = length;
			Tolerance = tolerance;
		}

		public Color getColorAverage(List<Color> cl)
		{
			if (cl.Count > 0)
			{
				int r = 0;
				int g = 0;
				int b = 0;

				foreach (Color cc in cl) { r += cc.R; g += cc.G; b += cc.B; }

				Color c = Color.FromArgb(255, r / cl.Count, g / cl.Count, b / cl.Count);
				return c;
			}
			else
			{
				return Color.Transparent;
			}
		}

		public Color AddAverageOfColors(List<Color> cl)
		{
			Color c = getColorAverage(cl);
			Colors.Add(c);
			return getAverage();
		}

		public Color Add(Color c)
		{
			Color ret = Color.White;

			if (Colors.Count == Length)
			{
				Colors.RemoveAt(0);
			}

			Colors.Add(c);

			ret = getAverage();

			return ret;
		}

		public Color getAverage()
		{
			Color ret = Color.White;

			int len = Colors.Count;

			if (len == 0)
			{
				ret = Color.FromArgb(0, 0, 0, 0);
			}
			else
			{
				int[] col = new int[3] { 0, 0, 0 };

				foreach (Color c in Colors)
				{
					col[0] += c.R;
					col[1] += c.G;
					col[2] += c.B;
				}

				col[0] = (byte)(col[0] / len);
				col[1] = (byte)(col[1] / len);
				col[2] = (byte)(col[2] / len);

				ret = Color.FromArgb(255, col[0], col[1], col[2]);
			}

			return ret;
		}

		public bool ColorInTolerance(Color c)
		{
			Color avg = getAverage();

			if (avg == Color.FromArgb(0, 0, 0, 0)) { return true; }
			/*
			if (
				(c.R > avg.R + Tolerance || c.R < avg.R - Tolerance) ||
				(c.G > avg.G + Tolerance || c.G < avg.G - Tolerance) ||
				(c.B > avg.B + Tolerance || c.B < avg.B - Tolerance)
			)
			*/

			int max = c.R + c.G + c.B + (int)(c.GetSaturation() + c.GetBrightness() + c.GetHue());
			int av = avg.R + avg.G + avg.B + (int)(avg.GetSaturation() + avg.GetBrightness() + avg.GetHue());
			int tol = Tolerance * 6;
			/*
			if(


				(c.GetHue() < avg.GetHue() - Tolerance || c.GetHue() > avg.GetHue() + Tolerance) &&
				(c.GetBrightness() < avg.GetBrightness() - Tolerance || c.GetBrightness() > avg.GetBrightness() + Tolerance) ||
				(
					(c.R > avg.R + Tolerance || c.R < avg.R - Tolerance) ||
					(c.G > avg.G + Tolerance || c.G < avg.G - Tolerance) ||
					(c.B > avg.B + Tolerance || c.B < avg.B - Tolerance)
				)
			)
			*/
			/*if(max < av - tol || max > av + tol)*/
			if(
				((c.R * c.R) > (avg.R * avg.R + Tolerance * Tolerance) || (c.R * c.R) < (avg.R * avg.R - Tolerance * Tolerance))||
				((c.G * c.G) > (avg.G * avg.G + Tolerance * Tolerance) || (c.G * c.G) < (avg.G * avg.G - Tolerance * Tolerance))||
				((c.B * c.B) > (avg.B * avg.B + Tolerance * Tolerance) || (c.B * c.B) < (avg.B * avg.B - Tolerance * Tolerance))

			)
			{
				return false;
			}

			return true;
		}
	}
}
