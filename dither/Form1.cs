using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dither
{
    public partial class Form1 : Form
    {
        private string _path = "standart.png";
        private bool _DoBW = true;
        private bool _dithering = false;
        private int _DoPer = 0;

        private Bitmap _primordialImage = new Bitmap("standart.png", true);
        private Bitmap _modifiedImage = new Bitmap("standart.png", true);

        public Form1()
        {
            InitializeComponent();

            LoadBox.Visible = false;

            Primordial_Image.Image = new Bitmap(_path, true);
            Modified_Image.Image = new Bitmap(_path, true);

            if (!Directory.Exists("Img"))
            {
                Directory.CreateDirectory("Img");
            }

            WidthLabel.Text = $"Width : {_modifiedImage.Width}px";
            HeightLabel.Text = $"Heigt : {_modifiedImage.Height}px";
            PixelLable.Text = $"Pixel Count : {_modifiedImage.Width * _modifiedImage.Height}px";
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
                _dithering = true;

                Thread thread = new Thread(
                    () => makeDithered(_modifiedImage, factor));
                thread.Start();
            }
            else
            {
                Debug.WriteLine("Проверку не прошёл!");
            }

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
            int x, y;

            Bitmap img = (Bitmap)img1.Clone();

            for (y = 0; y < img.Height; y++)
            {
                for (x = 0; x < img.Width; x++)
                {
                    var clr = img.GetPixel(x, y);
                    var oldR = clr.R;
                    var oldG = clr.G;
                    var oldB = clr.B;
                    var newR = closestStep(255, steps, oldR);
                    var newG = closestStep(255, steps, oldG);
                    var newB = closestStep(255, steps, oldB);

                    var newClr = Color.FromArgb((int)newR, (int)newG, (int)newB);
                    img.SetPixel(x, y, newClr);

                    var errR = oldR - newR;
                    var errG = oldG - newG;
                    var errB = oldB - newB;

                    distributeError(img, x, y, errR, errG, errB);
                    _DoPer += 1;
                }
                
            }


            if (!_DoBW)
            {
                for (x = 0; x < img.Width; x++)
                {
                    for (y = 0; y < img.Height; y++)
                    {
                        Color pixelColor = img.GetPixel(x, y);
                        var grayscaleColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        Color newColor = Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);

                        img.SetPixel(x, y, newColor);
                    }
                }
            }


            Modified_Image.Image = img;

            _dithering = false;
        }

        private void distributeError(Bitmap img, int x, int y, double errR, double errG, double errB)
        {
            addError(img, 7 / 16.0, x + 1, y, errR, errG, errB);
            addError(img, 3 / 16.0, x - 1, y + 1, errR, errG, errB);
            addError(img, 5 / 16.0, x, y + 1, errR, errG, errB);
            addError(img, 1 / 16.0, x + 1, y + 1, errR, errG, errB);
        }

        private void addError(Bitmap img, double factor, int x, int y, double errR, double errG, double errB)
        {
            if (x < 0 || x >= img.Width || y < 0 || y >= img.Height) return;
            var clr = img.GetPixel(x, y);
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

            img.SetPixel(x, y, newClr);
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
                //PerSentCouner.Visible = false;
            }
        }

        private void PerSentTimer_Tick(object sender, EventArgs e)
        {
            PerSentCouner.Text = $"Number of rendered pixels : {_DoPer}.";
        }
    }
}
