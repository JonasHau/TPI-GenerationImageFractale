using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerationImageFractale
{
    /// <summary>
    /// This abstract class represents a fractal
    /// </summary>
    public abstract class Fractal
    {
        //attributes
        private double xMin, xMax;
        private double yMin, yMax;

        //accessors
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }

        /// <summary>
        /// Is redefined for each fractal
        /// </summary>
        /// <returns>Never used, an empty bitmap</returns>
        public virtual Bitmap Render()
        {
            return null;
        }

        /// <summary>
        /// Converts a coordinate in the bitmap to a coordinate in the complex plane (based on the user configuration)
        /// </summary>
        /// <param name="bitmapX">x value in the bitmap</param>
        /// <param name="bitmapY">y value in the bitmap</param>
        /// <param name="width">width of the bitmap</param>
        /// <param name="height">height of the bitmap</param>
        /// <returns>The two converted coordinates in a list</returns>
        public List<double> ConvertLoopValuestoCoordinate(int bitmapX, int bitmapY, int width, int height)
        {
            List<double> complexCoordinate = new List<double>
            {
                //inspired from https://stackoverflow.com/a/51494556
                //x in [a,b] to y in [c,d] => y = (d-c) * (x-a) / (b-a) + c
                (XMax - XMin) * (bitmapX - 0) / (width - 0) + XMin,
                (YMax - YMin) * (bitmapY - 0) / (height - 0) + YMin
            };

            return complexCoordinate;
        }

        /// <summary>
        /// Check if the specified point is in the mandelbrot set
        /// </summary>
        /// <param name="z">z value</param>
        /// <param name="c">c value</param>
        /// <param name="limit">the maximum number of iterations</param>
        /// <param name="iter">the current number of iteration</param>
        /// <returns></returns>
        public bool IsPixelInTheSet(Complex z, Complex c, int limit, int iter = 0)
        {
            if (z.Magnitude > 2) { return false; }
            else if (iter == limit) { return true; }
            else
            {
                z = Complex.Add(Complex.Pow(z, 2), c);
                return IsPixelInTheSet(z, c, limit, iter + 1);
            }
        }
    }
}
