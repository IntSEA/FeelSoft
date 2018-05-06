using System;
using Qualifier;

namespace ViewQualifier
{
    partial class Calificador
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
            this.textRuta2 = new System.Windows.Forms.TextBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textCrudo = new System.Windows.Forms.RichTextBox();
            this.textProcesado = new System.Windows.Forms.RichTextBox();
            this.butExaminar2 = new System.Windows.Forms.Button();
            this.buExaminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butListo = new System.Windows.Forms.Button();
            this.textCalificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labContador = new System.Windows.Forms.Label();
            this.dataGridPalabras = new System.Windows.Forms.DataGridView();
            this.ColuPalabras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCalificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPalabras)).BeginInit();
            this.SuspendLayout();
            // 
            // textRuta2
            // 
            this.textRuta2.Location = new System.Drawing.Point(163, 21);
            this.textRuta2.Name = "textRuta2";
            this.textRuta2.Size = new System.Drawing.Size(100, 20);
            this.textRuta2.TabIndex = 0;
            this.textRuta2.TextChanged += new System.EventHandler(this.textRuta2_TextChanged);
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(163, 74);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(100, 20);
            this.textDireccion.TabIndex = 1;
            this.textDireccion.TextChanged += new System.EventHandler(this.textDireccion_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(392, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textCrudo
            // 
            this.textCrudo.Location = new System.Drawing.Point(12, 120);
            this.textCrudo.Name = "textCrudo";
            this.textCrudo.Size = new System.Drawing.Size(653, 96);
            this.textCrudo.TabIndex = 3;
            this.textCrudo.Text = "";
            this.textCrudo.TextChanged += new System.EventHandler(this.textCrudo_TextChanged);
            // 
            // textProcesado
            // 
            this.textProcesado.Location = new System.Drawing.Point(12, 222);
            this.textProcesado.Name = "textProcesado";
            this.textProcesado.Size = new System.Drawing.Size(653, 96);
            this.textProcesado.TabIndex = 4;
            this.textProcesado.Text = "";
            this.textProcesado.TextChanged += new System.EventHandler(this.textProcesado_TextChanged);
            // 
            // butExaminar2
            // 
            this.butExaminar2.Location = new System.Drawing.Point(279, 21);
            this.butExaminar2.Name = "butExaminar2";
            this.butExaminar2.Size = new System.Drawing.Size(75, 23);
            this.butExaminar2.TabIndex = 5;
            this.butExaminar2.Text = "Examinar";
            this.butExaminar2.UseVisualStyleBackColor = true;
            this.butExaminar2.Click += new System.EventHandler(this.butExaminar2_Click);
            // 
            // buExaminar
            // 
            this.buExaminar.Location = new System.Drawing.Point(279, 72);
            this.buExaminar.Name = "buExaminar";
            this.buExaminar.Size = new System.Drawing.Size(75, 23);
            this.buExaminar.TabIndex = 6;
            this.buExaminar.Text = "Examinar";
            this.buExaminar.UseVisualStyleBackColor = true;
            this.buExaminar.Click += new System.EventHandler(this.buExaminar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Examinar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butListo
            // 
            this.butListo.Location = new System.Drawing.Point(352, 496);
            this.butListo.Name = "butListo";
            this.butListo.Size = new System.Drawing.Size(75, 23);
            this.butListo.TabIndex = 8;
            this.butListo.Text = "LISTO";
            this.butListo.UseVisualStyleBackColor = true;
            this.butListo.Click += new System.EventHandler(this.butListo_Click);
            // 
            // textCalificacion
            // 
            this.textCalificacion.Location = new System.Drawing.Point(671, 120);
            this.textCalificacion.Name = "textCalificacion";
            this.textCalificacion.Size = new System.Drawing.Size(100, 20);
            this.textCalificacion.TabIndex = 9;
            this.textCalificacion.TextChanged += new System.EventHandler(this.textCalificacion_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cargar diccionario";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cargar parejas";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cargar frases calificadas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labContador
            // 
            this.labContador.AutoSize = true;
            this.labContador.Location = new System.Drawing.Point(364, 104);
            this.labContador.Name = "labContador";
            this.labContador.Size = new System.Drawing.Size(49, 13);
            this.labContador.TabIndex = 13;
            this.labContador.Text = "0 de 000";
            this.labContador.Click += new System.EventHandler(this.labContador_Click);
            // 
            // dataGridPalabras
            // 
            this.dataGridPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPalabras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColuPalabras,
            this.ColumnCalificacion});
            this.dataGridPalabras.Location = new System.Drawing.Point(271, 324);
            this.dataGridPalabras.Name = "dataGridPalabras";
            this.dataGridPalabras.Size = new System.Drawing.Size(279, 150);
            this.dataGridPalabras.TabIndex = 14;
            this.dataGridPalabras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPalabras_CellContentClick);
            // 
            // ColuPalabras
            // 
            this.ColuPalabras.HeaderText = "Palabras";
            this.ColuPalabras.Name = "ColuPalabras";
            // 
            // ColumnCalificacion
            // 
            this.ColumnCalificacion.HeaderText = "Calificacion";
            this.ColumnCalificacion.Name = "ColumnCalificacion";
            // 
            // Calificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.dataGridPalabras);
            this.Controls.Add(this.labContador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textCalificacion);
            this.Controls.Add(this.butListo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buExaminar);
            this.Controls.Add(this.butExaminar2);
            this.Controls.Add(this.textProcesado);
            this.Controls.Add(this.textCrudo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.textRuta2);
            this.Name = "Calificador";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPalabras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textDireccion_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textRuta2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textProcesado_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        #endregion
        private Clasificador clasificador;
        private System.Windows.Forms.TextBox textRuta2;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox textCrudo;
        private System.Windows.Forms.RichTextBox textProcesado;
        private System.Windows.Forms.Button butExaminar2;
        private System.Windows.Forms.Button buExaminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butListo;
        private System.Windows.Forms.TextBox textCalificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labContador;
        private System.Windows.Forms.DataGridView dataGridPalabras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColuPalabras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCalificacion;
    }
}

