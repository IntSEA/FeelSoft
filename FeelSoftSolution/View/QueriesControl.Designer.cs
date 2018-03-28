using SocialNetworkConnection;
using System.Collections;
using System.Collections.Generic;

namespace View
{
    partial class QueriesControl
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
            this.btnInitSearch = new System.Windows.Forms.Button();
            this.gbxQueriesConfigurations = new System.Windows.Forms.GroupBox();
            this.btnExportQueryConfiguration = new System.Windows.Forms.Button();
            this.btnImportQueryConfiguration = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gbxQueries = new System.Windows.Forms.GroupBox();
            this.gbxQueriesConfigurations.SuspendLayout();
            this.gbxQueries.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxQueries
            // 
            this.cbxQueries.FormattingEnabled = true;
            this.cbxQueries.Location = new System.Drawing.Point(9, 41);
            this.cbxQueries.Name = "cbxQueries";
            this.cbxQueries.Size = new System.Drawing.Size(200, 21);
            this.cbxQueries.TabIndex = 0;
            this.cbxQueries.SelectedIndexChanged += new System.EventHandler(this.CbxQueries_SelectedIndexChanged);
            // 
            // btnCreateQuery
            // 
            this.btnCreateQuery.Location = new System.Drawing.Point(6, 68);
            this.btnCreateQuery.Name = "btnCreateQuery";
            this.btnCreateQuery.Size = new System.Drawing.Size(203, 30);
            this.btnCreateQuery.TabIndex = 1;
            this.btnCreateQuery.Text = "Crear configuración de busqueda";
            this.btnCreateQuery.UseVisualStyleBackColor = true;
            this.btnCreateQuery.Click += new System.EventHandler(this.BtnCreateQuery_Click);
            // 
            // lblConfigurations
            // 
            this.lblConfigurations.AutoSize = true;
            this.lblConfigurations.Location = new System.Drawing.Point(73, 25);
            this.lblConfigurations.Name = "lblConfigurations";
            this.lblConfigurations.Size = new System.Drawing.Size(83, 13);
            this.lblConfigurations.TabIndex = 2;
            this.lblConfigurations.Text = "Configuraciones";
            // 
            // btnInitSearch
            // 
            this.btnInitSearch.Location = new System.Drawing.Point(222, 70);
            this.btnInitSearch.Name = "btnInitSearch";
            this.btnInitSearch.Size = new System.Drawing.Size(98, 28);
            this.btnInitSearch.TabIndex = 9;
            this.btnInitSearch.Text = "Iniciar busqueda";
            this.btnInitSearch.UseVisualStyleBackColor = true;
            this.btnInitSearch.Click += new System.EventHandler(this.BtnInitSearchClick);
            // 
            // gbxQueriesConfigurations
            // 
            this.gbxQueriesConfigurations.Controls.Add(this.btnExportQueryConfiguration);
            this.gbxQueriesConfigurations.Controls.Add(this.btnImportQueryConfiguration);
            this.gbxQueriesConfigurations.Controls.Add(this.btnRemove);
            this.gbxQueriesConfigurations.Controls.Add(this.cbxQueries);
            this.gbxQueriesConfigurations.Controls.Add(this.lblConfigurations);
            this.gbxQueriesConfigurations.Controls.Add(this.btnCreateQuery);
            this.gbxQueriesConfigurations.Controls.Add(this.btnInitSearch);
            this.gbxQueriesConfigurations.Location = new System.Drawing.Point(31, 19);
            this.gbxQueriesConfigurations.Name = "gbxQueriesConfigurations";
            this.gbxQueriesConfigurations.Size = new System.Drawing.Size(330, 161);
            this.gbxQueriesConfigurations.TabIndex = 11;
            this.gbxQueriesConfigurations.TabStop = false;
            this.gbxQueriesConfigurations.Text = "Configuraciones de busqueda";
            // 
            // btnExportQueryConfiguration
            // 
            this.btnExportQueryConfiguration.Location = new System.Drawing.Point(179, 104);
            this.btnExportQueryConfiguration.Name = "btnExportQueryConfiguration";
            this.btnExportQueryConfiguration.Size = new System.Drawing.Size(141, 33);
            this.btnExportQueryConfiguration.TabIndex = 12;
            this.btnExportQueryConfiguration.Text = "Exportar configuraciones";
            this.btnExportQueryConfiguration.UseVisualStyleBackColor = true;
            this.btnExportQueryConfiguration.Click += new System.EventHandler(this.BtnExportQueryConfigurationClick);
            // 
            // btnImportQueryConfiguration
            // 
            this.btnImportQueryConfiguration.Location = new System.Drawing.Point(9, 104);
            this.btnImportQueryConfiguration.Name = "btnImportQueryConfiguration";
            this.btnImportQueryConfiguration.Size = new System.Drawing.Size(147, 33);
            this.btnImportQueryConfiguration.TabIndex = 11;
            this.btnImportQueryConfiguration.Text = "Importar configuraciónes";
            this.btnImportQueryConfiguration.UseVisualStyleBackColor = true;
            this.btnImportQueryConfiguration.Click += new System.EventHandler(this.BtnImportQueryConfigurationClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(223, 39);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // gbxQueries
            // 
            this.gbxQueries.Controls.Add(this.gbxQueriesConfigurations);
            this.gbxQueries.Location = new System.Drawing.Point(16, 12);
            this.gbxQueries.Name = "gbxQueries";
            this.gbxQueries.Size = new System.Drawing.Size(386, 190);
            this.gbxQueries.TabIndex = 13;
            this.gbxQueries.TabStop = false;
            this.gbxQueries.Text = "Control de configuraciones";
            // 
            // QueriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxQueries);
            this.Name = "QueriesControl";
            this.Size = new System.Drawing.Size(421, 215);
            this.gbxQueriesConfigurations.ResumeLayout(false);
            this.gbxQueriesConfigurations.PerformLayout();
            this.gbxQueries.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxQueries;
        private System.Windows.Forms.Button btnCreateQuery;
        private System.Windows.Forms.Label lblConfigurations;
        private System.Windows.Forms.Button btnInitSearch;
        private IList<IQueryConfiguration> configurations;
        private IQueryConfiguration currentConfiguration;
        private QueryConfigurationForm queryForm;
        private WebScrapperViewer main;
        private System.Windows.Forms.GroupBox gbxQueriesConfigurations;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox gbxQueries;
        private System.Windows.Forms.Button btnImportQueryConfiguration;
        private System.Windows.Forms.Button btnExportQueryConfiguration;
    }
}
