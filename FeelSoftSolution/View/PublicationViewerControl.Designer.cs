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
            this.cbxQueries = new System.Windows.Forms.ComboBox();
            this.btnCreateQuery = new System.Windows.Forms.Button();
            this.lblConfigurations = new System.Windows.Forms.Label();
            this.tbxPublication = new System.Windows.Forms.TextBox();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnAfter = new System.Windows.Forms.Button();
            this.lblTotalPublications = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblPublication = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxQueries
            // 
            this.cbxQueries.FormattingEnabled = true;
            this.cbxQueries.Location = new System.Drawing.Point(37, 47);
            this.cbxQueries.Name = "cbxQueries";
            this.cbxQueries.Size = new System.Drawing.Size(191, 21);
            this.cbxQueries.TabIndex = 0;
            // 
            // btnCreateQuery
            // 
            this.btnCreateQuery.Location = new System.Drawing.Point(260, 32);
            this.btnCreateQuery.Name = "btnCreateQuery";
            this.btnCreateQuery.Size = new System.Drawing.Size(107, 48);
            this.btnCreateQuery.TabIndex = 1;
            this.btnCreateQuery.Text = "Crear configuración de busqueda";
            this.btnCreateQuery.UseVisualStyleBackColor = true;
            this.btnCreateQuery.Click += new System.EventHandler(this.btnCreateQuery_Click);
            // 
            // lblConfigurations
            // 
            this.lblConfigurations.AutoSize = true;
            this.lblConfigurations.Location = new System.Drawing.Point(77, 31);
            this.lblConfigurations.Name = "lblConfigurations";
            this.lblConfigurations.Size = new System.Drawing.Size(83, 13);
            this.lblConfigurations.TabIndex = 2;
            this.lblConfigurations.Text = "Configuraciones";
            // 
            // tbxPublication
            // 
            this.tbxPublication.Location = new System.Drawing.Point(37, 122);
            this.tbxPublication.Multiline = true;
            this.tbxPublication.Name = "tbxPublication";
            this.tbxPublication.Size = new System.Drawing.Size(330, 162);
            this.tbxPublication.TabIndex = 3;
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(37, 291);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 23);
            this.btnBefore.TabIndex = 4;
            this.btnBefore.Text = "<--";
            this.btnBefore.UseVisualStyleBackColor = true;
            // 
            // btnAfter
            // 
            this.btnAfter.Location = new System.Drawing.Point(127, 290);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.Size = new System.Drawing.Size(75, 23);
            this.btnAfter.TabIndex = 5;
            this.btnAfter.Text = "-->";
            this.btnAfter.UseVisualStyleBackColor = true;
            // 
            // lblTotalPublications
            // 
            this.lblTotalPublications.AutoSize = true;
            this.lblTotalPublications.Location = new System.Drawing.Point(257, 331);
            this.lblTotalPublications.Name = "lblTotalPublications";
            this.lblTotalPublications.Size = new System.Drawing.Size(100, 13);
            this.lblTotalPublications.TabIndex = 6;
            this.lblTotalPublications.Text = "Publicaciones : 100";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(335, 296);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // lblPublication
            // 
            this.lblPublication.AutoSize = true;
            this.lblPublication.Location = new System.Drawing.Point(257, 301);
            this.lblPublication.Name = "lblPublication";
            this.lblPublication.Size = new System.Drawing.Size(62, 13);
            this.lblPublication.TabIndex = 8;
            this.lblPublication.Text = "Publicación";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(37, 75);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // PublicationViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPublication);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblTotalPublications);
            this.Controls.Add(this.btnAfter);
            this.Controls.Add(this.btnBefore);
            this.Controls.Add(this.tbxPublication);
            this.Controls.Add(this.lblConfigurations);
            this.Controls.Add(this.btnCreateQuery);
            this.Controls.Add(this.cbxQueries);
            this.Name = "PublicationViewerControl";
            this.Size = new System.Drawing.Size(399, 365);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxQueries;
        private System.Windows.Forms.Button btnCreateQuery;
        private System.Windows.Forms.Label lblConfigurations;
        private System.Windows.Forms.TextBox tbxPublication;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Button btnAfter;
        private System.Windows.Forms.Label lblTotalPublications;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblPublication;
        private System.Windows.Forms.Button btnAceptar;
    }
}
