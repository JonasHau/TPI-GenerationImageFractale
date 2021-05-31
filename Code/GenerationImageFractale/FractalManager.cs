using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace GenerationImageFractale
{
    /// <summary>
    /// This class manages fractals
    /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selectedFractal">the index of the fractal selected</param>
        /// <param name="xMin">x min</param>
        /// <param name="xMax">x max</param>
        /// <param name="yMin">y min</param>
        /// <param name="yMax">y max</param>
        /// <param name="cReal">c real</param>
        /// <param name="cImaginary">c imaginary</param>
        public FractalManager(int selectedFractal, string xMin, string xMax, string yMin, string yMax, string cReal, string cImaginary)
        {
            this.SelectedFractal = selectedFractal;
            this.XMin =             xMin;
            this.XMax =             xMax;
            this.YMin =             yMin;
            this.YMax =             yMax;
            this.CReal =            cReal;
            this.CImaginary =       cImaginary;
        }

        /// <summary>
        /// Generates the fractal according to the user configuration
        /// </summary>
        /// <returns>The fractal rendered in a bitmap</returns>
        public Bitmap GenerateFractal(bool fromHistory)
        {
            //tries parsing the boundaries
            double xMin, xMax, yMin, yMax;
            Expression expression = new Expression();

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

            //declares variables related to the fractal
            Fractal fractal;
            Bitmap bitmap;

            //renders the selected fractal
            if (SelectedFractal == 0)
            {
                //instantiates the fractal
                fractal = new Mandelbrot(xMin, xMax, yMin, yMax);

                //adds the fractal to the history if necessary
                if (!fromHistory) { QueryBuilder.SaveFractal(SelectedFractal, xMin, xMax, yMin, yMax); }
            }
            else if (SelectedFractal == 1)
            {
                //tries parsing the complex constant c
                double cReal, cImaginary;

                expression.setExpressionString(CReal);
                if (!expression.checkSyntax()) { throw new InvalidCRealException(); }
                cReal = expression.calculate();

                expression.setExpressionString(CImaginary);
                if (!expression.checkSyntax()) { throw new InvalidCImaginaryException(); }
                cImaginary = expression.calculate();

                //instantiates the fractal
                fractal = new Julia(xMin, xMax, yMin, yMax, cReal, cImaginary);
                
                //adds the fractal to the history if necessary
                if (!fromHistory) { QueryBuilder.SaveFractal(SelectedFractal, xMin, xMax, yMin, yMax, cReal, cImaginary); }
            }
            else
            {
                throw new InvalidFractalException();
            }

            //renders the fractal
            bitmap = fractal.Render();

            return bitmap;
        }
    }
}
