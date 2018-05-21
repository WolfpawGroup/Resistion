using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resistion
{
	public partial class Form1 : Form
	{
		Bitmap bmp = null;

		public Form1()
		{
			InitializeComponent();
			p_Img.parentForm = this;
		}

		private void btn_OpenImg_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				bmp = (Bitmap)new Bitmap(ofd.FileName).Clone();
				p_Img.clearPoints();
				p_Img.bgImage = bmp;
			}
		}

		private void p_Img_SizeChanged(object sender, EventArgs e)
		{
			p_Img.Invalidate();
		}

		private void btn_Measure_Click(object sender, EventArgs e)
		{
			if (bmp != null)
			{

				Bands lines = Bands.none;
				if (rb_Auto.Checked)
				{
					lines = Bands.auto;
				}
				else if (rb_3Band.Checked)
				{
					lines = Bands.bands_3;
				}
				else if (rb_4Band.Checked)
				{
					lines = Bands.bands_4;
				}
				else if (rb_5Band.Checked)
				{
					lines = Bands.bands_5;
				}
				else if (rb_6Band.Checked)
				{
					lines = Bands.bands_6;
				}

				Dictionary<Point, Color> colors = p_Img.measureLine(lines);

				List<List<Color>> colorBands = new List<List<Color>>();

				int i = 0;
				int delta = 0;

				rollingColorAVG avg = new rollingColorAVG(30, 50);

				List<Point> redPoints = new List<Point>();

				foreach(KeyValuePair<Point, Color> kvp in colors)
				{
					Color c = kvp.Value;

					if (avg.ColorInTolerance(c))
					{
						avg.Add(c);
						redPoints.Add(kvp.Key);
						rtb_Data.Text += (i + "/" + colors.Count).ToString().PadRight(9) + " | " + 
							c.R.ToString().PadLeft(3, '0') + " " + 
							c.G.ToString().PadLeft(3, '0') + " " + 
							c.B.ToString().PadLeft(3, '0') + " " + "\r\n";
						i++;
					}

					
					//rtb_Data.Text += c.R + ", " + c.G + ", " + c.B + "\r\n";
				}

				p_Img.redPoints = redPoints;
			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}

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

		public Color Add(Color c)
		{
			Color ret = Color.White;

			if(Colors.Count == Length)
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

			if(avg == Color.FromArgb(0, 0, 0, 0)) { return true; }

			if(
				(c.R > avg.R + Tolerance || c.R < avg.R - Tolerance) ||
				(c.G > avg.G + Tolerance || c.G < avg.G - Tolerance) ||
				(c.B > avg.B + Tolerance || c.B < avg.B - Tolerance)
			)
			{
				return false;
			}

			return true;
		}
	}

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

		public void calculateVector()
		{
			Point v = new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
		}

		public Point[] getPixelsAlongVector()
		{
			var line = new Line(startPoint, endPoint);
			var points = line.getPoints((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y));
			return points;
		}

	}

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

	public class myPanel : Panel
	{
		private Bitmap BgImage = null;
		public Bitmap bgImage { get { return BgImage; } set { BgImage = value; this.Refresh(); } }

		private List<Point> Redpoints = new List<Point>();
		public List<Point> redPoints { get { return Redpoints; } set { Redpoints = value; this.Refresh(); } }


		public Form parentForm { get; set; }

		private bool mDown = false;

		private Point startPoint = Point.Empty;
		private Point endPoint = Point.Empty;

		private Point[] arrayOfPoints = null;
		private List<Color> arrayOfColors = new List<Color>();

		public myPanel()
		{
			DoubleBuffered = true;

			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		public Dictionary<Point, Color> measureLine(Bands lines)
		{
			Dictionary<Point, Color> ret = new Dictionary<Point, Color>();

			if (startPoint != Point.Empty && endPoint != Point.Empty)
			{
				imageHandler ih = new imageHandler(bgImage, startPoint, endPoint, lines);
				arrayOfPoints = ih.getPixelsAlongVector();
				arrayOfColors.Clear();

				Bitmap bmp = new Bitmap(this.Bounds.Width, this.Bounds.Height);

				using(Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(BgImage, new Rectangle(new Point(0, 0), new Size(Bounds.Width, Bounds.Height)));
				}

				Color tmpColor = Color.White;

				foreach (Point p in arrayOfPoints)
				{
					tmpColor = bmp.GetPixel(p.X, p.Y);
					try
					{
						ret.Add(new Point(p.X, p.Y), tmpColor);
					}
					catch
					{

					}
					arrayOfColors.Add(tmpColor);
				}


				Invalidate();
			}

			return ret;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (BgImage != null)
			{
				e.Graphics.DrawImage(BgImage, new Rectangle(new Point(0, 0), new Size(Bounds.Width, Bounds.Height)));

				if (startPoint != Point.Empty)
				{
					object[] oa = getCircleAtPoint(startPoint);
					e.Graphics.DrawEllipse(Pens.Red, new Rectangle((Point)oa[0], (Size)oa[1]));
				}

				if (endPoint != Point.Empty)
				{
					object[] oa = getCircleAtPoint(endPoint);
					e.Graphics.DrawEllipse(Pens.Red, new Rectangle((Point)oa[0], (Size)oa[1]));

					e.Graphics.DrawLine(Pens.Red, startPoint.X + 10, startPoint.Y + 10, endPoint.X + 10, endPoint.Y +10);
				}

				if (arrayOfPoints != null && arrayOfPoints.Length > 0)
				{
					foreach (Point p in arrayOfPoints)
					{
						e.Graphics.DrawLine(Pens.GreenYellow, new Point(p.X + 10, p.Y + 10), new Point(p.X + 11, p.Y + 11));
					}
				}

				if (Redpoints != null && Redpoints.Count > 0)
				{
					foreach (Point p in Redpoints)
					{
						e.Graphics.DrawLine(Pens.Red, new Point(p.X + 5, p.Y + 10), new Point(p.X + 6, p.Y + 11));
					}
				}
			}


		}

		public object[] getCircleAtPoint(Point p)
		{
			return new object[] { p , new Size(20, 20) };
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			mDown = true;
			startPoint = new Point(Cursor.Position.X - parentForm.Left - (Bounds.Left + Parent.Bounds.Left + 18), Cursor.Position.Y - parentForm.Top - (Bounds.Top + Parent.Bounds.Top + 39));
			endPoint = Point.Empty;

			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			mDown = false;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (mDown)
			{
				endPoint = new Point(Cursor.Position.X - parentForm.Left - (Bounds.Left + Parent.Bounds.Left + 18), Cursor.Position.Y - parentForm.Top - (Bounds.Top + Parent.Bounds.Top + 39));
			}

			Invalidate();
		}

		public void clearPoints()
		{
			startPoint = endPoint = Point.Empty;
		}
	}

	public enum Bands
	{
		auto,
		bands_3,
		bands_4,
		bands_5,
		bands_6,
		none
	}

}
