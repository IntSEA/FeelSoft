using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetworkConnection;

namespace View
{
    public partial class QueryConfigurationForm : Form
    {
        public QueryConfigurationForm()
        {
            InitializeComponent();
            
        }

        internal IQueryConfiguration GetQueryConfiguration()
        {
            return queryConfigurationControl.GetQueryConfiguration();
        }

        private void BtnCreateQueryConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void SetQueryConfiguration(IQueryConfiguration queryConfiguration)
        {
            queryConfigurationControl.SetQueryConfiguration(queryConfiguration);
        }
    }
}
