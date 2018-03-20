using System;
using System.Windows.Forms;
using System.IO;
using Tweetinvi;
using SocialNetworkConnection;

namespace View
{
    public partial class WebScrapperViewer : Form
    {
        public WebScrapperViewer()
        {
            InitializeComponent();
            InitializeSocialNetworks();
            //InitializeTests();
        }

        private void InitializeSocialNetworks()
        {

            InitializeFacebook();
            InitializeTwitter();


        }

        private void InitializeTwitter()
        {


            twitter = new TwitterConnection.Twitter();
            //FALTA AUTENTICAR CON TWITTER CREDENTIALS (el metodo AUTH:SETUSER())

        }

        internal void Search(IQueryConfiguration currentConfiguration)
        {
            throw new NotImplementedException();
        }

        private void ParseTwitterCredentials(string[] twitterCredentials, out string twitterCredential)
        {
            twitterCredential = "";
            for (int i = 0; i < twitterCredentials.Length - 1; i++)
            {
                twitterCredential += twitterCredentials[i] + "|";

            }
            twitterCredential += twitterCredentials[twitterCredentials.Length - 1];
        }

        private void InitializeFacebook()
        {
            facebook = new FacebookConnection.Facebook();
        }


<<<<<<< HEAD

        private bool ReadCredentials(out string facebookCrendtials, out string[] twitterCredentials)
        {
            ReadFacebookCredentials(out facebookCrendtials);
            ReadTwitterCredentials(out twitterCredentials);

            return (String.IsNullOrEmpty(facebookCrendtials) || twitterCredentials.Length > 0);
        }

        private void ReadTwitterCredentials(out string[] twitterCredentials)
        {
            StreamReader stream = new StreamReader(path: TWITTER_CREDENTIALS_PATH);
            twitterCredentials = new string[4];
            twitterCredentials[0] = stream.ReadLine();
            twitterCredentials[1] = stream.ReadLine();
            twitterCredentials[2] = stream.ReadLine();
            twitterCredentials[3] = stream.ReadLine();

            stream.Close();

        }

        private void ReadFacebookCredentials(out string facebookCrendtials)
        {
            StreamReader stream = new StreamReader(path: FACEBOOK_CREDENTIALS_PATH);
            facebookCrendtials = stream.ReadLine();
            stream.Close();
        }

=======
>>>>>>> 88f9f86edc99ac0df7603ae71d9cdc586dfde4c2
        private void RdbCheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
