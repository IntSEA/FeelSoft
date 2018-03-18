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
            QueryConfiguration configuration;

            facebook = new Facebook();


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
