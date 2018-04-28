using SocialNetworkConnection;

namespace View
{
    partial class CreateQueryConfigurationViewer
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
            this.lbKeyword = new System.Windows.Forms.Label();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbFilter = new System.Windows.Forms.Label();
            this.lbSinceDate = new System.Windows.Forms.Label();
            this.lbUntilDate = new System.Windows.Forms.Label();
            this.lbSearchType = new System.Windows.Forms.Label();
            this.lbGeo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.dtpSinceDate = new System.Windows.Forms.DateTimePicker();
            this.dtpUntilDate = new System.Windows.Forms.DateTimePicker();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.countPublication = new System.Windows.Forms.NumericUpDown();
            this.txteo = new System.Windows.Forms.TextBox();
            this.txtWordKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.countPublication)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKeyword
            // 
            this.lbKeyword.AutoSize = true;
            this.lbKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeyword.Location = new System.Drawing.Point(20, 43);
            this.lbKeyword.Name = "lbKeyword";
            this.lbKeyword.Size = new System.Drawing.Size(99, 20);
            this.lbKeyword.TabIndex = 0;
            this.lbKeyword.Text = "Palabra Clave :";
            this.lbKeyword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbKeyword.UseCompatibleTextRendering = true;
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLanguage.Location = new System.Drawing.Point(23, 74);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(65, 20);
            this.lbLanguage.TabIndex = 2;
            this.lbLanguage.Text = "Lenguaje:";
            this.lbLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLanguage.UseCompatibleTextRendering = true;
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocation.Location = new System.Drawing.Point(23, 103);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(65, 20);
            this.lbLocation.TabIndex = 3;
            this.lbLocation.Text = "Ubicacion";
            this.lbLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLocation.UseCompatibleTextRendering = true;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(23, 132);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(39, 20);
            this.lbFilter.TabIndex = 4;
            this.lbFilter.Text = "Filtro:";
            this.lbFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFilter.UseCompatibleTextRendering = true;
            // 
            // lbSinceDate
            // 
            this.lbSinceDate.AutoSize = true;
            this.lbSinceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSinceDate.Location = new System.Drawing.Point(23, 164);
            this.lbSinceDate.Name = "lbSinceDate";
            this.lbSinceDate.Size = new System.Drawing.Size(85, 20);
            this.lbSinceDate.TabIndex = 5;
            this.lbSinceDate.Text = "Fecha inicial:";
            this.lbSinceDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSinceDate.UseCompatibleTextRendering = true;
            // 
            // lbUntilDate
            // 
            this.lbUntilDate.AutoSize = true;
            this.lbUntilDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUntilDate.Location = new System.Drawing.Point(23, 193);
            this.lbUntilDate.Name = "lbUntilDate";
            this.lbUntilDate.Size = new System.Drawing.Size(76, 20);
            this.lbUntilDate.TabIndex = 6;
            this.lbUntilDate.Text = "Fecha final:";
            this.lbUntilDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUntilDate.UseCompatibleTextRendering = true;
            // 
            // lbSearchType
            // 
            this.lbSearchType.AutoSize = true;
            this.lbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchType.Location = new System.Drawing.Point(20, 221);
            this.lbSearchType.Name = "lbSearchType";
            this.lbSearchType.Size = new System.Drawing.Size(120, 20);
            this.lbSearchType.TabIndex = 7;
            this.lbSearchType.Text = "Tipo de Busqueda:";
            this.lbSearchType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSearchType.UseCompatibleTextRendering = true;
            // 
            // lbGeo
            // 
            this.lbGeo.AutoSize = true;
            this.lbGeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGeo.Location = new System.Drawing.Point(20, 252);
            this.lbGeo.Name = "lbGeo";
            this.lbGeo.Size = new System.Drawing.Size(102, 20);
            this.lbGeo.TabIndex = 8;
            this.lbGeo.Text = "Geolocalizacion";
            this.lbGeo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbGeo.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cantidad de Publicaciones: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // cbLanguage
            // 
            this.cbLanguage.DisplayMember = "Spanish";
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            SocialNetworkConnection.Languages.Spanish,
            SocialNetworkConnection.Languages.English});
            this.cbLanguage.Location = new System.Drawing.Point(124, 73);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbLanguage.TabIndex = 10;
            this.cbLanguage.Text = "Spanish";
            this.cbLanguage.ValueMember = "¿";
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Items.AddRange(new object[] {
            SocialNetworkConnection.Locations.Colombia,
            SocialNetworkConnection.Locations.USA});
            this.cbLocation.Location = new System.Drawing.Point(124, 102);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(121, 21);
            this.cbLocation.TabIndex = 11;
            this.cbLocation.Text = "Colombia";
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            SocialNetworkConnection.Filters.Video,
            SocialNetworkConnection.Filters.Image,
            SocialNetworkConnection.Filters.None,
            SocialNetworkConnection.Filters.Hashtag});
            this.cbFilter.Location = new System.Drawing.Point(124, 131);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 12;
            this.cbFilter.Text = "None";
            // 
            // cbSearchType
            // 
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            SocialNetworkConnection.SearchTypes.Mixed,
            SocialNetworkConnection.SearchTypes.Popular,
            SocialNetworkConnection.SearchTypes.Recent});
            this.cbSearchType.Location = new System.Drawing.Point(140, 221);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(121, 21);
            this.cbSearchType.TabIndex = 13;
            this.cbSearchType.Text = "Popular";
            // 
            // dtpSinceDate
            // 
            this.dtpSinceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSinceDate.Location = new System.Drawing.Point(124, 162);
            this.dtpSinceDate.Name = "dtpSinceDate";
            this.dtpSinceDate.Size = new System.Drawing.Size(121, 20);
            this.dtpSinceDate.TabIndex = 14;
            // 
            // dtpUntilDate
            // 
            this.dtpUntilDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUntilDate.Location = new System.Drawing.Point(124, 191);
            this.dtpUntilDate.Name = "dtpUntilDate";
            this.dtpUntilDate.Size = new System.Drawing.Size(121, 20);
            this.dtpUntilDate.TabIndex = 15;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(23, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(54, 20);
            this.lbName.TabIndex = 17;
            this.lbName.Text = "Nombre";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.UseCompatibleTextRendering = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 18;
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(23, 314);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(87, 23);
            this.btSave.TabIndex = 19;
            this.btSave.Text = "Guardar";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // countPublication
            // 
            this.countPublication.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.countPublication.Location = new System.Drawing.Point(191, 284);
            this.countPublication.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.countPublication.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.countPublication.Name = "countPublication";
            this.countPublication.Size = new System.Drawing.Size(81, 20);
            this.countPublication.TabIndex = 20;
            this.countPublication.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // txteo
            // 
            this.txteo.Location = new System.Drawing.Point(140, 251);
            this.txteo.Name = "txteo";
            this.txteo.Size = new System.Drawing.Size(100, 20);
            this.txteo.TabIndex = 21;
            // 
            // txtWordKey
            // 
            this.txtWordKey.Location = new System.Drawing.Point(126, 42);
            this.txtWordKey.Name = "txtWordKey";
            this.txtWordKey.Size = new System.Drawing.Size(100, 20);
            this.txtWordKey.TabIndex = 22;
            // 
            // CreateQueryConfigurationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 349);
            this.Controls.Add(this.txtWordKey);
            this.Controls.Add(this.txteo);
            this.Controls.Add(this.countPublication);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.dtpUntilDate);
            this.Controls.Add(this.dtpSinceDate);
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbGeo);
            this.Controls.Add(this.lbSearchType);
            this.Controls.Add(this.lbUntilDate);
            this.Controls.Add(this.lbSinceDate);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.lbKeyword);
            this.Name = "CreateQueryConfigurationViewer";
            this.Text = "CreateQueryConfigurationViewer";
            ((System.ComponentModel.ISupportInitialize)(this.countPublication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKeyword;
        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.Label lbSinceDate;
        private System.Windows.Forms.Label lbUntilDate;
        private System.Windows.Forms.Label lbSearchType;
        private System.Windows.Forms.Label lbGeo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.DateTimePicker dtpSinceDate;
        private System.Windows.Forms.DateTimePicker dtpUntilDate;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.NumericUpDown countPublication;
        private System.Windows.Forms.TextBox txteo;
        private System.Windows.Forms.TextBox txtWordKey;
    }
}