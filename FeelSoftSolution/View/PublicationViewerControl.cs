using Microsoft.VisualBasic;
using SocialNetworkConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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
                MessageBox.Show("Found publications");
                this.publications = publications.ToArray();
                SetDefaultViewConfigToPublications();
            }

        }

        private void SetDefaultViewConfigToPublications()
        {
            ShowPublication(indexCurrentPublications);
            lblTotalPublications.Text = "Publicaciones : " + this.publications.Length;
        }


        private void ShowPublication(int indexCurrentPublication)
        {
            

            if (publications.Length > 0)
            {
                if (indexCurrentPublication < 0 || indexCurrentPublication > publications.Length)
                {
                    indexCurrentPublication = 0;
                }
                IPublication publication = publications.ElementAt(indexCurrentPublication);
                string id = publication.Id;
                string wroteBy = publication.WroteBy;
                string createDate = publication.CreateDate.ToShortDateString();
                string message = publication.Message;
                string location = publication.Location.ToString();
                string language = publication.Language.ToString();
                string info = id + "\r\n" + wroteBy + "\r\n" + createDate + "\r\n" + message + "\r\n" + location + "\r\n" + language + "\r\n";

                tbxPublication.Text = info;
                numericUpDown.Value = indexCurrentPublication + 1;

                bool isTwitter = IsTwitterPublication(publications[indexCurrentPublications]);
                ToEnableFullText(isTwitter);

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
                if (indexCurrentPublications + 1 < publications.Length)
                {
                    ++indexCurrentPublications;
                    ShowPublication(indexCurrentPublications);
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
                if (indexCurrentPublications - 1 >= 0)
                {
                    --indexCurrentPublications;
                    ShowPublication(indexCurrentPublications);
                }
            }
        }

        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            decimal indexValue = numericUpDown.Value;
            if (!TryShowPublicationInIndex(indexValue))
            {
                numericUpDown.Value = indexCurrentPublications;
            }
        }

        private bool TryShowPublicationInIndex(decimal indexValue)
        {
            bool showed = indexValue <= publications.Length && indexValue >= 0;

            if (showed)
            {
                indexCurrentPublications = (int)indexValue - 1;
                ShowPublication(indexCurrentPublications);
            }
            else
            {
                MessageBox.Show("Ingrese un dato valido, mayor a 1 y menor al total de publicaciones");
            }

            bool isTwitter = IsTwitterPublication(publications[indexCurrentPublications]);
            ToEnableFullText(showed && isTwitter);

            return showed;

        }

        private bool IsTwitterPublication(IPublication publication)
        {
            if (publication != null)
            {
                return Publication.IsTweet(publication);
            }
            return false;

        }

        private void ToEnableFullText(bool showed)
        {
            btnViewFullText.Visible = showed;
        }

        internal IPublication[] GetPublications()
        {
            return publications;
        }

        private void BtnSavePublications_Click(object sender, EventArgs e)
        {
            //AQUI
            main.SavePublications(this.publications);
        }

        private void BtnImportPublications_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                main.ImportPublications();

            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }



        private void BtnExportPublications_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea guardar las publicaciones por paquetes?", "Exportar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                string quantity = Interaction.InputBox("Ingrese cantidad");
                int.TryParse(quantity, out int q);

                main.ExportPublications(q);
            }
            else if (result == DialogResult.No)
            {
                main.ExportPublications(-1);
            }
        }

        private void BtnViewFullText_Click(object sender, EventArgs e)
        {

            Thread thread = new Thread(InitHtmlProcess(indexCurrentPublications));
            thread.Start();

        }

        private ThreadStart InitHtmlProcess(int indexCurrentPublications)
        {
            return () => { ReadHtmlInfo(indexCurrentPublications); };
        }

        private void ReadHtmlInfo(int i)
        {
            string strIdPublication = publications[i].Id.Split(':')[1];
            long idTweet = long.Parse(strIdPublication);
            publications[i].Message = Twitter.ReadHtmlContent(idTweet);
            RefreshViewer del = new RefreshViewer(RefreshTextBox);
            this.Invoke(del);
        }

        public delegate void RefreshViewer();

        public void RefreshTextBox()
        {
            ShowPublication(indexCurrentPublications);
        }

        private void BtnAddToGraph_Click(object sender, EventArgs e)
        {
            if (this.publications != null)
            {
                if (publications1 == null)
                {
                    publications1 = new List<IPublication>();
                    publications1.AddRange(this.publications);
                }
                else if (publications2 == null)
                {
                    publications2 = new List<IPublication>();
                    publications2.AddRange(this.publications);
                }
                else
                {
                    publications1 = new List<IPublication>();
                    publications1.AddRange(this.publications);
                    publications2 = null;
                }
            }
        }

        private void BtnViewGraph_Click(object sender, EventArgs e)
        {
            if (publications1 == null || publications2 == null)
            {
                MessageBox.Show("Primero debe agregar 2 listas al grafico");
            }
            else
            {
                if (publications1 != null && publications2 != null)
                {

                }
            }
        }
    }
}
