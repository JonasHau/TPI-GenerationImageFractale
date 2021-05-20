using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerationImageFractale
{
    /// <summary>
    /// This class builds query
    /// </summary>
    public class QueryBuilder
    {
        /// <summary>
        /// Gets the history
        /// </summary>
        /// <returns>an array of fractals</returns>
        public static ToolStripItem[] GetHistory()
        {
            //prepare the list of ToolStripItems
            string query = @"SELECT [indexFractal], [xMin], [xMax], [yMin], [yMax], [cReal], [cImaginary] FROM [Fractals] ORDER BY [id] DESC LIMIT 10";
            List<List<string>> fractals = QueryExecutor.Select(query);
            ToolStripItem[] history = new ToolStripItem[fractals.Count()];
            string entryText;

            //feed them with the data
            for (int i = 0; i < fractals.Count(); i++)
            {
                //prepare the text
                if (fractals[i][0] == "0") //mandelbrot
                {
                    entryText = "Type: Mandelbrot\r";
                    entryText += "x: " + fractals[i][1] + " à " + fractals[i][2] + "\r";
                    entryText += "y: " + fractals[i][3] + " à " + fractals[i][4];
                }
                else //julia
                {
                    entryText = "Type: Julia\r";
                    entryText += "x: " + fractals[i][1] + " à " + fractals[i][2] + "\r";
                    entryText += "y: " + fractals[i][3] + " à " + fractals[i][4] + "\r";
                    entryText += "c: " + fractals[i][5] + " + " + fractals[i][6] + "i";
                }

                //create and fill the ToolStripMenuItem
                history[i] = new ToolStripMenuItem
                {
                    Text = entryText,
                    Tag = fractals[i]
                };
            }

            return history;
        }

        /// <summary>
        /// Saves a fractal in history
        /// </summary>
        /// <param name="indexFractal">the index of the selected fractal</param>
        /// <param name="xMin">x min</param>
        /// <param name="xMax">x max</param>
        /// <param name="yMin">y min</param>
        /// <param name="yMax">y max</param>
        /// <param name="cReal">c real, can be omitted</param>
        /// <param name="cImaginary">c imaginary, can be omitted</param>
        public static void SaveFractal(int indexFractal, double xMin, double xMax, double yMin, double yMax, double cReal = 0, double cImaginary = 0)
        {
            string query;

            switch (indexFractal)
            {
                case 0: //Mandelbrot
                case 1: //Julia
                    query = "INSERT INTO Fractals(indexFractal, xMin, xMax, yMin, yMax, cReal, cImaginary) values (\'" + indexFractal + "\', \'" + xMin + "\', \'" + xMax + "\', \'" + yMin + "\', \'" + yMax + "\', \'" + cReal + "\', \'" + cImaginary + "\')";
                    break;
                default:
                    throw new InvalidFractalException();
            }
            
            QueryExecutor.Insert(query);
        }
    }
}
