using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookConnection;
using SocialNetworkConnection;
using Microsoft.VisualBasic;
using TwitterConnection;
using Tweetinvi;

namespace View
{
    public partial class PublicationViewerControl : UserControl
    {
        public PublicationViewerControl()
        {
            InitializeComponent();
            InitializeDataContainers();

        }

        private void InitializeDataContainers()
        {
            publications = new List<IPublication>();
            configurations = new List<IQueryConfiguration>();
        }

        public void InitializeSocialNetworks(string facebookCredentials, string twitterCredentials)
        {
            InitializeFacebook(facebookCredentials);
            InitializeTwitter(twitterCredentials);
        }

        private void InitializeTwitter(string twitterCredentials)
        {
            ParseTwitterCredentials(twitterCredentials, out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken);
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, secretToken);

            twitter = new Twitter(twitterCredentials);


        }

        private void ParseTwitterCredentials(string twitterCredentials, out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken)
        {
            string[] keys = twitterCredentials.Split('|');
            consumerKey = keys[0];
            consumerSecret = keys[1];
            accessToken = keys[2];
            secretToken = keys[3];
        }

        private void InitializeFacebook(string facebookCredentials)
        {
            facebook = new Facebook(facebookCredentials);
        }

        private void BtnAcceptClick(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(facebook.Credential))
            {
                facebook.Credential = Interaction.InputBox("Ingrese credenciales");
            }

            MakeQueryRequest();

        }

        private void MakeQueryRequest()
        {    


            IList<string> words = new List<String>()
            {
                "GustavoPetroUrrego",
            };

            currentConfiguration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 03, 12),
                UntilDate = new DateTime(2018, 03, 15),
                MaxPublicationCount = 10


            };


            configurations.Add(currentConfiguration);


            ((List<IPublication>)publications).AddRange(facebook.Search(configurations));

            IPublication publication = publications[0];
            tbxPublication.Text = publication.Message;
        }

        private void RdCheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
