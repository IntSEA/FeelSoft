namespace MainFrame
{
    partial class HomePanel
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
            this.btDailyAnalysis = new System.Windows.Forms.Button();
            this.lbPetro = new System.Windows.Forms.Label();
            this.lbFajardo = new System.Windows.Forms.Label();
            this.lbVS = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPetro = new System.Windows.Forms.PictureBox();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // btDailyAnalysis
            // 
            this.btDailyAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btDailyAnalysis.FlatAppearance.BorderSize = 0;
            this.btDailyAnalysis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btDailyAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDailyAnalysis.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDailyAnalysis.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDailyAnalysis.Location = new System.Drawing.Point(260, 525);
            this.btDailyAnalysis.Name = "btDailyAnalysis";
            this.btDailyAnalysis.Size = new System.Drawing.Size(217, 61);
            this.btDailyAnalysis.TabIndex = 3;
            this.btDailyAnalysis.Text = "Analisis Diario";
            this.btDailyAnalysis.UseVisualStyleBackColor = false;
            this.btDailyAnalysis.Click += new System.EventHandler(this.btDailyAnalysis_Click);
            // 
            // lbPetro
            // 
            this.lbPetro.AutoSize = true;
            this.lbPetro.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPetro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPetro.Location = new System.Drawing.Point(103, 427);
            this.lbPetro.Name = "lbPetro";
            this.lbPetro.Size = new System.Drawing.Size(156, 24);
            this.lbPetro.TabIndex = 4;
            this.lbPetro.Text = "Gustavo Petro";
            // 
            // lbFajardo
            // 
            this.lbFajardo.AutoSize = true;
            this.lbFajardo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFajardo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbFajardo.Location = new System.Drawing.Point(491, 427);
            this.lbFajardo.Name = "lbFajardo";
            this.lbFajardo.Size = new System.Drawing.Size(152, 24);
            this.lbFajardo.TabIndex = 5;
            this.lbFajardo.Text = "Sergio Fajardo";
            // 
            // lbVS
            // 
            this.lbVS.AutoSize = true;
            this.lbVS.Font = new System.Drawing.Font("Mistral", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbVS.Location = new System.Drawing.Point(318, 267);
            this.lbVS.Name = "lbVS";
            this.lbVS.Size = new System.Drawing.Size(121, 114);
            this.lbVS.TabIndex = 6;
            this.lbVS.Text = "VS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MainFrame.Properties.Resources.Fajardo;
            this.pictureBox1.Location = new System.Drawing.Point(462, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 201);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pbPetro
            // 
            this.pbPetro.Image = global::MainFrame.Properties.Resources.Petro;
            this.pbPetro.Location = new System.Drawing.Point(82, 201);
            this.pbPetro.Name = "pbPetro";
            this.pbPetro.Size = new System.Drawing.Size(202, 201);
            this.pbPetro.TabIndex = 1;
            this.pbPetro.TabStop = false;
            // 
            // pbBanner
            // 
            this.pbBanner.Image = global::MainFrame.Properties.Resources.bannere_elecciones_2018;
            this.pbBanner.Location = new System.Drawing.Point(12, 12);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(736, 148);
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            this.pbBanner.Click += new System.EventHandler(this.pbBanner_Click);
            // 
            // HomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(754, 609);
            this.Controls.Add(this.lbVS);
            this.Controls.Add(this.lbFajardo);
            this.Controls.Add(this.lbPetro);
            this.Controls.Add(this.btDailyAnalysis);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPetro);
            this.Controls.Add(this.pbBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomePanel";
            this.Text = "Home";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.HomePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.PictureBox pbPetro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btDailyAnalysis;
        private System.Windows.Forms.Label lbPetro;
        private System.Windows.Forms.Label lbFajardo;
        private System.Windows.Forms.Label lbVS;
        
    }
}