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
using ViewQualifier;

namespace MainFrame
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            InitializeControls();
            ControllerPetro = new Controller.Controller("..//..//..//Database//LemmatizedPublications//Petro");
            ControllerFajardo = new Controller.Controller("..//..//..//Database//LemmatizedPublications//Fajardo");
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
            MessageBox.Show("Muy pronto");
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            webScrapperViewer = new View.WebScrapperViewer();
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
    }
}
