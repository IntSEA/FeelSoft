using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitTestProject;

namespace View
{
    public partial class WebScrapperViewer : Form
    {
        public WebScrapperViewer()
        {
            InitializeComponent();
          //  InitializeTests();
        }

        private void InitializeTests()
        {
            SocialNetworkUnitTest a = new SocialNetworkUnitTest();
            
            
        }
    }
}
