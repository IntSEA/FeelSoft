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
            ParseTwitterCredentials(twitterCredentials,out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken);
            Auth.SetUserCredentials(consumerKey,consumerSecret,accessToken,secretToken);
            
            twitter = new Twitter(twitterCredentials);
            

        }

        private void ParseTwitterCredentials(string twitterCredentials,out string consumerKey, out string consumerSecret, out string accessToken, out string secretToken)
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
                facebook.Credential= Interaction.InputBox("Ingrese credenciales");
            }

            MakeQueryRequest();           

        }

        private void MakeQueryRequest()
        {
<<<<<<< HEAD
=======

        IPublication publication;
        ISocialNetwork facebook;
        IQueryConfiguration configuration;
        const string key = "EAACEdEose0cBAPzjHb7jfahDP0ZB7TaPer2qOC4os4aflj9cjF72tuZBtuz81zIMLwUUYDAOscuZCw4V8LX4pNG5wMdfkRnSdRddvY7xx2iT2ZBIKEV6TeqPub8ZBjfsfYAGmPi4AVzm8V41rgLK4uBN6vupbOeWaPte7bItmCL5xwjFlerZBgFdB9RL3UBEfwSmHybquRk5ZA3b8LZCEQPJ";

            facebook = new Facebook(key);
>>>>>>> c9ef4f1ebc7728c9a9caa97e8dcb13ad1c4ab9eb

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

<<<<<<< HEAD
            configurations.Add(currentConfiguration);


            ((List<IPublication>)publications).AddRange(facebook.Search(configurations));
=======
            publication = facebook.Search(configuration)[0];
            tbxPublication.Text = publication.Message;
>>>>>>> c9ef4f1ebc7728c9a9caa97e8dcb13ad1c4ab9eb
        }

        private void RdbTwitter_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
