namespace Resistion
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.p_Img = new Resistion.myPanel();
			this.btn_Measure = new System.Windows.Forms.Button();
			this.rb_Auto = new System.Windows.Forms.RadioButton();
			this.rb_4Band = new System.Windows.Forms.RadioButton();
			this.rb_5Band = new System.Windows.Forms.RadioButton();
			this.rtb_Data = new System.Windows.Forms.RichTextBox();
			this.btn_OpenImg = new System.Windows.Forms.Button();
			this.btn_Close = new System.Windows.Forms.Button();
			this.rb_3Band = new System.Windows.Forms.RadioButton();
			this.rb_6Band = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel1.Controls.Add(this.p_Img);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(464, 426);
			this.panel1.TabIndex = 0;
			// 
			// p_Img
			// 
			this.p_Img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.p_Img.BackColor = System.Drawing.SystemColors.Control;
			this.p_Img.bgImage = null;
			this.p_Img.Location = new System.Drawing.Point(3, 3);
			this.p_Img.Name = "p_Img";
			this.p_Img.parentForm = null;
			this.p_Img.Size = new System.Drawing.Size(458, 420);
			this.p_Img.TabIndex = 0;
			this.p_Img.SizeChanged += new System.EventHandler(this.p_Img_SizeChanged);
			// 
			// btn_Measure
			// 
			this.btn_Measure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Measure.Location = new System.Drawing.Point(485, 52);
			this.btn_Measure.Name = "btn_Measure";
			this.btn_Measure.Size = new System.Drawing.Size(174, 35);
			this.btn_Measure.TabIndex = 1;
			this.btn_Measure.Text = "Measure";
			this.btn_Measure.UseVisualStyleBackColor = true;
			this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
			// 
			// rb_Auto
			// 
			this.rb_Auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb_Auto.AutoSize = true;
			this.rb_Auto.Checked = true;
			this.rb_Auto.Location = new System.Drawing.Point(485, 94);
			this.rb_Auto.Name = "rb_Auto";
			this.rb_Auto.Size = new System.Drawing.Size(80, 17);
			this.rb_Auto.TabIndex = 2;
			this.rb_Auto.TabStop = true;
			this.rb_Auto.Text = "Auto detect";
			this.rb_Auto.UseVisualStyleBackColor = true;
			// 
			// rb_4Band
			// 
			this.rb_4Band.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb_4Band.AutoSize = true;
			this.rb_4Band.Location = new System.Drawing.Point(485, 136);
			this.rb_4Band.Name = "rb_4Band";
			this.rb_4Band.Size = new System.Drawing.Size(58, 17);
			this.rb_4Band.TabIndex = 3;
			this.rb_4Band.Text = "4 band";
			this.rb_4Band.UseVisualStyleBackColor = true;
			// 
			// rb_5Band
			// 
			this.rb_5Band.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb_5Band.AutoSize = true;
			this.rb_5Band.Location = new System.Drawing.Point(485, 157);
			this.rb_5Band.Name = "rb_5Band";
			this.rb_5Band.Size = new System.Drawing.Size(58, 17);
			this.rb_5Band.TabIndex = 4;
			this.rb_5Band.Text = "5 band";
			this.rb_5Band.UseVisualStyleBackColor = true;
			// 
			// rtb_Data
			// 
			this.rtb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtb_Data.Location = new System.Drawing.Point(485, 201);
			this.rtb_Data.Name = "rtb_Data";
			this.rtb_Data.Size = new System.Drawing.Size(174, 180);
			this.rtb_Data.TabIndex = 5;
			this.rtb_Data.Text = "";
			// 
			// btn_OpenImg
			// 
			this.btn_OpenImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_OpenImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_OpenImg.Location = new System.Drawing.Point(485, 11);
			this.btn_OpenImg.Name = "btn_OpenImg";
			this.btn_OpenImg.Size = new System.Drawing.Size(174, 35);
			this.btn_OpenImg.TabIndex = 6;
			this.btn_OpenImg.Text = "Open Image";
			this.btn_OpenImg.UseVisualStyleBackColor = true;
			this.btn_OpenImg.Click += new System.EventHandler(this.btn_OpenImg_Click);
			// 
			// btn_Close
			// 
			this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Close.Location = new System.Drawing.Point(485, 389);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(174, 51);
			this.btn_Close.TabIndex = 7;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// rb_3Band
			// 
			this.rb_3Band.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb_3Band.AutoSize = true;
			this.rb_3Band.Location = new System.Drawing.Point(485, 115);
			this.rb_3Band.Name = "rb_3Band";
			this.rb_3Band.Size = new System.Drawing.Size(58, 17);
			this.rb_3Band.TabIndex = 8;
			this.rb_3Band.Text = "3 band";
			this.rb_3Band.UseVisualStyleBackColor = true;
			// 
			// rb_6Band
			// 
			this.rb_6Band.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb_6Band.AutoSize = true;
			this.rb_6Band.Location = new System.Drawing.Point(485, 178);
			this.rb_6Band.Name = "rb_6Band";
			this.rb_6Band.Size = new System.Drawing.Size(58, 17);
			this.rb_6Band.TabIndex = 9;
			this.rb_6Band.Text = "6 band";
			this.rb_6Band.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(668, 450);
			this.Controls.Add(this.rb_6Band);
			this.Controls.Add(this.rb_3Band);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.btn_OpenImg);
			this.Controls.Add(this.rtb_Data);
			this.Controls.Add(this.rb_5Band);
			this.Controls.Add(this.rb_4Band);
			this.Controls.Add(this.rb_Auto);
			this.Controls.Add(this.btn_Measure);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Resistance Measure";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private myPanel p_Img;
		private System.Windows.Forms.Button btn_Measure;
		private System.Windows.Forms.RadioButton rb_Auto;
		private System.Windows.Forms.RadioButton rb_4Band;
		private System.Windows.Forms.RadioButton rb_5Band;
		private System.Windows.Forms.RichTextBox rtb_Data;
		private System.Windows.Forms.Button btn_OpenImg;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.RadioButton rb_3Band;
		private System.Windows.Forms.RadioButton rb_6Band;
	}
}

