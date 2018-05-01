using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;


namespace MainFrame
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            InitializeControls();
            controller = new Controller.Controller("..//..//..//Database//LemmatizedPublications//Petro");
            ShowFormHome();

        }

        private void ShowFormHome()
        {

            containerPanel.Tag = home;
            home.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(2018, 3, 10);
            DateTime time2 = new DateTime(2018, 3, 28);
            DateTime time3 = new DateTime(2018, 3, 27);

            Dictionary<DateTime, double[]> dateAndCalification = controller.DailyAnalysis(time, time2);

            MessageBox.Show(time3.ToShortDateString() + "\n" + dateAndCalification[time3][0] + "\n" + dateAndCalification[time3][1]);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            webScrapperViewer = new View.WebScrapperViewer();
            webScrapperViewer.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowFormHome();
        }


        private void InitializeControls()
        {
            home = new HomePanel();
            home.Dock = DockStyle.Fill;
            home.TopLevel = false;
            containerPanel.Controls.Add(home);
        }
    }
}
