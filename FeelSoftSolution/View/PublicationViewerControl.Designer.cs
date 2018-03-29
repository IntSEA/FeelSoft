using SocialNetworkConnection;
using System.Collections.Generic;

namespace View
{
    partial class PublicationViewerControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxPublications = new System.Windows.Forms.GroupBox();
            this.lblPublication = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblTotalPublications = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBefore = new System.Windows.Forms.Button();
            this.tbxPublication = new System.Windows.Forms.TextBox();
            this.gbxFunctions = new System.Windows.Forms.GroupBox();
            this.btnImportPublications = new System.Windows.Forms.Button();
            this.btnExportPublications = new System.Windows.Forms.Button();
            this.btnSavePublications = new System.Windows.Forms.Button();
            this.gbxPublications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.gbxFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPublications
            // 
            this.gbxPublications.Controls.Add(this.lblPublication);
            this.gbxPublications.Controls.Add(this.numericUpDown);
            this.gbxPublications.Controls.Add(this.lblTotalPublications);
            this.gbxPublications.Controls.Add(this.btnNext);
            this.gbxPublications.Controls.Add(this.btnBefore);
            this.gbxPublications.Controls.Add(this.tbxPublication);
            this.gbxPublications.Location = new System.Drawing.Point(27, 19);
            this.gbxPublications.Name = "gbxPublications";
            this.gbxPublications.Size = new System.Drawing.Size(386, 287);
            this.gbxPublications.TabIndex = 0;
            this.gbxPublications.TabStop = false;
            this.gbxPublications.Text = "Publicaciones";
            // 
            // lblPublication
            // 
            this.lblPublication.AutoSize = true;
            this.lblPublication.Location = new System.Drawing.Point(247, 221);
            this.lblPublication.Name = "lblPublication";
            this.lblPublication.Size = new System.Drawing.Size(62, 13);
            this.lblPublication.TabIndex = 20;
            this.lblPublication.Text = "Publicación";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown.Location = new System.Drawing.Point(325, 216);
            this.numericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown.TabIndex = 19;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            // 
            // lblTotalPublications
            // 
            this.lblTotalPublications.AutoSize = true;
            this.lblTotalPublications.Location = new System.Drawing.Point(247, 251);
            this.lblTotalPublications.Name = "lblTotalPublications";
            this.lblTotalPublications.Size = new System.Drawing.Size(88, 13);
            this.lblTotalPublications.TabIndex = 18;
            this.lblTotalPublications.Text = "Publicaciones : 0";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(117, 210);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "-->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(27, 211);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 23);
            this.btnBefore.TabIndex = 16;
            this.btnBefore.Text = "<--";
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.BtnBeforeClick);
            // 
            // tbxPublication
            // 
            this.tbxPublication.Location = new System.Drawing.Point(27, 42);
            this.tbxPublication.Multiline = true;
            this.tbxPublication.Name = "tbxPublication";
            this.tbxPublication.Size = new System.Drawing.Size(330, 162);
            this.tbxPublication.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.gbxFunctions.Controls.Add(this.btnImportPublications);
            this.gbxFunctions.Controls.Add(this.btnExportPublications);
            this.gbxFunctions.Controls.Add(this.btnSavePublications);
            this.gbxFunctions.Location = new System.Drawing.Point(27, 323);
            this.gbxFunctions.Name = "groupBox1";
            this.gbxFunctions.Size = new System.Drawing.Size(386, 113);
            this.gbxFunctions.TabIndex = 1;
            this.gbxFunctions.TabStop = false;
            this.gbxFunctions.Text = "Funciones";
            // 
            // btnImportPublications
            // 
            this.btnImportPublications.Location = new System.Drawing.Point(207, 19);
            this.btnImportPublications.Name = "btnImportPublications";
            this.btnImportPublications.Size = new System.Drawing.Size(159, 23);
            this.btnImportPublications.TabIndex = 2;
            this.btnImportPublications.Text = "Importar publicaciones";
            this.btnImportPublications.UseVisualStyleBackColor = true;
            this.btnImportPublications.Click += new System.EventHandler(this.BtnImportPublications_Click);
            // 
            // btnExportPublications
            // 
            this.btnExportPublications.Location = new System.Drawing.Point(117, 71);
            this.btnExportPublications.Name = "btnExportPublications";
            this.btnExportPublications.Size = new System.Drawing.Size(165, 23);
            this.btnExportPublications.TabIndex = 1;
            this.btnExportPublications.Text = "Exportar publicaciónes";
            this.btnExportPublications.UseVisualStyleBackColor = true;
            this.btnExportPublications.Click += new System.EventHandler(this.BtnExportPublications_Click);
            // 
            // btnSavePublications
            // 
            this.btnSavePublications.Location = new System.Drawing.Point(27, 19);
            this.btnSavePublications.Name = "btnSavePublications";
            this.btnSavePublications.Size = new System.Drawing.Size(165, 23);
            this.btnSavePublications.TabIndex = 0;
            this.btnSavePublications.Text = "Guardar publicaciones";
            this.btnSavePublications.UseVisualStyleBackColor = true;
            this.btnSavePublications.Click += new System.EventHandler(this.BtnSavePublications_Click);
            // 
            // PublicationViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxFunctions);
            this.Controls.Add(this.gbxPublications);
            this.Name = "PublicationViewerControl";
            this.Size = new System.Drawing.Size(455, 473);
            this.gbxPublications.ResumeLayout(false);
            this.gbxPublications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.gbxFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPublications;
        private System.Windows.Forms.Label lblPublication;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lblTotalPublications;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.TextBox tbxPublication;
        private IPublication[] publications;
        private int indexCurrentPublications;
        private System.Windows.Forms.GroupBox gbxFunctions;
        private System.Windows.Forms.Button btnSavePublications;
        private System.Windows.Forms.Button btnImportPublications;
        private System.Windows.Forms.Button btnExportPublications;
        private WebScrapperViewer main;
    }
}
