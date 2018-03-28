namespace View
{
    partial class QueryConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentPane = new System.Windows.Forms.Panel();
            this.btnCreateQueryConfiguration = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.queryConfigurationControl = new View.QueryConfigurationControl();
            this.contentPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPane
            // 
            this.contentPane.AutoScroll = true;
            this.contentPane.Controls.Add(this.queryConfigurationControl);
            this.contentPane.Location = new System.Drawing.Point(12, 13);
            this.contentPane.Name = "contentPane";
            this.contentPane.Size = new System.Drawing.Size(474, 354);
            this.contentPane.TabIndex = 0;
            // 
            // btnCreateQueryConfiguration
            // 
            this.btnCreateQueryConfiguration.Location = new System.Drawing.Point(92, 379);
            this.btnCreateQueryConfiguration.Name = "btnCreateQueryConfiguration";
            this.btnCreateQueryConfiguration.Size = new System.Drawing.Size(163, 23);
            this.btnCreateQueryConfiguration.TabIndex = 1;
            this.btnCreateQueryConfiguration.Text = "Crear configuración";
            this.btnCreateQueryConfiguration.UseVisualStyleBackColor = true;
            this.btnCreateQueryConfiguration.Click += new System.EventHandler(this.BtnCreateQueryConfiguration_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(291, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // queryConfigurationControl
            // 
            this.queryConfigurationControl.Location = new System.Drawing.Point(4, 4);
            this.queryConfigurationControl.Name = "queryConfigurationControl";
            this.queryConfigurationControl.Size = new System.Drawing.Size(462, 544);
            this.queryConfigurationControl.TabIndex = 0;
            // 
            // QueryConfigurationForm
            // 
            this.AcceptButton = this.btnCreateQueryConfiguration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(498, 414);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateQueryConfiguration);
            this.Controls.Add(this.contentPane);
            this.Name = "QueryConfigurationForm";
            this.Text = "QueryConfigurationForm";
            this.contentPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentPane;
        private QueryConfigurationControl queryConfigurationControl;
        private System.Windows.Forms.Button btnCreateQueryConfiguration;
        private System.Windows.Forms.Button btnCancel;
    }
}