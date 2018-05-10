using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainFrame
{
    public partial class Visualization : UserControl
    {
        public Visualization(MainFrame frame)
        {
            main = frame;
            InitializeComponent();

        }

        private void Visualization_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
             
        }

        public void loadGraphic()
        {
            

            DateTime startDate = dtpStart.Value;
            DateTime finishDate = dtpEnd.Value;
            Boolean PetroIsSelect = cbPetro.Checked;
            Boolean FajardoIsSelect = cbFajardo.Checked;

            Dictionary<DateTime, double[]> hashFajardo = main.ControllerFajardo.DailyAnalysis(startDate, finishDate);
            List<DateTime> time = hashFajardo.Keys.ToList();
            time.Sort();

            Dictionary<DateTime, double[]> hashPetro = main.ControllerPetro.DailyAnalysis(startDate, finishDate);
            List<DateTime> time2 = hashPetro.Keys.ToList();
            time2.Sort();


            if (FajardoIsSelect)
            {
                
                chart1.Series["Fajardo +"].Points.Clear();
                chart1.Series["Fajardo +"].ChartType = SeriesChartType.Line;
                chart1.Series["Fajardo +"].XValueType = ChartValueType.DateTime;

                chart1.Series["Fajardo -"].Points.Clear();
                chart1.Series["Fajardo -"].ChartType = SeriesChartType.Line;
                chart1.Series["Fajardo -"].XValueType = ChartValueType.DateTime;
                



                for (int i = 0; i < hashFajardo.Count; i++)

                {

                    chart1.Series["Fajardo +"].Points.AddXY(time[i], hashFajardo[time[i]][0]*100);
                    chart1.Series["Fajardo -"].Points.AddXY(time[i], hashFajardo[time[i]][1] * 100);
                   

                }
            }
            if (PetroIsSelect)
            {
                chart1.Series["Petro +"].Points.Clear();
                chart1.Series["Petro +"].ChartType = SeriesChartType.Line;
                chart1.Series["Petro +"].XValueType = ChartValueType.DateTime;

                chart1.Series["Petro -"].Points.Clear();
                chart1.Series["Petro -"].ChartType = SeriesChartType.Line;
                chart1.Series["Petro -"].XValueType = ChartValueType.DateTime;

                for (int i = 0; i < hashPetro.Count; i++)

                {
                    chart1.Series["Petro +"].Points.AddXY(time2[i], hashPetro[time2[i]][0] * 100);
                    chart1.Series["Petro -"].Points.AddXY(time2[i], hashPetro[time2[i]][1] * 100);

                }
            }

            this.chart1.GetToolTipText += this.chart1_GetToolTipText;

            
        }

       /* private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }*/

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Check selected chart element and set tooltip text for it
            switch (e.HitTestResult.ChartElementType)
            {
                
                case ChartElementType.DataPoint:
                    
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    e.Text = string.Format("X:\t{0}\nY:\t{1}", dataPoint.XValue, dataPoint.YValues[0]);
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            loadGraphic();
            
        }
    }
}
