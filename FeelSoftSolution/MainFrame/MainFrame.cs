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
using View;
using ViewQualifier;

namespace MainFrame
{
    public partial class MainFrame : Form, IScrapperHandler
    {
        public MainFrame()
        {
            InitializeComponent();
            InitializeControls();
            ControllerPetro = new Controller.Controller("..//..//..//Database//LemmatizedPublications//Petro");
            ControllerFajardo = new Controller.Controller("..//..//..//Database//LemmatizedPublications//Fajardo");
            report = new ReportPane(controllerFajardo);
            ShowFormHome();

        }

        private void ShowFormHome()
        {
            
            containerPanel.Tag = home;
            home.Show();
        }

        public void ShowFormVisualization()
        {
            visualization = new Visualization(this);
            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(visualization);
            containerPanel.Tag = visualization;
            visualization.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(report);
            containerPanel.Tag = report;
            report.Show();            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            webScrapperViewer = new WebScrapperViewer();
            webScrapperViewer.AddHandler(this);
            webScrapperViewer.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            
            containerPanel.Controls.Clear();
            InitializeControls();
            ShowFormHome();
        }


        private void InitializeControls()
        {
            home = new HomePanel(this);
            home.Dock = DockStyle.Fill;
            home.TopLevel = false;
            containerPanel.Controls.Add(home);
        }

        private void btnQualification_Click(object sender, EventArgs e)
        {
            viewQualifier = new Calificador();
            viewQualifier.Show();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void btnAdvances_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Muy pronto");
        }

        private void btnViewPublications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Muy pronto");
        }

        public void ExportEventHandler()
        {
            MessageBox.Show("Active Handler");
        }

        private void verticalMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void containerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
