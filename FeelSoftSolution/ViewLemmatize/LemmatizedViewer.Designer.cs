using SocialNetworkConnection;
using TextualProcessor;
namespace View
{
    partial class LemmatizedViewer
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
            this.lblLoad = new System.Windows.Forms.Label();
            this.publicationViewerControl = new View.PublicationViewerControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(23, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblLoad);
            this.splitContainer.Panel1.Controls.Add(this.publicationViewerControl);
            this.splitContainer.Size = new System.Drawing.Size(466, 706);
            this.splitContainer.SplitterDistance = this.splitContainer.Width;
            this.splitContainer.TabIndex = 0;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(44, 241);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(0, 13);
            this.lblLoad.TabIndex = 0;
            // 
            // publicationViewerControl
            // 
            this.publicationViewerControl.Location = new System.Drawing.Point(-11, -5);
            this.publicationViewerControl.Name = "publicationViewerControl";
            this.publicationViewerControl.Size = new System.Drawing.Size(436, 437);
            this.publicationViewerControl.TabIndex = 1;
            // 
            // LemmatizedViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 456);
            this.Controls.Add(this.splitContainer);
            this.Name = "LemmatizedViewer";
            this.Text = "FeelSoft";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private SocialNetworkConnection.ISocialNetwork facebook;
        private SocialNetworkConnection.ISocialNetwork twitter;
        private int selectedSocialNetwork;
        private PublicationViewerControl publicationViewerControl;
        private ISearchDataSet dataset;
        private Processor processor;

        public const int FACEBOOK = 0;
        public const int TWITTER = 1;
        private System.Windows.Forms.Label lblLoad;
    }
}

