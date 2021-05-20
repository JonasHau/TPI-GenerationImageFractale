using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenerationImageFractale
{
    /// <summary>
    /// This class represents a Mandelbrot fractal
    /// </summary>
    public class Mandelbrot : Fractal
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xMin">x min</param>
        /// <param name="xMax">x max</param>
        /// <param name="yMin">y min</param>
        /// <param name="yMax">y max</param>
        public Mandelbrot(double xMin, double xMax, double yMin, double yMax)
        {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }

        /// <summary>
        /// Render the fractal
        /// </summary>
        /// <returns>a bitmap of the fractal</returns>
        public override Bitmap Render()
        {
            //canvas related variables
            int canvasWidth = 500;
            int canvasHeight = 500;
            Bitmap canvas = new Bitmap(canvasWidth, canvasHeight);

            //fractal related variables
            Complex c;
            List<double> complexCoordinate;
            int iterationLimit = 150;

            //horizontal loop
            for (int i = 0; i < canvasWidth; i++)
            {
                //vertical loop
                for (int j = 0; j < canvasHeight; j++)
                {
                    //convert the values of the loop to coordinates on the canvas
                    complexCoordinate = ConvertLoopValuestoCoordinate(i, j, canvasWidth, canvasHeight);
                    c = new Complex(complexCoordinate[0], complexCoordinate[1]);

                    //color the pixels that are in the mandelbrot set
                    if (IsPixelInTheSet(new Complex(0, 0), c, iterationLimit))
                    {
                        canvas.SetPixel(i, Math.Abs(j - (canvasHeight - 1)), Color.Black);
                    }
                }
            }

            return canvas;
        }
    }
}
