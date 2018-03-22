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

        internal void ShowPublications(IList<IPublication> publications)
        {
            this.publications = publications.ToArray();
            indexCurrentPublication = 0;
            ShowPublication(indexCurrentPublication);
            lblTotalPublications.Text = "Publicaciones : " + publications.Count;
        }

        private void ShowPublication(int indexCurrentPublication)
        {
            if (publications.Length > 0)
            {
                IPublication publication = publications.ElementAt(indexCurrentPublication);
                string id = publication.Id;
                string wroteBy = publication.WroteBy;
                string createDate = publication.CreateDate.ToShortDateString();
                string message = publication.Message;
                string location = publication.Location.ToString();
                string language = publication.Language.ToString();
                string favorability = publication.Favorability.ToString();
                string info = id + "\r\n" + wroteBy + "\r\n" + createDate + "\r\n" + message + "\r\n" + location + "\r\n" + language + "\r\n" + favorability;

                tbxPublication.Text = info;
                numericUpDown.Value = indexCurrentPublication + 1;
            }
        }

        private void BtnNextClick(object sender, EventArgs e)
        {
            SetNextPublication();

        }

        private void SetNextPublication()
        {
            if (publications != null)
            {
                if (indexCurrentPublication + 1 < publications.Length)
                {
                    ++indexCurrentPublication;
                    ShowPublication(indexCurrentPublication);
                }
            }
        }

        private void BtnBeforeClick(object sender, EventArgs e)
        {
            SetBeforePublication();

        }

        private void SetBeforePublication()
        {
            if (publications != null)
            {
                if (indexCurrentPublication - 1 >= 0)
                {
                    --indexCurrentPublication;
                    ShowPublication(indexCurrentPublication);
                }
            }
        }

        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            decimal indexValue = numericUpDown.Value;
            if (!TryShowPublicationInIndex(indexValue))
            {
                numericUpDown.Value = indexCurrentPublication;
            }
        }

        private bool TryShowPublicationInIndex(decimal indexValue)
        {
            bool showed = indexValue <= publications.Length && indexValue>=0;
            
            if (showed)
            {
                indexCurrentPublication = (int)indexValue-1;
                ShowPublication(indexCurrentPublication);
            }
            else
            {
                MessageBox.Show("Ingrese un dato valido, mayor a 1 y menor al total de publicaciones");
            }
            return showed;
            
        }
    }
}
