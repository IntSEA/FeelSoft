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
        IQueryConfiguration configuration;
        const string key = "EAACEdEose0cBAPzjHb7jfahDP0ZB7TaPer2qOC4os4aflj9cjF72tuZBtuz81zIMLwUUYDAOscuZCw4V8LX4pNG5wMdfkRnSdRddvY7xx2iT2ZBIKEV6TeqPub8ZBjfsfYAGmPi4AVzm8V41rgLK4uBN6vupbOeWaPte7bItmCL5xwjFlerZBgFdB9RL3UBEfwSmHybquRk5ZA3b8LZCEQPJ";

            facebook = new Facebook(key);

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

            publication = facebook.Search(configuration)[0];
            tbxPublication.Text = publication.Message;
        }
    }
}
