using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistion
{
	public class imageHandler
	{
		private Bitmap image;
		private Point startPoint;
		private Point endPoint;
		private Bands lines;

		private List<Color> pixels = new List<Color>();

		public imageHandler(Bitmap Image, Point StartPoint, Point EndPoint, Bands Lines)
		{
			image = Image;
			startPoint = StartPoint;
			endPoint = EndPoint;
			lines = Lines;
		}

		public bool canDetect()
		{
			bool ret = false;



			return ret;
		}

		public int calculateVectorSize()
		{
			return ((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y));
		}

		public Point[] getPixelsAlongVector()
		{
			var line = new Line(startPoint, endPoint);
			var points = line.getPoints((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y));
			return points;
		}

	}
}
