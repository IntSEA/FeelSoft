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
using TwitterConnection;

namespace View
{
    public partial class PublicationViewerControl : UserControl
    {
        public PublicationViewerControl()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        IPublication publication;
        ISocialNetwork facebook;
        ISocialNetwork twitter;
        IQueryConfiguration configuration;
        const string key = "EAACEdEose0cBAPzjHb7jfahDP0ZB7TaPer2qOC4os4aflj9cjF72tuZBtuz81zIMLwUUYDAOscuZCw4V8LX4pNG5wMdfkRnSdRddvY7xx2iT2ZBIKEV6TeqPub8ZBjfsfYAGmPi4AVzm8V41rgLK4uBN6vupbOeWaPte7bItmCL5xwjFlerZBgFdB9RL3UBEfwSmHybquRk5ZA3b8LZCEQPJ";

            facebook = new Facebook(key);
            twitter = new Twitter("3vs8cBTP4ON4xwEZsS6Yvl9xG", "WrGPZdyLy4naOir1RawS1nRc9AjNASNSmFQEtgorlAl3vvCnMh", "974033487266271233-UPAOdI0rPS1TjK5FR5VJMJsD4dBselw", "n0rfufLN4hqgzJ0OimJvM5wYaykQ2wmAyHAjUOoDuNWOc");

            IList<string> words = new List<String>()
            {
                "GustavoPetroUrrego",
            };

            configuration = new QueryConfiguration()
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
            publication = twitter.Search(configuration)[0];
           // publication = facebook.Search(configuration)[0];
            tbxPublication.Text = publication.Message;
        }

        private void btnCreateQuery_Click(object sender, EventArgs e)
        {
            CreateQueryConfigurationViewer createQueryConfigurationViewer = new CreateQueryConfigurationViewer();
            createQueryConfigurationViewer.ShowDialog();
        }
    }
}
