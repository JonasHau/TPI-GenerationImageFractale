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
    public class Julia : Fractal
    {
        //attributes
        private double cReal, cImaginary;

        //accessors
        public double CReal { get; set; }
        public double CImaginary { get; set; }

        //constructor
        public Julia(double xMin, double xMax, double yMin, double yMax, double cReal, double cImaginary)
        {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
            this.CReal = cReal;
            this.CImaginary = cImaginary;
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
            c = new Complex(CReal, CImaginary);
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
                    z = new Complex(complexCoordinate[0], complexCoordinate[1]);

                    //color the pixels that are in the julia set
                    if (IsPixelInTheSet(z, c, iterationLimit))
                    {
                        canvas.SetPixel(i, Math.Abs(j - (canvasHeight - 1)), Color.Black);
                    }
                }
            }

            return canvas;
        }
    }
}
