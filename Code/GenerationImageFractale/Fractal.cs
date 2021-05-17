using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerationImageFractale
{
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
        /// Converts a coordinate in the bitmap to a coordinate in the complex plane (based on the user configuration
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
    }
}
