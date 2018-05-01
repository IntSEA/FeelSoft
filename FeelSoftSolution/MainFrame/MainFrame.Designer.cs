using Controller;
using System.Windows.Forms;
using View;




namespace MainFrame
{
    partial class MainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.verticalMenu = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.btnViewPublications = new System.Windows.Forms.Button();
            this.btnAdvances = new System.Windows.Forms.Button();
            this.btnQualification = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.verticalMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // verticalMenu
            // 
            this.verticalMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.verticalMenu.Controls.Add(this.btnViewPublications);
            this.verticalMenu.Controls.Add(this.panel6);
            this.verticalMenu.Controls.Add(this.btnAdvances);
            this.verticalMenu.Controls.Add(this.panel5);
            this.verticalMenu.Controls.Add(this.btnQualification);
            this.verticalMenu.Controls.Add(this.pictureBox1);
            this.verticalMenu.Controls.Add(this.panel4);
            this.verticalMenu.Controls.Add(this.panel3);
            this.verticalMenu.Controls.Add(this.btnSearch);
            this.verticalMenu.Controls.Add(this.panel2);
            this.verticalMenu.Controls.Add(this.btnReports);
            this.verticalMenu.Controls.Add(this.panel1);
            this.verticalMenu.Controls.Add(this.btnHome);
            this.verticalMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalMenu.Location = new System.Drawing.Point(0, 0);
            this.verticalMenu.Name = "verticalMenu";
            this.verticalMenu.Size = new System.Drawing.Size(228, 627);
            this.verticalMenu.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel6.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel6.Location = new System.Drawing.Point(0, 551);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 53);
            this.panel6.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel5.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel5.Location = new System.Drawing.Point(0, 477);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 53);
            this.panel5.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel4.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel4.Location = new System.Drawing.Point(0, 332);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 53);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel3.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel3.Location = new System.Drawing.Point(0, 406);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 53);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel2.Location = new System.Drawing.Point(0, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 53);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.ForeColor = System.Drawing.Color.Cornsilk;
            this.panel1.Location = new System.Drawing.Point(0, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 53);
            this.panel1.TabIndex = 1;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(228, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(797, 627);
            this.containerPanel.TabIndex = 3;
            // 
            // btnViewPublications
            // 
            this.btnViewPublications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnViewPublications.FlatAppearance.BorderSize = 0;
            this.btnViewPublications.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnViewPublications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPublications.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPublications.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewPublications.Image = ((System.Drawing.Image)(resources.GetObject("btnViewPublications.Image")));
            this.btnViewPublications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPublications.Location = new System.Drawing.Point(7, 477);
            this.btnViewPublications.Name = "btnViewPublications";
            this.btnViewPublications.Size = new System.Drawing.Size(219, 50);
            this.btnViewPublications.TabIndex = 9;
            this.btnViewPublications.Text = "Publicaciones";
            this.btnViewPublications.UseVisualStyleBackColor = false;
            // 
            // btnAdvances
            // 
            this.btnAdvances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnAdvances.FlatAppearance.BorderSize = 0;
            this.btnAdvances.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnAdvances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvances.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvances.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdvances.Image = ((System.Drawing.Image)(resources.GetObject("btnAdvances.Image")));
            this.btnAdvances.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdvances.Location = new System.Drawing.Point(6, 554);
            this.btnAdvances.Name = "btnAdvances";
            this.btnAdvances.Size = new System.Drawing.Size(219, 50);
            this.btnAdvances.TabIndex = 8;
            this.btnAdvances.Text = "Avanzadas";
            this.btnAdvances.UseVisualStyleBackColor = false;
            // 
            // btnQualification
            // 
            this.btnQualification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnQualification.FlatAppearance.BorderSize = 0;
            this.btnQualification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnQualification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQualification.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQualification.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQualification.Image = ((System.Drawing.Image)(resources.GetObject("btnQualification.Image")));
            this.btnQualification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQualification.Location = new System.Drawing.Point(6, 406);
            this.btnQualification.Name = "btnQualification";
            this.btnQualification.Size = new System.Drawing.Size(219, 50);
            this.btnQualification.TabIndex = 5;
            this.btnQualification.Text = "Calificacion";
            this.btnQualification.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 160);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(6, 260);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(219, 50);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Busqueda";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(7, 332);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(218, 53);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Reportes";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Image = global::MainFrame.Properties.Resources.House;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(6, 188);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(219, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Inicio";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1025, 627);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.verticalMenu);
            this.Name = "MainFrame";
            this.verticalMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel verticalMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnQualification;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controller.Controller controller;
        private WebScrapperViewer webScrapperViewer;
        private HomePanel home;
        private System.Windows.Forms.Button btnAdvances;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel containerPanel;
        private Button btnViewPublications;
        private Panel panel6;
    }
}

