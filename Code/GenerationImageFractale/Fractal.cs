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
        private double xMin;
        private double xMax;
        private double yMin;
        private double yMax;

        //accessors
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }

        /// <summary>
        /// is redefined for each fractals
        /// </summary>
        /// <returns></returns>
        public virtual Bitmap Render()
        {
            //empty 16x16 bitmap
            return new Bitmap(500, 500); //empty bitmap
        }

        /// <summary>
        /// converts a coordinate in the bitmap to a coordinate in the complex plane
        /// </summary>
        /// <param name="bitmapX"></param>
        /// <param name="bitmapY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public List<double> ConvertBitmapPixeltoCoordinate(int bitmapX, int bitmapY, int width, int height)
        {
            List<double> complexCoordinate = new List<double>();

            //taken from https://stackoverflow.com/a/51494556
            //x in [a,b] => z = (d-c) * (x-a) / (b-a) + c in [c,d]
            complexCoordinate.Add((XMax - XMin) * (bitmapX - 0) / (width - 0) + XMin); //x coordinate
            complexCoordinate.Add((YMax - YMin) * (bitmapY - 0) / (height - 0) + YMin);

            return complexCoordinate;
        }
    }
}
