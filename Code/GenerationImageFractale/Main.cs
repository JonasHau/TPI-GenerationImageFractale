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

            //default values
            txtXMin.Text = "-2";
            txtXMax.Text = "2";
            txtYMin.Text = "-2";
            txtYMax.Text = "2";
            cboFractal.SelectedIndex = 0;
        }

        private void GenerateFractal(object sender, EventArgs e)
        {
            //parser needs to be used here
            double xMin, xMax, yMin, yMax;
            xMin = Double.Parse(txtXMin.Text);
            xMax = Double.Parse(txtXMax.Text);
            yMin = Double.Parse(txtYMin.Text);
            yMax = Double.Parse(txtYMax.Text);

            Fractal fractal = new Mandelbrot(xMin, xMax, yMin, yMax);
            picCanvas.Image = fractal.Render();
        }
    }
}
