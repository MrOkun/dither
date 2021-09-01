using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dither
{
    public partial class Form1 : Form
    {
        private string _path = "0.png";
        private bool _DoBW = true;

        private Bitmap _primordialImage;
        private Bitmap _modifiedImage;

        public Form1()
        {
            InitializeComponent();

            Primordial_Image.Image = new Bitmap(_path, true);
            Modified_Image.Image = new Bitmap(_path, true);
        }



        private Bitmap ImageRender(Bitmap Img)
        {


            return Img;
        }

        private void Dither_Click(object sender, EventArgs e)
        {
            _modifiedImage = new Bitmap(_path, true);

            makeDithered(_modifiedImage, Steps_Bar.Value);
            //_DoBW

            if (!_DoBW)
            {
                int x, y;

                for (x = 0; x < _modifiedImage.Width; x++)
                {
                    for (y = 0; y < _modifiedImage.Height; y++)
                    {
                        Color pixelColor1 = _modifiedImage.GetPixel(x, y);

                        int grayscaleColor = (pixelColor1.R + pixelColor1.G + pixelColor1.B) / 3;

                        Color newColor = Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);
                        _modifiedImage.SetPixel(x, y, newColor);
                    }
                }
            }

            Modified_Image.Image = _modifiedImage;
        }

        private double closestStep(int max, int steps, int value)
        {
            return Math.Round((steps * value) /255 * Math.Floor(255 / (double)steps));
        }

        private void makeDithered(Bitmap img, int steps)
        {
            for (var y = 0; y < img.Height; y++)
            {
                for (var x = 0; x < img.Width; x++)
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
                }
            }
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
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {

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
    }
}
