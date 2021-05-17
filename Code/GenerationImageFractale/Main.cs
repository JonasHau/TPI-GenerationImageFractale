using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            picCanvas.BackColor = Color.White;

            //creates database if it doesn't exist
            DatabaseConnector.OpenDatabase();
        }

        /// <summary>
        /// Prints a fractal according to the user's configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintFractal(object sender, EventArgs e)
        {
            //create and start chronometer
            var chrono = new System.Diagnostics.Stopwatch();
            chrono.Start();

            //stores the values in the form
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
                picCanvas.Image = null;

                //end chronometer
                chrono.Stop();
                txtGenerationTime.Text = "";
                
                //print error
                MessageBox.Show(exception.Message);
            }

            //resets the cursor
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Save the fractal to a png
        /// </summary>
        private void SaveFractal(object sender, EventArgs e)
        {
            //filename default format : "Year-Month-Day HourhMinute"
            string filename = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " "
                + DateTime.Now.Hour + "h" + DateTime.Now.Minute;

            //save bitmap with save file dialog
            Image bitmap = picCanvas.Image;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Images|*.png";
            dialog.FileName = filename;

            //make sure that a bitmap has been generated
            if(bitmap != null)
            {
                //open the dialog and save if the user confirms
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }
    }
}
