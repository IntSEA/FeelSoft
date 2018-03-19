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
            this.queriesControl1 = new View.QueriesControl();
            this.lblSelectSocialNetwork = new System.Windows.Forms.Label();
            this.rdbFacebook = new System.Windows.Forms.RadioButton();
            this.publicationViewerControl1 = new View.PublicationViewerControl();
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
            this.splitContainer.Panel1.Controls.Add(this.queriesControl1);
            this.splitContainer.Panel1.Controls.Add(this.lblSelectSocialNetwork);
            this.splitContainer.Panel1.Controls.Add(this.rdbFacebook);
            this.splitContainer.Panel1.Controls.Add(this.publicationViewerControl1);
            this.splitContainer.Size = new System.Drawing.Size(836, 544);
            this.splitContainer.SplitterDistance = 536;
            this.splitContainer.TabIndex = 0;
            // 
            // rdbTwitter
            // 
            this.rdbTwitter.AutoSize = true;
            this.rdbTwitter.Location = new System.Drawing.Point(374, 5);
            this.rdbTwitter.Name = "rdbTwitter";
            this.rdbTwitter.Size = new System.Drawing.Size(57, 17);
            this.rdbTwitter.TabIndex = 13;
            this.rdbTwitter.Text = "Twitter";
            this.rdbTwitter.UseVisualStyleBackColor = true;
            this.rdbTwitter.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // queriesControl1
            // 
            this.queriesControl1.Location = new System.Drawing.Point(74, 28);
            this.queriesControl1.Name = "queriesControl1";
            this.queriesControl1.Size = new System.Drawing.Size(421, 208);
            this.queriesControl1.TabIndex = 2;
            // 
            // lblSelectSocialNetwork
            // 
            this.lblSelectSocialNetwork.AutoSize = true;
            this.lblSelectSocialNetwork.Location = new System.Drawing.Point(110, 5);
            this.lblSelectSocialNetwork.Name = "lblSelectSocialNetwork";
            this.lblSelectSocialNetwork.Size = new System.Drawing.Size(129, 13);
            this.lblSelectSocialNetwork.TabIndex = 15;
            this.lblSelectSocialNetwork.Text = "Seleccione una red social";
            // 
            // rdbFacebook
            // 
            this.rdbFacebook.AutoSize = true;
            this.rdbFacebook.Checked = true;
            this.rdbFacebook.Location = new System.Drawing.Point(279, 5);
            this.rdbFacebook.Name = "rdbFacebook";
            this.rdbFacebook.Size = new System.Drawing.Size(73, 17);
            this.rdbFacebook.TabIndex = 14;
            this.rdbFacebook.TabStop = true;
            this.rdbFacebook.Text = "Facebook";
            this.rdbFacebook.UseVisualStyleBackColor = true;
            this.rdbFacebook.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // publicationViewerControl1
            // 
            this.publicationViewerControl1.Location = new System.Drawing.Point(59, 225);
            this.publicationViewerControl1.Name = "publicationViewerControl1";
            this.publicationViewerControl1.Size = new System.Drawing.Size(436, 316);
            this.publicationViewerControl1.TabIndex = 1;
            // 
            // WebScrapperViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 568);
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

        public const string TWITTER_CREDENTIALS_PATH = "..//..//Resources//TwitterCredentials.txt";
        public const string FACEBOOK_CREDENTIALS_PATH = "..//..//Resources//FacebookCredentials.txt";
        private PublicationViewerControl publicationViewerControl1;
        private System.Windows.Forms.RadioButton rdbTwitter;
        private QueriesControl queriesControl1;
        private System.Windows.Forms.Label lblSelectSocialNetwork;
        private System.Windows.Forms.RadioButton rdbFacebook;
    }
}

