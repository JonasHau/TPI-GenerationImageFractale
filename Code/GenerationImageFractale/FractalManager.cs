using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace GenerationImageFractale
{
    public class FractalManager
    {
        //attributes
        private string xMin, xMax;
        private string yMin, yMax;
        private string cReal, cImaginary;
        private int selectedFractal;

        //accessors
        public string XMin { get; set; }
        public string XMax { get; set; }
        public string YMin { get; set; }
        public string YMax { get; set; }
        public string CReal { get; set; }
        public string CImaginary { get; set; }
        public int SelectedFractal { get; set; }

        //constructor
        public FractalManager(string xMin, string xMax, string yMin, string yMax, string cReal, string cImaginary, int selectedFractal)
        {
            this.XMin =             xMin;
            this.XMax =             xMax;
            this.YMin =             yMin;
            this.YMax =             yMax;
            this.CReal =            cReal;
            this.CImaginary =       cImaginary;
            this.SelectedFractal =  selectedFractal;
        }

        /// <summary>
        /// Generates the fractal according to the user configuration
        /// </summary>
        /// <returns>The fractal rendered in a bitmap</returns>
        public Bitmap GenerateFractal()
        {
            //try parsing the boundaries
            double xMin, xMax, yMin, yMax;
            Expression expression = new Expression();

            //check the boundaries
            expression.setExpressionString(XMin);
            if (!expression.checkSyntax()) { throw new InvalidXMinException(); }
            xMin = expression.calculate();

            expression.setExpressionString(XMax);
            if (!expression.checkSyntax()) { throw new InvalidXMaxException(); }
            xMax = expression.calculate();

            expression.setExpressionString(YMin);
            if (!expression.checkSyntax()) { throw new InvalidYMinException(); }
            yMin = expression.calculate();

            expression.setExpressionString(YMax);
            if (!expression.checkSyntax()) { throw new InvalidYMaxException(); }
            yMax = expression.calculate();

            //render the selected fractal
            if (SelectedFractal == 0)
            {
                Fractal fractal = new Mandelbrot(xMin, xMax, yMin, yMax);
                return fractal.Render();
            }
            /*
            else if (SelectedFractal == 1)
            {
                //try to parse c parameters

                fractal = new Julia(xMin, xMax, yMin, yMax, cReal, cImaginary);
                return fractal.Render();
            }*/
            else
            {
                throw new InvalidFractalException();
            }
        }

        public void SaveFractal()
        {

        }
    }
}
