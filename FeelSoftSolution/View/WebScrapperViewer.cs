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
using System.IO;

namespace View
{
    public partial class WebScrapperViewer : Form
    {
        public WebScrapperViewer()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
           if( ReadCredentials(out string facebookCrendtials, out string twitterCredentials))
            {
                publicationViewerControl.InitializeSocialNetworks(facebookCrendtials, twitterCredentials);

            }
            else
            {
                MessageBox.Show("No se lograron cargar los credenciales, por favor integrelos e inicialice nuevamente la aplicación");
                this.Close();
            }
        }

        private bool ReadCredentials(out string facebookCrendtials, out string twitterCredentials)
        {
            ReadFacebookCredentials(out facebookCrendtials);
            ReadTwitterCredentials(out twitterCredentials);

            return !(String.IsNullOrEmpty(facebookCrendtials) || String.IsNullOrEmpty(twitterCredentials));
        }

        private void ReadTwitterCredentials(out string twitterCredentials)
        {
            StreamReader stream = new StreamReader(path: TWITTER_CREDENTIALS_PATH);
                        
            string consumerKey = stream.ReadLine();
            string consumerSecret = stream.ReadLine();
            string accessToken = stream.ReadLine();
            string secretToken = stream.ReadLine();

            stream.Close();
            twitterCredentials = consumerKey + "|" + consumerSecret + "|" + accessToken + "|" + secretToken;

        }

        private void ReadFacebookCredentials(out string facebookCrendtials)
        {
            StreamReader stream = new StreamReader(path: FACEBOOK_CREDENTIALS_PATH);
            facebookCrendtials = stream.ReadLine();
            stream.Close();
        }
    }
}
