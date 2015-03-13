using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace str_recognition.ImageProcessing
{
    public static class ImageUtility
    {
        /// <summary>
        /// Converts an abitarary bitmap to grayscale
        /// My sincere thanks to the site:
        /// http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
        /// </summary>
        /// <param name="original">Original bitmap</param>
        /// <returns></returns>
        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        /// <summary>
        /// For grayscale images only
        /// </summary>
        /// <param name="Dispersion"></param>
        /// <param name="bitmap"></param>
        public static void AddGreyscaleGaussianNoise(double Dispersion, Bitmap bitmap)
        {
            var random = new Random();
            for (int j = 0; j < bitmap.Width; j++)
            {
                for (int i = 0; i < bitmap.Height; i++)
                {
                    //Polar Method,  A First Course on Probability by S. M. Ross
                    //lookup here: http://www.dspguru.com/dsp/howtos/how-to-generate-white-gaussian-noise
                    double u1, u2, v1, v2, s, x;
                    do
                    {
                        u1 = random.NextDouble();
                        u2 = random.NextDouble();
                        v1 = 2 * u1 - 1;
                        v2 = 2 * u2 - 1;
                        s = v1 * v1 + v2 * v2;
                    }
                    while (s >= 1);
                    x = Math.Sqrt(-2 * Math.Log(s) / s) * v1;
                    int noise = (int)(Dispersion * x);
                    //fit it into type constraints
                    int r = bitmap.GetPixel(j,i).R + noise;
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    bitmap.SetPixel(j, i, Color.FromArgb(r, r, r));
                }
            }
        }
    }
}
