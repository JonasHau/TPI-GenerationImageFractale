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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        public Mandelbrot(double xMin, double xMax, double yMin, double yMax)
        {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }

        /// <summary>
        /// renders the fractal
        /// </summary>
        /// <returns>a bitmap picture</returns>
        public override Bitmap Render()
        {
            int canvasWidth = 500;
            int canvasHeight = 500;
            double yLength = Math.Abs(YMin - YMax);

            int iterationLimit = 15;

            Complex z = new Complex(0, 0); //useless ??
            Complex c = new Complex(0, 0);
            double xCoordinate, yCoordinate;
            List<double> complexCoordinate;

            Bitmap canvas = new Bitmap(canvasWidth, canvasHeight);

            /* multithreading generates error because multiple threads tries to access canvas
            //horizontal loop
            Parallel.For(0, canvasWidth, i =>
            {
                //vertical loop
                Parallel.For(0, canvasHeight, j =>
                {
            */

            //horizontal loop
            for(int i = 0; i < canvasWidth; i++) {
                //vertical loop
                for(int j = 0; j < canvasHeight; j++) {
                    
                    //converts the values of the loop to the coordinates based on the configuration
                    complexCoordinate = ConvertBitmapPixeltoCoordinate(i, j, canvasWidth, canvasHeight);
                    xCoordinate = complexCoordinate[0];
                    yCoordinate = complexCoordinate[1];

                    c = new Complex(xCoordinate, yCoordinate);

                    //colors the pixels that are in the mandelbrot set
                    if (IsPixelInTheMandelbrotSet(z, c, iterationLimit))
                    {
                        canvas.SetPixel(i, Math.Abs(j - (canvasHeight-1)), Color.Black);    //BUGFIXES TODO -> OutOfRangeException
                    }
                }
            }

            /*
                });
            });*/

            return canvas;
        }

        /// <summary>
        /// check if the specified point is in the mandelbrot set
        /// </summary>
        /// <param name="z"></param>
        /// <param name="c"></param>
        /// <param name="limit"></param>
        /// <param name="iter"></param>
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
