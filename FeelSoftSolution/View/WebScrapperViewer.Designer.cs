using SocialNetworkConnection;

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
            this.rdbTwitter = new System.Windows.Forms.RadioButton();
            this.queriesControl = new View.QueriesControl();
            this.lblLoad = new System.Windows.Forms.Label();
            this.lblSelectSocialNetwork = new System.Windows.Forms.Label();
            this.rdbFacebook = new System.Windows.Forms.RadioButton();
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
            this.splitContainer.Panel1.Controls.Add(this.rdbTwitter);
            this.splitContainer.Panel1.Controls.Add(this.queriesControl);
            this.splitContainer.Panel1.Controls.Add(this.lblLoad);
            this.splitContainer.Panel1.Controls.Add(this.lblSelectSocialNetwork);
            this.splitContainer.Panel1.Controls.Add(this.rdbFacebook);
            this.splitContainer.Panel1.Controls.Add(this.publicationViewerControl);
            this.splitContainer.Size = new System.Drawing.Size(836, 706);
            this.splitContainer.SplitterDistance = 536;
            this.splitContainer.TabIndex = 0;
            // 
            // rdbTwitter
            // 
            this.rdbTwitter.AutoSize = true;
            this.rdbTwitter.Location = new System.Drawing.Point(345, 5);
            this.rdbTwitter.Name = "rdbTwitter";
            this.rdbTwitter.Size = new System.Drawing.Size(57, 17);
            this.rdbTwitter.TabIndex = 13;
            this.rdbTwitter.Text = "Twitter";
            this.rdbTwitter.UseVisualStyleBackColor = true;
            this.rdbTwitter.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // queriesControl
            // 
            this.queriesControl.Location = new System.Drawing.Point(27, 28);
            this.queriesControl.Name = "queriesControl";
            this.queriesControl.Size = new System.Drawing.Size(421, 204);
            this.queriesControl.TabIndex = 2;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(44, 241);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(0, 13);
            this.lblLoad.TabIndex = 0;
            // 
            // lblSelectSocialNetwork
            // 
            this.lblSelectSocialNetwork.AutoSize = true;
            this.lblSelectSocialNetwork.Location = new System.Drawing.Point(81, 5);
            this.lblSelectSocialNetwork.Name = "lblSelectSocialNetwork";
            this.lblSelectSocialNetwork.Size = new System.Drawing.Size(129, 13);
            this.lblSelectSocialNetwork.TabIndex = 15;
            this.lblSelectSocialNetwork.Text = "Seleccione una red social";
            // 
            // rdbFacebook
            // 
            this.rdbFacebook.AutoSize = true;
            this.rdbFacebook.Checked = true;
            this.rdbFacebook.Location = new System.Drawing.Point(250, 5);
            this.rdbFacebook.Name = "rdbFacebook";
            this.rdbFacebook.Size = new System.Drawing.Size(73, 17);
            this.rdbFacebook.TabIndex = 14;
            this.rdbFacebook.TabStop = true;
            this.rdbFacebook.Text = "Facebook";
            this.rdbFacebook.UseVisualStyleBackColor = true;
            this.rdbFacebook.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // publicationViewerControl
            // 
            this.publicationViewerControl.Location = new System.Drawing.Point(12, 241);
            this.publicationViewerControl.Name = "publicationViewerControl";
            this.publicationViewerControl.Size = new System.Drawing.Size(436, 437);
            this.publicationViewerControl.TabIndex = 1;
            // 
            // WebScrapperViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 730);
            this.Controls.Add(this.splitContainer);
            this.Name = "WebScrapperViewer";
            this.Text = "Form1";
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
        private System.Windows.Forms.RadioButton rdbTwitter;
        private QueriesControl queriesControl;
        private System.Windows.Forms.Label lblSelectSocialNetwork;
        private System.Windows.Forms.RadioButton rdbFacebook;
        private ISearchDataSet dataset;

        public const int FACEBOOK = 0;
        public const int TWITTER = 1;
        private System.Windows.Forms.Label lblLoad;
    }
}

