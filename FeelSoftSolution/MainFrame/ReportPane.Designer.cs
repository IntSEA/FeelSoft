namespace MainFrame
{
    partial class ReportPane
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.wordsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sentence = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.failTraining = new System.Windows.Forms.Label();
            this.failDic = new System.Windows.Forms.Label();
            this.failT = new System.Windows.Forms.Label();
            this.failD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wordsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentence)).BeginInit();
            this.SuspendLayout();
            // 
            // wordsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.wordsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.wordsChart.Legends.Add(legend1);
            this.wordsChart.Location = new System.Drawing.Point(3, 39);
            this.wordsChart.Name = "wordsChart";
            this.wordsChart.Size = new System.Drawing.Size(421, 209);
            this.wordsChart.TabIndex = 0;
            this.wordsChart.Text = "Words";
            // 
            // sentence
            // 
            chartArea2.Name = "ChartArea1";
            this.sentence.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.sentence.Legends.Add(legend2);
            this.sentence.Location = new System.Drawing.Point(439, 39);
            this.sentence.Name = "sentence";
            this.sentence.Size = new System.Drawing.Size(401, 209);
            this.sentence.TabIndex = 1;
            this.sentence.Text = "sentence";
            // 
            // failTraining
            // 
            this.failTraining.AutoSize = true;
            this.failTraining.Location = new System.Drawing.Point(51, 279);
            this.failTraining.Name = "failTraining";
            this.failTraining.Size = new System.Drawing.Size(114, 13);
            this.failTraining.TabIndex = 2;
            this.failTraining.Tag = "";
            this.failTraining.Text = "Error de entrenamiento";
            // 
            // failDic
            // 
            this.failDic.AutoSize = true;
            this.failDic.Location = new System.Drawing.Point(51, 310);
            this.failDic.Name = "failDic";
            this.failDic.Size = new System.Drawing.Size(89, 13);
            this.failDic.TabIndex = 3;
            this.failDic.Text = "Error de decision ";
            // 
            // failT
            // 
            this.failT.AutoSize = true;
            this.failT.Location = new System.Drawing.Point(202, 279);
            this.failT.Name = "failT";
            this.failT.Size = new System.Drawing.Size(0, 13);
            this.failT.TabIndex = 4;
            // 
            // failD
            // 
            this.failD.AutoSize = true;
            this.failD.Location = new System.Drawing.Point(202, 310);
            this.failD.Name = "failD";
            this.failD.Size = new System.Drawing.Size(0, 13);
            this.failD.TabIndex = 5;
            // 
            // ReportPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.failD);
            this.Controls.Add(this.failT);
            this.Controls.Add(this.failDic);
            this.Controls.Add(this.failTraining);
            this.Controls.Add(this.sentence);
            this.Controls.Add(this.wordsChart);
            this.Name = "ReportPane";
            this.Size = new System.Drawing.Size(878, 391);
            ((System.ComponentModel.ISupportInitialize)(this.wordsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart wordsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart sentence;
        private Controller.Controller controller;
        private System.Windows.Forms.Label failTraining;
        private System.Windows.Forms.Label failDic;
        private System.Windows.Forms.Label failT;
        private System.Windows.Forms.Label failD;
    }
}
