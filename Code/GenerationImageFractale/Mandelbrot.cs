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
    public class Mandelbrot : Fractal
    {
        //constructor
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
            Complex z, c;
            z = new Complex(0, 0);
            List<double> complexCoordinate;
            int iterationLimit = 50;

            //horizontal loop
            for (int i = 0; i < canvasWidth; i++) {

                //vertical loop
                for(int j = 0; j < canvasHeight; j++) {
                    
                    //convert the values of the loop to coordinates on the canvas
                    complexCoordinate = ConvertLoopValuestoCoordinate(i, j, canvasWidth, canvasHeight);
                    c = new Complex(complexCoordinate[0], complexCoordinate[1]);

                    //color the pixels that are in the mandelbrot set
                    if (IsPixelInTheMandelbrotSet(z, c, iterationLimit))
                    {
                        canvas.SetPixel(i, Math.Abs(j - (canvasHeight-1)), Color.Black);
                    }
                }
            }

            return canvas;
        }

        /// <summary>
        /// Check if the specified point is in the mandelbrot set
        /// </summary>
        /// <param name="z"></param>
        /// <param name="c"></param>
        /// <param name="limit">the maximum number of iterations</param>
        /// <param name="iter">the current number of iteration</param>
        /// <returns></returns>
        bool IsPixelInTheMandelbrotSet(Complex z, Complex c, int limit, int iter = 0)
        {
            if(z.Magnitude > 2) { return false; }
            else if(iter == limit) { return true; }
            else
            {
                z = Complex.Add(Complex.Pow(z, 2), c);
                return IsPixelInTheMandelbrotSet(z, c, limit, iter + 1);
            }
        }
    }
}
