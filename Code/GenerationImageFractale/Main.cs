using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerationImageFractale
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //initializes default values
            txtXMin.Text = "-2";
            txtXMax.Text = "2";
            txtYMin.Text = "-2";
            txtYMax.Text = "2";
            txtGenerationTime.Text = "";
            cboFractal.SelectedIndex = 0;
        }

        private void GenerateFractal(object sender, EventArgs e)
        {
            //create and start chronometer
            var chrono = new System.Diagnostics.Stopwatch();
            chrono.Start();

            //parser needs to be used here -> check if everything is correct
            string xMin, xMax, yMin, yMax, cReal, cImaginary;
            xMin = txtXMin.Text;
            xMax = txtXMax.Text;
            yMin = txtYMin.Text;
            yMax = txtYMax.Text;
            cReal = txtCReal.Text;
            cImaginary = txtCImaginary.Text;
            int selectedFractal = cboFractal.SelectedIndex;

            try
            {
                //set the cursor as the loading cursor
                Cursor.Current = Cursors.WaitCursor;

                //create and render fractal
                FractalManager fractal = new FractalManager(xMin, xMax, yMin, yMax, cReal, cImaginary, selectedFractal);
                picCanvas.Image = fractal.GenerateFractal();

                //end chronometer
                chrono.Stop();
                string chronoString = (chrono.ElapsedMilliseconds / 1000).ToString() + "." + (chrono.ElapsedMilliseconds % 1000).ToString() + " seconde(s)";
                txtGenerationTime.Text = chronoString;
            }
            catch (Exception exception)
            {
                //render an empty bitmap
                picCanvas.Image = new Bitmap(500, 500);

                //end chronometer
                chrono.Stop();
                txtGenerationTime.Text = "";
                
                //print error
                MessageBox.Show(exception.Message);
            }

            //resets the cursor
            Cursor.Current = Cursors.Default;
        }

        private void SaveFractal(object sender, EventArgs e)
        {

        }
    }
}
