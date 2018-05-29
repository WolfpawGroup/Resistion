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

		public int tolerance = 30;
		public int sampleDistance = 10;

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
			p_Img.colorsForDemo.Clear();
			rtb_Data.Clear();

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

				int width = sampleDistance;

				p_Img.lines.Clear();
				p_Img.lines.AddRange(c_Trig.getParallelLines(new Line(p_Img.startPoint, p_Img.endPoint), width));

				width += sampleDistance;

				p_Img.lines.AddRange(c_Trig.getParallelLines(new Line(p_Img.startPoint, p_Img.endPoint), width));

				width += sampleDistance;

				p_Img.lines.AddRange(c_Trig.getParallelLines(new Line(p_Img.startPoint, p_Img.endPoint), width));
				p_Img.getParallelLines();

				List<Dictionary<Point, Color>> colors = p_Img.measureLine(lines);

				List<List<Color>> colorBands = new List<List<Color>>();

				int maxLength = 0;
				foreach(Dictionary<Point, Color> d in colors) { if(d.Count > maxLength) { maxLength = d.Count; } }

				int i = 0;
				int delta = 0;

				rollingColorAVG avg = new rollingColorAVG(30, tolerance);
				int maxShortBreak = p_Img.lines.Last().Length() / 20;
				int currentBreakLength = 0;

				List<List<Point>> bandList = new List<List<Point>>();

				List<Point> redPoints = new List<Point>();

				List<List<Color>> colorbands = new List<List<Color>>();

				List<Color> tmp = new List<Color>();

				for(int len = 0; len < maxLength; len++)
				{
					List<Color> ca = new List<Color>();

					foreach (Dictionary<Point, Color> dict in colors)
					{

						if (dict.Count > len)
						{
							//rtb_Data.Text += dict.ElementAt(len).Key.ToString() + "\r\n";
							ca.Add(dict.ElementAt(len).Value);
						}
					}

					Color c = avg.getColorAverage(ca);

					if (avg.ColorInTolerance(c))
					{
						avg.AddAverageOfColors(ca);

						tmp.Add(c);

						foreach(Dictionary<Point, Color> dict in colors)
						{
							try
							{
								redPoints.Add(dict.ElementAt(len).Key);
							}
							catch (ArgumentOutOfRangeException) { }
							catch (Exception ex) { Console.WriteLine(ex.ToString()); }
						}

						
						i++;
						currentBreakLength = 0;
					}
					else
					{
						
						
						if (currentBreakLength >= maxShortBreak)
						{
							len -= currentBreakLength;

							delta++;
							colorBands.Add(tmp);

							tmp = new List<Color>();
							avg = new rollingColorAVG(30, tolerance);

							currentBreakLength = 0;
						}
						
						
						currentBreakLength++;
					}
				}

				if (tmp.Count > 0) { colorBands.Add(tmp); }

				foreach (List<Color> cols in colorBands)
				{
					rollingColorAVG a = new rollingColorAVG(30, tolerance);
					Color c = a.AddAverageOfColors(cols);

					p_Img.colorsForDemo.Add(c);
					

				}
				
				p_Img.redPoints = redPoints;
			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			Application.Exit();
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
