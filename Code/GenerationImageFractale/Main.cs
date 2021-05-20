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
    /// <summary>
    /// The main form
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Form constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();

            //initializes default values
            txtXMin.Text = "-2";
            txtXMax.Text = "2";
            txtYMin.Text = "-2";
            txtYMax.Text = "2";
            txtCReal.Text = "-0.12";
            txtCImaginary.Text = "0.75";
            lblGenerationTime.Text = "";
            cboFractal.SelectedIndex = 0;
            picCanvas.BackColor = Color.White;

            //configures the tooltip 
            ToolTip help = new ToolTip();
            help.AutoPopDelay = 10000;
            help.InitialDelay = 1000;
            help.UseFading = true;

            //adds the tooltip to every component tht might be confusing
            help.SetToolTip(this.lblXMin,           "Borne minimale (à gauche) dans l'axe des x");
            help.SetToolTip(this.lblXMax,           "Borne maximale (à droite) dans l'axe des x");
            help.SetToolTip(this.lblYMin,           "Borne minimale (en bas) dans l'axe des y");
            help.SetToolTip(this.lblYMax,           "Borne maximale (en haut) dans l'axe des y");
            help.SetToolTip(this.lblCReal,          "Composante réelle de c");
            help.SetToolTip(this.lblCImaginary,     "Composante imaginaire de c");
            help.SetToolTip(this.lblGenerationTime, "Temps de génération de l'image");
            help.SetToolTip(this.cboFractal,        "Fractale que vous souhaitez générer");
            help.SetToolTip(this.picCanvas,         "Cliquez sur l'image pour la sauvegarder...");
            help.SetToolTip(this.btnGenerate,       "Cliquez sur ce bouton pour générer la fractale");

            //creates database if it doesn't exist
            DatabaseConnector.OpenDatabase();

            //reloads history
            LoadHistory();
        }

        /// <summary>
        /// Prints a fractal according to the user's configuration
        /// </summary>
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
                FractalManager fractal = new FractalManager(selectedFractal, xMin, xMax, yMin, yMax, cReal, cImaginary);
                picCanvas.Image = fractal.GenerateFractal(false);

                //end chronometer
                chrono.Stop();
                string chronoString = (chrono.ElapsedMilliseconds / 1000).ToString() + "." + (chrono.ElapsedMilliseconds % 1000).ToString() + " seconde(s)";
                lblGenerationTime.Text = chronoString;
            }
            catch (Exception exception)
            {
                //render an empty bitmap
                picCanvas.Image = null;

                //end chronometer
                chrono.Stop();
                lblGenerationTime.Text = "";
                
                //print error
                MessageBox.Show(exception.Message);
            }

            //resets the cursor
            Cursor.Current = Cursors.Default;

            //reloads history
            LoadHistory();
        }

        /// <summary>
        /// Saves the fractal to a png
        /// </summary>
        private void ExportFractalToPng(object sender, EventArgs e)
        {
            //filename default format : "Year-Month-Day HourhMinute"
            string filename = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + "h" + DateTime.Now.Minute;

            //save bitmap with save file dialog
            Image bitmap = picCanvas.Image;
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Images|*.png",
                FileName = filename
            };

            //make sure that a bitmap has been generated
            if (bitmap != null)
            {
                //open the dialog and save if the user confirms
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }

        /// <summary>
        /// Loads the history
        /// </summary>
        private void LoadHistory()
        {
            ToolStripItem[] history = QueryBuilder.GetHistory();
            
            foreach(ToolStripItem entry in history)
            {
                entry.Click += new EventHandler(PrintFractalFromHistory);
            }

            toolStrHistory.DropDownItems.Clear();
            toolStrHistory.DropDownItems.AddRange(history);
        }

        /// <summary>
        /// Generates a fractal from history
        /// </summary>
        public void PrintFractalFromHistory(object sender, EventArgs e)
        {
            //create and start chronometer
            var chrono = new System.Diagnostics.Stopwatch();
            chrono.Start();

            //stores entry values in the tag
            ToolStripMenuItem entry = sender as ToolStripMenuItem;
            List<string> fractalParams = entry.Tag as List<string>;

            try
            {
                //set the cursor as the loading cursor
                Cursor.Current = Cursors.WaitCursor;

                //create and render fractal
                FractalManager fractal = new FractalManager(int.Parse(fractalParams[0]), fractalParams[1], fractalParams[2], fractalParams[3], fractalParams[4], fractalParams[5], fractalParams[6]);
                picCanvas.Image = fractal.GenerateFractal(true);

                //end chronometer
                chrono.Stop();
                string chronoString = (chrono.ElapsedMilliseconds / 1000).ToString() + "." + (chrono.ElapsedMilliseconds % 1000).ToString() + " seconde(s)";
                lblGenerationTime.Text = chronoString;
            }
            catch (Exception exception)
            {
                //render an empty bitmap
                picCanvas.Image = null;

                //end chronometer
                chrono.Stop();
                lblGenerationTime.Text = "";

                //print error
                MessageBox.Show(exception.Message);
            }

            //resets the cursor
            Cursor.Current = Cursors.Default;

            //reloads history
            LoadHistory();
        }

        /// <summary>
        /// Runs everytime the selected fractal changes
        /// </summary>
        private void SelectedFractalChanged(object sender, EventArgs e)
        {
            bool IsFractalJulia = cboFractal.SelectedIndex == 1 ? true : false;

            //changes the visibility of controls based on the fractal selected
            lblCReal.Visible = IsFractalJulia;
            txtCReal.Visible = IsFractalJulia;
            lblCImaginary.Visible = IsFractalJulia;
            txtCImaginary.Visible = IsFractalJulia;
        }

        /// <summary>
        /// Opens the help window
        /// </summary>
        private void OpenHelpForm(object sender, EventArgs e)
        {
            //todo
        }
    }
}
