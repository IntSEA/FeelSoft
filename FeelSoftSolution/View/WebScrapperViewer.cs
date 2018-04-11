using System;
using System.Windows.Forms;
using System.IO;
using Tweetinvi;
using SocialNetworkConnection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace View
{
    public partial class WebScrapperViewer : Form
    {
        public WebScrapperViewer()
        {
            InitializeComponent();
           // Show();
            InitializeSocialNetworks();

         
            //InitializeTests();

            IntializeControls();
        }

        private void IntializeControls()
        {
            queriesControl.SetMain(this);

        }

        private void InitializeSocialNetworks()
        {

            //InitializeFacebook();
            InitializeTwitter();


        }

        private void InitializeTwitter()
        {


            

            twitter = new TwitterConnection.Twitter();
            ParseTwitterCredentials(twitter.Credential, out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken);

        }

        private void ParseTwitterCredentials(string credential, out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken)
        {
            string[] info = credential.Split('|');
            consumerKey = info[0].Trim();
            consumerSecret = info[1].Trim();
            accessToken = info[2].Trim();
            secretToken = info[3].Trim();
            

            Auth.SetUserCredentials(consumerKey,consumerSecret,accessToken,secretToken);

        }

        internal async void Search(IQueryConfiguration queryConfiguration)
        {

            await Task.Run(()=>
            {
                IList<IPublication> publications = GetSelectedSocialNetwork().Search(queryConfiguration);

                ShowInPublicationViewer delegateMethod = new ShowInPublicationViewer(ShowPublicationsInPublicationViewer);
                this.Invoke(delegateMethod, publications);
            });
          
            
        }

        public delegate void ShowInPublicationViewer(IList<IPublication> publications);


        internal void ShowPublicationsInPublicationViewer(IList<IPublication> publications)
        {
            publicationViewerControl.ShowPublications(publications);

        }

        private ISocialNetwork GetSelectedSocialNetwork()
        {
            if (selectedSocialNetwork == FACEBOOK)
            {
                return facebook;
            }
            else if (selectedSocialNetwork == TWITTER)
            {
                return twitter;
            }
            else
            {
                return null;
            }
        }

        private async Task InitializeFacebook()
        {
            await Task.Run(() => facebook = new FacebookConnection.Facebook());
        }    

      

        private void RdbCheckedChanged(object sender, EventArgs e)
        {
            if(sender == rdbFacebook)
            {
                selectedSocialNetwork = FACEBOOK;
            }else if(sender == rdbTwitter)
            {
                selectedSocialNetwork = TWITTER;
            }
        }


    }
}
