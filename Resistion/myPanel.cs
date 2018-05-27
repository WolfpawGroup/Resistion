using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resistion
{
	public class myPanel : Panel
	{
		private Bitmap BgImage = null;
		public Bitmap bgImage { get { return BgImage; } set { BgImage = value; this.Refresh(); } }

		private List<Point> Redpoints = new List<Point>();
		public List<Point> redPoints { get { return Redpoints; } set { Redpoints = value; this.Refresh(); } }
		
		private List<Line> Lines = new List<Line>();
		public List<Line> lines { get { return Lines; } set { Lines = value; this.Refresh(); } }

		public Form parentForm { get; set; }

		private bool mDown = false;

		public imageHandler ih;
		public Point startPoint = Point.Empty;
		public Point endPoint = Point.Empty;

		private List<Point> arrayOfPoints = new List<Point>();
		private List<Point[]> parallelLines = new List<Point[]>();
		private List<Color> arrayOfColors = new List<Color>();

		public myPanel()
		{
			DoubleBuffered = true;

			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		public void InitializeIh()
		{
			ih = new imageHandler(bgImage, startPoint, endPoint, Bands.auto);
		}

		public void getParallelLines()
		{
			InitializeIh();
			parallelLines.Clear();

			if (Lines != null && Lines.Count > 0)
			{
				foreach (Line l in Lines)
				{
					Point[] pnts = l.getPoints(ih.calculateVectorSize());
					parallelLines.Add(pnts);
				}

				//Invalidate();
			}
		}

		public List<Dictionary<Point, Color>> measureLine(Bands lines)
		{
			arrayOfPoints.Clear();
			Lines.Add(new Line(startPoint, endPoint));

			List<Dictionary<Point, Color>> ret = new List<Dictionary<Point, Color>>();

			Bitmap bmp = new Bitmap(this.Bounds.Width, this.Bounds.Height);

			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawImage(BgImage, new Rectangle(new Point(0, 0), new Size(Bounds.Width, Bounds.Height)));
			}

			foreach (Line l in Lines)
			{
				Point p1 = l.p1;
				Point p2 = l.p2;

				Dictionary<Point, Color> tmp = new Dictionary<Point, Color>();
				List<Point> pointArr = new List<Point>();

				if (p1 != Point.Empty && p2 != Point.Empty)
				{
					ih = new imageHandler(bgImage, p1, p2, lines);
					pointArr.AddRange(ih.getPixelsAlongVector());
					arrayOfPoints.AddRange(pointArr);
					arrayOfColors.Clear();

					

					Color tmpColor = Color.White;

					foreach (Point p in pointArr)
					{
						try
						{
							tmpColor = bmp.GetPixel(p.X, p.Y);
							try
							{
								if (!tmp.Keys.Contains(p))
								{
									tmp.Add(p, tmpColor);
								}
							}
							catch(Exception ex)
							{
								Console.WriteLine(ex.ToString());
							}
							arrayOfColors.Add(tmpColor);
						}
						catch(Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
					}
					
				}

				ret.Add(tmp);
			}

			Invalidate();
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

					e.Graphics.DrawLine(Pens.Red, startPoint.X + 10, startPoint.Y + 10, endPoint.X + 10, endPoint.Y + 10);
				}

				if (parallelLines != null && parallelLines.Count > 0)
				{
					foreach (Point[] pnts in parallelLines)
					{
						foreach (Point p in pnts)
						{
							e.Graphics.DrawLine(Pens.Red, new Point(p.X + 5, p.Y + 10), new Point(p.X + 6, p.Y + 11));
						}
					}
				}

				if (arrayOfPoints != null && arrayOfPoints.Count > 0)
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
			return new object[] { p, new Size(20, 20) };
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
}
