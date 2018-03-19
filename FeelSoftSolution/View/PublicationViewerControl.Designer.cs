using SocialNetworkConnection;
using System.Collections;
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
            this.cbxQueries = new System.Windows.Forms.ComboBox();
            this.btnCreateQuery = new System.Windows.Forms.Button();
            this.lblConfigurations = new System.Windows.Forms.Label();
            this.tbxPublication = new System.Windows.Forms.TextBox();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnAfter = new System.Windows.Forms.Button();
            this.lblTotalPublications = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblPublication = new System.Windows.Forms.Label();
            this.btnAcept = new System.Windows.Forms.Button();
            this.rdbFacebook = new System.Windows.Forms.RadioButton();
            this.rdbTwitter = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxQueries
            // 
            this.cbxQueries.FormattingEnabled = true;
            this.cbxQueries.Location = new System.Drawing.Point(38, 90);
            this.cbxQueries.Name = "cbxQueries";
            this.cbxQueries.Size = new System.Drawing.Size(191, 21);
            this.cbxQueries.TabIndex = 0;
            // 
            // btnCreateQuery
            // 
            this.btnCreateQuery.Location = new System.Drawing.Point(261, 75);
            this.btnCreateQuery.Name = "btnCreateQuery";
            this.btnCreateQuery.Size = new System.Drawing.Size(107, 48);
            this.btnCreateQuery.TabIndex = 1;
            this.btnCreateQuery.Text = "Crear configuración de busqueda";
            this.btnCreateQuery.UseVisualStyleBackColor = true;
            // 
            // lblConfigurations
            // 
            this.lblConfigurations.AutoSize = true;
            this.lblConfigurations.Location = new System.Drawing.Point(78, 74);
            this.lblConfigurations.Name = "lblConfigurations";
            this.lblConfigurations.Size = new System.Drawing.Size(83, 13);
            this.lblConfigurations.TabIndex = 2;
            this.lblConfigurations.Text = "Configuraciones";
            // 
            // tbxPublication
            // 
            this.tbxPublication.Location = new System.Drawing.Point(38, 165);
            this.tbxPublication.Multiline = true;
            this.tbxPublication.Name = "tbxPublication";
            this.tbxPublication.Size = new System.Drawing.Size(330, 162);
            this.tbxPublication.TabIndex = 3;
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(38, 334);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 23);
            this.btnBefore.TabIndex = 4;
            this.btnBefore.Text = "<--";
            this.btnBefore.UseVisualStyleBackColor = true;
            // 
            // btnAfter
            // 
            this.btnAfter.Location = new System.Drawing.Point(128, 333);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.Size = new System.Drawing.Size(75, 23);
            this.btnAfter.TabIndex = 5;
            this.btnAfter.Text = "-->";
            this.btnAfter.UseVisualStyleBackColor = true;
            // 
            // lblTotalPublications
            // 
            this.lblTotalPublications.AutoSize = true;
            this.lblTotalPublications.Location = new System.Drawing.Point(258, 374);
            this.lblTotalPublications.Name = "lblTotalPublications";
            this.lblTotalPublications.Size = new System.Drawing.Size(100, 13);
            this.lblTotalPublications.TabIndex = 6;
            this.lblTotalPublications.Text = "Publicaciones : 100";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(336, 339);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown.TabIndex = 7;
            // 
            // lblPublication
            // 
            this.lblPublication.AutoSize = true;
            this.lblPublication.Location = new System.Drawing.Point(258, 344);
            this.lblPublication.Name = "lblPublication";
            this.lblPublication.Size = new System.Drawing.Size(62, 13);
            this.lblPublication.TabIndex = 8;
            this.lblPublication.Text = "Publicación";
            // 
            // btnAcept
            // 
            this.btnAcept.Location = new System.Drawing.Point(38, 118);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(85, 23);
            this.btnAcept.TabIndex = 9;
            this.btnAcept.Text = "Aceptar";
            this.btnAcept.UseVisualStyleBackColor = true;
            this.btnAcept.Click += new System.EventHandler(this.BtnAcceptClick);
            // 
            // rdbFacebook
            // 
            this.rdbFacebook.AutoSize = true;
            this.rdbFacebook.Checked = true;
            this.rdbFacebook.Location = new System.Drawing.Point(81, 22);
            this.rdbFacebook.Name = "rdbFacebook";
            this.rdbFacebook.Size = new System.Drawing.Size(73, 17);
            this.rdbFacebook.TabIndex = 10;
            this.rdbFacebook.TabStop = true;
            this.rdbFacebook.Text = "Facebook";
            this.rdbFacebook.UseVisualStyleBackColor = true;
            this.rdbFacebook.CheckedChanged += new System.EventHandler(this.RdbTwitter_CheckedChanged);
            // 
            // rdbTwitter
            // 
            this.rdbTwitter.AutoSize = true;
            this.rdbTwitter.Location = new System.Drawing.Point(238, 22);
            this.rdbTwitter.Name = "rdbTwitter";
            this.rdbTwitter.Size = new System.Drawing.Size(57, 17);
            this.rdbTwitter.TabIndex = 10;
            this.rdbTwitter.Text = "Twitter";
            this.rdbTwitter.UseVisualStyleBackColor = true;
            this.rdbTwitter.CheckedChanged += new System.EventHandler(this.RdbTwitter_CheckedChanged);
            // 
            // PublicationViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdbTwitter);
            this.Controls.Add(this.rdbFacebook);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.lblPublication);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.lblTotalPublications);
            this.Controls.Add(this.btnAfter);
            this.Controls.Add(this.btnBefore);
            this.Controls.Add(this.tbxPublication);
            this.Controls.Add(this.lblConfigurations);
            this.Controls.Add(this.btnCreateQuery);
            this.Controls.Add(this.cbxQueries);
            this.Name = "PublicationViewerControl";
            this.Size = new System.Drawing.Size(399, 415);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lblPublication;
        private System.Windows.Forms.Button btnAcept;
        private ISocialNetwork facebook;
        private IList<IQueryConfiguration> configurations;
        private IList<IPublication> publications;
        private ISocialNetwork twitter;
        private IQueryConfiguration currentConfiguration;
        private System.Windows.Forms.RadioButton rdbFacebook;
        private System.Windows.Forms.RadioButton rdbTwitter;
    }
}
