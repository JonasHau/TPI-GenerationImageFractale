namespace GenerationImageFractale
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStr = new System.Windows.Forms.ToolStrip();
            this.toolStrHistorique = new System.Windows.Forms.ToolStripDropDownButton();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.lblXMin = new System.Windows.Forms.Label();
            this.lblXMax = new System.Windows.Forms.Label();
            this.lblYMin = new System.Windows.Forms.Label();
            this.lblYMax = new System.Windows.Forms.Label();
            this.lblCReal = new System.Windows.Forms.Label();
            this.lblCImaginary = new System.Windows.Forms.Label();
            this.cboFractal = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.txtYMax = new System.Windows.Forms.TextBox();
            this.txtCReal = new System.Windows.Forms.TextBox();
            this.txtCImaginary = new System.Windows.Forms.TextBox();
            this.txtGenerationTime = new System.Windows.Forms.Label();
            this.toolStr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStr
            // 
            this.toolStr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrHistorique});
            this.toolStr.Location = new System.Drawing.Point(0, 0);
            this.toolStr.Name = "toolStr";
            this.toolStr.Size = new System.Drawing.Size(524, 25);
            this.toolStr.TabIndex = 0;
            this.toolStr.Text = "toolStr";
            // 
            // toolStrHistorique
            // 
            this.toolStrHistorique.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrHistorique.Image = ((System.Drawing.Image)(resources.GetObject("toolStrHistorique.Image")));
            this.toolStrHistorique.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrHistorique.Name = "toolStrHistorique";
            this.toolStrHistorique.Size = new System.Drawing.Size(75, 22);
            this.toolStrHistorique.Text = "Historique";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(12, 28);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(500, 500);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.ExportFractalToPng);
            // 
            // lblXMin
            // 
            this.lblXMin.AutoSize = true;
            this.lblXMin.Location = new System.Drawing.Point(12, 540);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(37, 13);
            this.lblXMin.TabIndex = 0;
            this.lblXMin.Text = "x min :";
            // 
            // lblXMax
            // 
            this.lblXMax.AutoSize = true;
            this.lblXMax.Location = new System.Drawing.Point(140, 540);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(40, 13);
            this.lblXMax.TabIndex = 0;
            this.lblXMax.Text = "x max :";
            // 
            // lblYMin
            // 
            this.lblYMin.AutoSize = true;
            this.lblYMin.Location = new System.Drawing.Point(12, 580);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(37, 13);
            this.lblYMin.TabIndex = 0;
            this.lblYMin.Text = "y min :";
            // 
            // lblYMax
            // 
            this.lblYMax.AutoSize = true;
            this.lblYMax.Location = new System.Drawing.Point(140, 580);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(40, 13);
            this.lblYMax.TabIndex = 0;
            this.lblYMax.Text = "y max :";
            // 
            // lblCReal
            // 
            this.lblCReal.AutoSize = true;
            this.lblCReal.Location = new System.Drawing.Point(274, 580);
            this.lblCReal.Name = "lblCReal";
            this.lblCReal.Size = new System.Drawing.Size(39, 13);
            this.lblCReal.TabIndex = 0;
            this.lblCReal.Text = "c Re. :";
            // 
            // lblCImaginary
            // 
            this.lblCImaginary.AutoSize = true;
            this.lblCImaginary.Location = new System.Drawing.Point(399, 580);
            this.lblCImaginary.Name = "lblCImaginary";
            this.lblCImaginary.Size = new System.Drawing.Size(36, 13);
            this.lblCImaginary.TabIndex = 0;
            this.lblCImaginary.Text = "c Im. :";
            // 
            // cboFractal
            // 
            this.cboFractal.FormattingEnabled = true;
            this.cboFractal.Items.AddRange(new object[] {
            "Mandelbrot",
            "Julia"});
            this.cboFractal.Location = new System.Drawing.Point(274, 537);
            this.cboFractal.Name = "cboFractal";
            this.cboFractal.Size = new System.Drawing.Size(125, 21);
            this.cboFractal.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(437, 536);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Générer !";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.PrintFractal);
            // 
            // txtXMin
            // 
            this.txtXMin.Location = new System.Drawing.Point(50, 537);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.Size = new System.Drawing.Size(75, 20);
            this.txtXMin.TabIndex = 2;
            // 
            // txtXMax
            // 
            this.txtXMax.Location = new System.Drawing.Point(178, 537);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.Size = new System.Drawing.Size(75, 20);
            this.txtXMax.TabIndex = 3;
            // 
            // txtYMin
            // 
            this.txtYMin.Location = new System.Drawing.Point(50, 577);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.Size = new System.Drawing.Size(75, 20);
            this.txtYMin.TabIndex = 4;
            // 
            // txtYMax
            // 
            this.txtYMax.Location = new System.Drawing.Point(178, 577);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.Size = new System.Drawing.Size(75, 20);
            this.txtYMax.TabIndex = 5;
            // 
            // txtCReal
            // 
            this.txtCReal.Location = new System.Drawing.Point(312, 577);
            this.txtCReal.Name = "txtCReal";
            this.txtCReal.Size = new System.Drawing.Size(75, 20);
            this.txtCReal.TabIndex = 6;
            // 
            // txtCImaginary
            // 
            this.txtCImaginary.Location = new System.Drawing.Point(437, 577);
            this.txtCImaginary.Name = "txtCImaginary";
            this.txtCImaginary.Size = new System.Drawing.Size(75, 20);
            this.txtCImaginary.TabIndex = 7;
            // 
            // txtGenerationTime
            // 
            this.txtGenerationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenerationTime.BackColor = System.Drawing.Color.Transparent;
            this.txtGenerationTime.Location = new System.Drawing.Point(419, 7);
            this.txtGenerationTime.Name = "txtGenerationTime";
            this.txtGenerationTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGenerationTime.Size = new System.Drawing.Size(93, 18);
            this.txtGenerationTime.TabIndex = 9;
            this.txtGenerationTime.Text = "temps";
            this.txtGenerationTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 605);
            this.Controls.Add(this.txtGenerationTime);
            this.Controls.Add(this.txtCImaginary);
            this.Controls.Add(this.txtCReal);
            this.Controls.Add(this.txtYMax);
            this.Controls.Add(this.txtYMin);
            this.Controls.Add(this.txtXMax);
            this.Controls.Add(this.txtXMin);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cboFractal);
            this.Controls.Add(this.lblCImaginary);
            this.Controls.Add(this.lblCReal);
            this.Controls.Add(this.lblYMax);
            this.Controls.Add(this.lblYMin);
            this.Controls.Add(this.lblXMax);
            this.Controls.Add(this.lblXMin);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.toolStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Génération d\'image fractale";
            this.toolStr.ResumeLayout(false);
            this.toolStr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStr;
        private System.Windows.Forms.ToolStripDropDownButton toolStrHistorique;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.Label lblCReal;
        private System.Windows.Forms.Label lblCImaginary;
        private System.Windows.Forms.ComboBox cboFractal;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.TextBox txtCReal;
        private System.Windows.Forms.TextBox txtCImaginary;
        private System.Windows.Forms.Label txtGenerationTime;
    }
}

