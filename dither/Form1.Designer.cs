
namespace dither
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Primordia_Image_Plane = new System.Windows.Forms.Panel();
            this.Primordial_Image = new System.Windows.Forms.PictureBox();
            this.Modified_Image = new System.Windows.Forms.PictureBox();
            this.Modified_Image_Plane = new System.Windows.Forms.Panel();
            this.Load_Button = new System.Windows.Forms.Button();
            this.Dither = new System.Windows.Forms.Button();
            this.Steps_Bar = new System.Windows.Forms.TrackBar();
            this.Method_Selector = new System.Windows.Forms.CheckBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.SizeModBox = new System.Windows.Forms.ComboBox();
            this.LoadBox = new System.Windows.Forms.PictureBox();
            this.PerSentCouner = new System.Windows.Forms.Label();
            this.PerSentTimer = new System.Windows.Forms.Timer(this.components);
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.PixelLable = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Primordia_Image_Plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Primordial_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Image)).BeginInit();
            this.Modified_Image_Plane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Steps_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Primordia_Image_Plane
            // 
            this.Primordia_Image_Plane.BackColor = System.Drawing.Color.Gray;
            this.Primordia_Image_Plane.Controls.Add(this.Primordial_Image);
            this.Primordia_Image_Plane.Location = new System.Drawing.Point(16, 33);
            this.Primordia_Image_Plane.Name = "Primordia_Image_Plane";
            this.Primordia_Image_Plane.Size = new System.Drawing.Size(310, 310);
            this.Primordia_Image_Plane.TabIndex = 0;
            // 
            // Primordial_Image
            // 
            this.Primordial_Image.Image = ((System.Drawing.Image)(resources.GetObject("Primordial_Image.Image")));
            this.Primordial_Image.Location = new System.Drawing.Point(3, 3);
            this.Primordial_Image.Name = "Primordial_Image";
            this.Primordial_Image.Size = new System.Drawing.Size(304, 304);
            this.Primordial_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Primordial_Image.TabIndex = 0;
            this.Primordial_Image.TabStop = false;
            // 
            // Modified_Image
            // 
            this.Modified_Image.Image = ((System.Drawing.Image)(resources.GetObject("Modified_Image.Image")));
            this.Modified_Image.Location = new System.Drawing.Point(3, 3);
            this.Modified_Image.Name = "Modified_Image";
            this.Modified_Image.Size = new System.Drawing.Size(304, 304);
            this.Modified_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Modified_Image.TabIndex = 0;
            this.Modified_Image.TabStop = false;
            this.Modified_Image.Paint += new System.Windows.Forms.PaintEventHandler(this.Modified_Image_OnPaint);
            // 
            // Modified_Image_Plane
            // 
            this.Modified_Image_Plane.BackColor = System.Drawing.Color.Gray;
            this.Modified_Image_Plane.Controls.Add(this.Modified_Image);
            this.Modified_Image_Plane.Location = new System.Drawing.Point(332, 33);
            this.Modified_Image_Plane.Name = "Modified_Image_Plane";
            this.Modified_Image_Plane.Size = new System.Drawing.Size(310, 310);
            this.Modified_Image_Plane.TabIndex = 1;
            // 
            // Load_Button
            // 
            this.Load_Button.BackColor = System.Drawing.Color.White;
            this.Load_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Button.Font = new System.Drawing.Font("Montserrat Light", 14.25F);
            this.Load_Button.ForeColor = System.Drawing.Color.Black;
            this.Load_Button.Location = new System.Drawing.Point(19, 414);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(141, 46);
            this.Load_Button.TabIndex = 3;
            this.Load_Button.Text = "Load";
            this.Load_Button.UseVisualStyleBackColor = false;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // Dither
            // 
            this.Dither.BackColor = System.Drawing.Color.White;
            this.Dither.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dither.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dither.Font = new System.Drawing.Font("Montserrat Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dither.ForeColor = System.Drawing.Color.Black;
            this.Dither.Location = new System.Drawing.Point(501, 414);
            this.Dither.Name = "Dither";
            this.Dither.Size = new System.Drawing.Size(141, 46);
            this.Dither.TabIndex = 4;
            this.Dither.Text = "Dither";
            this.Dither.UseVisualStyleBackColor = false;
            this.Dither.Click += new System.EventHandler(this.Dither_Click);
            // 
            // Steps_Bar
            // 
            this.Steps_Bar.LargeChange = 1;
            this.Steps_Bar.Location = new System.Drawing.Point(19, 349);
            this.Steps_Bar.Maximum = 20;
            this.Steps_Bar.Minimum = 1;
            this.Steps_Bar.Name = "Steps_Bar";
            this.Steps_Bar.Size = new System.Drawing.Size(304, 45);
            this.Steps_Bar.TabIndex = 1;
            this.Steps_Bar.Value = 1;
            // 
            // Method_Selector
            // 
            this.Method_Selector.AutoSize = true;
            this.Method_Selector.Font = new System.Drawing.Font("Montserrat Light", 14.25F);
            this.Method_Selector.Location = new System.Drawing.Point(529, 349);
            this.Method_Selector.Name = "Method_Selector";
            this.Method_Selector.Size = new System.Drawing.Size(113, 30);
            this.Method_Selector.TabIndex = 5;
            this.Method_Selector.Text = "B and W";
            this.Method_Selector.UseVisualStyleBackColor = true;
            this.Method_Selector.CheckStateChanged += new System.EventHandler(this.Method_Selector_CheckStateChanged);
            // 
            // Save_Button
            // 
            this.Save_Button.BackColor = System.Drawing.Color.White;
            this.Save_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Button.Font = new System.Drawing.Font("Montserrat Light", 14.25F);
            this.Save_Button.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Location = new System.Drawing.Point(166, 414);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(141, 46);
            this.Save_Button.TabIndex = 2;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = false;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // SizeModBox
            // 
            this.SizeModBox.DisplayMember = "3";
            this.SizeModBox.Font = new System.Drawing.Font("Montserrat Light", 8F);
            this.SizeModBox.FormattingEnabled = true;
            this.SizeModBox.Items.AddRange(new object[] {
            "Normal",
            "StretchImage",
            "CenterImage (Default)"});
            this.SizeModBox.Location = new System.Drawing.Point(335, 347);
            this.SizeModBox.Name = "SizeModBox";
            this.SizeModBox.Size = new System.Drawing.Size(153, 23);
            this.SizeModBox.TabIndex = 7;
            this.SizeModBox.Text = "CenterImage (Default)";
            this.SizeModBox.SelectedIndexChanged += new System.EventHandler(this.SizeModBox_SelectedIndexChanged);
            // 
            // LoadBox
            // 
            this.LoadBox.Image = ((System.Drawing.Image)(resources.GetObject("LoadBox.Image")));
            this.LoadBox.Location = new System.Drawing.Point(449, 414);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new System.Drawing.Size(46, 46);
            this.LoadBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadBox.TabIndex = 8;
            this.LoadBox.TabStop = false;
            // 
            // PerSentCouner
            // 
            this.PerSentCouner.AutoSize = true;
            this.PerSentCouner.Font = new System.Drawing.Font("Montserrat Light", 8F);
            this.PerSentCouner.Location = new System.Drawing.Point(12, 9);
            this.PerSentCouner.Name = "PerSentCouner";
            this.PerSentCouner.Size = new System.Drawing.Size(171, 15);
            this.PerSentCouner.TabIndex = 1;
            this.PerSentCouner.Text = "Number of rendered pixels : 0.";
            // 
            // PerSentTimer
            // 
            this.PerSentTimer.Enabled = true;
            this.PerSentTimer.Interval = 200;
            this.PerSentTimer.Tick += new System.EventHandler(this.PerSentTimer_Tick);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Montserrat Light", 8F);
            this.WidthLabel.Location = new System.Drawing.Point(298, 9);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(48, 15);
            this.WidthLabel.TabIndex = 9;
            this.WidthLabel.Text = "Width : ";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Montserrat Light", 8F);
            this.HeightLabel.Location = new System.Drawing.Point(405, 9);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(53, 15);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "Height : ";
            // 
            // PixelLable
            // 
            this.PixelLable.AutoSize = true;
            this.PixelLable.Font = new System.Drawing.Font("Montserrat Light", 8F);
            this.PixelLable.Location = new System.Drawing.Point(498, 9);
            this.PixelLable.Name = "PixelLable";
            this.PixelLable.Size = new System.Drawing.Size(78, 15);
            this.PixelLable.TabIndex = 11;
            this.PixelLable.Text = "Pixel Count : ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Enabled = false;
            this.ProgressBar.Location = new System.Drawing.Point(501, 392);
            this.ProgressBar.MarqueeAnimationSpeed = 1;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(141, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 482);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.PixelLable);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.PerSentCouner);
            this.Controls.Add(this.LoadBox);
            this.Controls.Add(this.SizeModBox);
            this.Controls.Add(this.Method_Selector);
            this.Controls.Add(this.Steps_Bar);
            this.Controls.Add(this.Dither);
            this.Controls.Add(this.Load_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Modified_Image_Plane);
            this.Controls.Add(this.Primordia_Image_Plane);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dither";
            this.Primordia_Image_Plane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Primordial_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Image)).EndInit();
            this.Modified_Image_Plane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Steps_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Primordia_Image_Plane;
        private System.Windows.Forms.PictureBox Modified_Image;
        private System.Windows.Forms.PictureBox Primordial_Image;
        private System.Windows.Forms.Panel Modified_Image_Plane;
        private System.Windows.Forms.Button Load_Button;
        private System.Windows.Forms.Button Dither;
        private System.Windows.Forms.TrackBar Steps_Bar;
        private System.Windows.Forms.CheckBox Method_Selector;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.ComboBox SizeModBox;
        private System.Windows.Forms.PictureBox LoadBox;
        private System.Windows.Forms.Label PerSentCouner;
        private System.Windows.Forms.Timer PerSentTimer;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label PixelLable;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}

