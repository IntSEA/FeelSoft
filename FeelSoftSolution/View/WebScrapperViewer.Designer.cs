namespace View
{
    partial class WebScrapperViewer
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.publicationViewerControl = new View.PublicationViewerControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer.Location = new System.Drawing.Point(23, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.publicationViewerControl);
            this.splitContainer.Size = new System.Drawing.Size(836, 394);
            this.splitContainer.SplitterDistance = 536;
            this.splitContainer.TabIndex = 0;
            // 
            // publicationViewerControl
            // 
            this.publicationViewerControl.Location = new System.Drawing.Point(44, 12);
            this.publicationViewerControl.Name = "publicationViewerControl";
            this.publicationViewerControl.Size = new System.Drawing.Size(452, 365);
            this.publicationViewerControl.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 410);
            this.Controls.Add(this.splitContainer);
            this.Name = "Main";
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private PublicationViewerControl publicationViewerControl;
        public const string TWITTER_CREDENTIALS_PATH = "..//Resources//TwitterCredentials.txt";
        public const string FACEBOOK_CREDENTIALS_PATH = "..//Resources//FacebookCredentials.txt";
    }
}

