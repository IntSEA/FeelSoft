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

        public void SetMain(WebScrapperViewer main)
        {
            this.main = main;
        }

        internal void ShowPublications(IList<IPublication> publications)
        {
            if (publications == null)
            {
                MessageBox.Show("Not found publications");
            }
            else if (publications.Count == 0)
            {
                MessageBox.Show("NOt found publications");
            }
            else if (publications.Count > 0)
            {
                MessageBox.Show("Founded publications");
            }
            this.publications = publications.ToArray();
            this.views = publications.ToArray();
            SetDefaultViewConfigToPublications();
        }

        private void SetDefaultViewConfigToPublications()
        {
            indexCurrentViews = indexCurrentPublications;
            ShowPublication(indexCurrentViews);
            lblTotalPublications.Text = "Publicaciones : " + this.views.Length;
        }

        private void SetDefaultViewConfigToResponses()
        {
            indexCurrentViews = 0;
            ShowPublication(indexCurrentViews);
            lblTotalPublications.Text = "Publicaciones : " + this.views.Length;
        }

        private void ShowPublication(int indexCurrentPublication)
        {
            if (views.Length > 0)
            {
                IPublication publication = views.ElementAt(indexCurrentPublication);
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
            if (views != null)
            {
                if (indexCurrentViews + 1 < views.Length)
                {
                    ++indexCurrentViews;
                    ShowPublication(indexCurrentViews);
                }
            }
        }

        private void BtnBeforeClick(object sender, EventArgs e)
        {
            SetBeforePublication();

        }

        private void SetBeforePublication()
        {
            if (views != null)
            {
                if (indexCurrentViews - 1 >= 0)
                {
                    --indexCurrentViews;
                    ShowPublication(indexCurrentViews);
                }
            }
        }

        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            decimal indexValue = numericUpDown.Value;
            if (!TryShowPublicationInIndex(indexValue))
            {
                numericUpDown.Value = indexCurrentViews;
            }
        }

        private bool TryShowPublicationInIndex(decimal indexValue)
        {
            bool showed = indexValue <= views.Length && indexValue >= 0;

            if (showed)
            {
                indexCurrentViews = (int)indexValue - 1;
                ShowPublication(indexCurrentViews);
            }
            else
            {
                MessageBox.Show("Ingrese un dato valido, mayor a 1 y menor al total de publicaciones");
            }
            return showed;

        }

        private void BtnViewResponsesClick(object sender, EventArgs e)
        {
            if (views != responses)
            {
                views = responses;
                SetDefaultViewConfigToResponses();
                btnViewResponses.Text = "Publicaciones";

            }
            else
            {
                views = publications;
                SetDefaultViewConfigToPublications();
                btnViewResponses.Text = "Resuestas";

            }
        }

        internal IPublication[] GetPublications()
        {
            return publications;
        }

        private void BtnSavePublications_Click(object sender, EventArgs e)
        {
            main.SavePublications(this.views);
        }

        private void BtnImportPublications_Click(object sender, EventArgs e)
        {
            main.ImportPublications();
        }

        private void BtnExportPublications_Click(object sender, EventArgs e)
        {
            main.ExportPublications();
        }
    }
}
