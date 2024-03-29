﻿using FastBitmapLib;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace dither
{
    public partial class Form1 : Form
    {
        private string _path = "standart.png";
        private bool _DoBW = true;
        private bool _dithering = false;
        private int _DoPer = 0;
        private double _progress = 0;

        private Bitmap _primordialImage = new Bitmap("standart.png", true);
        private Bitmap _modifiedImage = new Bitmap("standart.png", true);

        private FastBitmap fastBitmap;

        public Form1()
        {
            InitializeComponent();

            Start();
        }

        private void Start()
        {
            LoadBox.Visible = false;
            ProgressBar.Visible = false;

            Primordial_Image.Image = new Bitmap(_path, true);
            Modified_Image.Image = new Bitmap(_path, true);

            if (!Directory.Exists("Img"))
            {
                Directory.CreateDirectory("Img");
            }

            WidthLabel.Text = $"Width : {_modifiedImage.Width}px";
            HeightLabel.Text = $"Heigt : {_modifiedImage.Height}px";
            PixelLable.Text = $"Pixel Count : {_modifiedImage.Width * _modifiedImage.Height}px";
            ProgressBar.Maximum = _modifiedImage.Width * _modifiedImage.Height;
        }

        private void Dither_Click(object sender, EventArgs e)
        {
            _DoPer = 0;
            PerSentCouner.Visible = true;



            Debug.WriteLine("Считал нажатие на кнопку!");
            _modifiedImage = new Bitmap(_path, true);



            var factor = Steps_Bar.Value;

            if (!_dithering)
            {
                Debug.WriteLine("Проверку прошёл!");

                LoadBox.Visible = true;
                ProgressBar.Visible = true;

                _dithering = true;

                Thread thread = new Thread(
                    () => makeDithered(_modifiedImage, factor));
                thread.Start();
            }
            else
            {
                Debug.WriteLine("Проверку не прошёл!");
            }

            _dithering = false;
            LoadBox.Visible = false;
            ProgressBar.Visible = false;

            /*
            Thread thread = new Thread(
        () => makeDithered(_modifiedImage, factor));
            thread.Start(); */
            //_DoBW



            //Modified_Image.Image = _modifiedImage;
        }

        private double closestStep(int max, int steps, int value)
        {
            return Math.Round((steps * value) / 255 * Math.Floor(255 / (double)steps));
        }

        private void makeDithered(Bitmap img1, int steps)
        {
            _DoPer = 0;
            _progress = 0;
            int x, y;


            Bitmap img = (Bitmap)img1.Clone();
            
            FastBitmap fastBitmap;

            Bitmap orig = (Bitmap)img.Clone();
            Bitmap clone = new Bitmap(orig.Width, orig.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using (Graphics gr = Graphics.FromImage(clone))
            {
                gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
            }

            img = (Bitmap)clone.Clone();

            try
            {
                fastBitmap = new FastBitmap(img);
            }
            catch
            {
                string message = "The provided bitmap must have a 32bpp depth.";
                string title = "Error";
                MessageBox.Show(message, title);
                return;
            }
            

            fastBitmap.Lock();


            for (y = 0; y < fastBitmap.Height; y++)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    var clr = fastBitmap.GetPixel(x, y);
                    var oldR = clr.R;
                    var oldG = clr.G;
                    var oldB = clr.B;
                    var newR = closestStep(255, steps, oldR);
                    var newG = closestStep(255, steps, oldG);
                    var newB = closestStep(255, steps, oldB);

                    var newClr = Color.FromArgb((int)newR, (int)newG, (int)newB);
                    fastBitmap.SetPixel(x, y, newClr);

                    var errR = oldR - newR;
                    var errG = oldG - newG;
                    var errB = oldB - newB;

                    distributeError(fastBitmap, x, y, errR, errG, errB);
                    _DoPer += 1;
                    _progress += 1;
                }
                
            }


            if (!_DoBW)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    for (y = 0; y < fastBitmap.Height; y++)
                    {
                        Color pixelColor = fastBitmap.GetPixel(x, y);
                        var grayscaleColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        Color newColor = Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);

                        fastBitmap.SetPixel(x, y, newColor);
                    }
                }
            }

            fastBitmap.Unlock();

            Modified_Image.Image = img;

            _dithering = false;
        }

        private void distributeError(FastBitmap fastBitmap, int x, int y, double errR, double errG, double errB)
        {
            addError(fastBitmap, 7 / 16.0, x + 1, y, errR, errG, errB);
            addError(fastBitmap, 3 / 16.0, x - 1, y + 1, errR, errG, errB);
            addError(fastBitmap, 5 / 16.0, x, y + 1, errR, errG, errB);
            addError(fastBitmap, 1 / 16.0, x + 1, y + 1, errR, errG, errB);
        }

        private void addError(FastBitmap fastBitmap, double factor, int x, int y, double errR, double errG, double errB)
        {
            if (x < 0 || x >= fastBitmap.Width || y < 0 || y >= fastBitmap.Height) return;
            var clr = fastBitmap.GetPixel(x, y);
            var r = clr.R;
            var g = clr.G;
            var b = clr.B;

            int Red = (int)(r + errR * factor);
            int Green = (int)(g + (errG * factor));
            int Blue = (int)(b + errB * factor);

            if (Red > 255)
            {
                Red = 255;
            }
            if (Green > 255)
            {
                Green = 255;
            }
            if (Blue > 255)
            {
                Blue = 255;
            }

            var newClr = Color.FromArgb(Red, Green, Blue);

            fastBitmap.SetPixel(x, y, newClr);
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            Primordial_Image.Image = new Bitmap(_path, true);
            Modified_Image.Image = new Bitmap(_path, true);

            var OPF = new OpenFileDialog();
            OPF.Filter = "Файлы .png|*.png|Файлы .jpg|*.jpg";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                _path = OPF.FileName;
                _modifiedImage = new Bitmap(_path, true);
                _primordialImage = new Bitmap(_path, true);
                Primordial_Image.Image = _primordialImage;
                Modified_Image.Image = _modifiedImage;//центр стреч нормал

                WidthLabel.Text = $"Width : {_modifiedImage.Width}px";
                HeightLabel.Text = $"Heigt : {_modifiedImage.Height}px";
                PixelLable.Text = $"Pixel Count : {_modifiedImage.Width * _modifiedImage.Height}px";
                ProgressBar.Maximum = _modifiedImage.Width * _modifiedImage.Height;
            }
            else
            {
                OPF.Dispose();
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            var standartFilePath = $"{Directory.GetCurrentDirectory()}/Img/PostImage.jpg";

            try{
                Modified_Image.Image.Save(standartFilePath);
            }
            catch
            {

            }
            MessageBox.Show($"Image saved in {standartFilePath}");
        }

        private void Method_Selector_CheckStateChanged(object sender, EventArgs e)
        {
            if (Method_Selector.Checked)
            {
                _DoBW = false;
            }
            else
            {
                _DoBW = true;
            }
        }

        private void SizeModBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SizeModBox.SelectedIndex)
            {
                case 0:
                    {
                        Primordial_Image.SizeMode = PictureBoxSizeMode.Normal;
                        Modified_Image.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                    }
                case 1:
                    {
                        Primordial_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                        Modified_Image.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    }
                case 2:
                    {
                        Primordial_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                        Modified_Image.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                    }
            }
        }

        private void Modified_Image_OnPaint(object sender, PaintEventArgs e)
        {
            if (!_dithering)
            {
                LoadBox.Visible = false;
                ProgressBar.Visible = false;
                //PerSentCouner.Visible = false;
            }
        }

        private void PerSentTimer_Tick(object sender, EventArgs e)
        {
            PerSentCouner.Text = $"Number of rendered pixels : {_DoPer}.";
            ProgressBar.Maximum = Primordial_Image.Image.Width * Primordial_Image.Image.Height;
            try
            {
                ProgressBar.Value = _DoPer;
            }
            catch
            {
                Debug.WriteLine($"Do per - {_DoPer}");
                Debug.WriteLine($"Max - {ProgressBar.Maximum}");
                Debug.WriteLine($"All - {Primordial_Image.Image.Width * Primordial_Image.Image.Height}");
            }
        }
    }
}
