using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SocialNetworkConnection;

namespace View
{
    public partial class QueryConfigurationControl : UserControl
    {
        public QueryConfigurationControl()
        {
            InitializeComponent();
        }

        private void BtnAddKeyword_Click(object sender, EventArgs e)
        {
            string keyword = Interaction.InputBox("Ingrese la palabra clave");
            
            if (String.IsNullOrEmpty(keyword) || String.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Ingrese una clave no vacia");
            }
            else
            {
                cbxKeywords.Items.Add(keyword);
                cbxKeywords.SelectedItem = cbxKeywords.Items.Count > 0 ? cbxKeywords.Items[0] : "";

            }

        }

        internal IQueryConfiguration GetQueryConfiguration()
        {

            if (queryConfiguration == null)
            {
                return CreateQueryConfiguration();
            }
            return queryConfiguration;
        }

        private IQueryConfiguration CreateQueryConfiguration()
        {
            
            queryConfiguration = new QueryConfiguration();
            AddKeyWords(queryConfiguration);
            AddLocation(queryConfiguration);
            AddSearchTypes(queryConfiguration);
            AddLanguajes(queryConfiguration);
            AddFilter(queryConfiguration);
            AddSinceDate(queryConfiguration);
            AddUntilDate(queryConfiguration);
            AddTotalSearches(queryConfiguration);


            return queryConfiguration;
        }

        private void AddTotalSearches(IQueryConfiguration queryConfiguration)
        {
            decimal value = nmudTotalPublications.Value;
            if(value>0 && value < 5000)
            {
                queryConfiguration.MaxPublicationCount = (int)value;
            }
            else
            {
                queryConfiguration.MaxPublicationCount = 100;

            }

        }

        private void AddSinceDate(IQueryConfiguration queryConfiguration)
        {
            queryConfiguration.SinceDate = dtpSinceDate.Value;
        }

        private void AddFilter(IQueryConfiguration queryConfiguration)
        {
            if (rdbVideo.Checked)
            {
                queryConfiguration.Filter = Filters.Video;
            }
            else if (rdbImage.Checked)
            {
                queryConfiguration.Filter = Filters.Image;
            }
            else if (rdbNews.Checked)
            {
                queryConfiguration.Filter = Filters.News;
            }
            else if (rdbHashtag.Checked)
            {
                queryConfiguration.Filter = Filters.Hashtag;
            }

        }

        private void AddLanguajes(IQueryConfiguration queryConfiguration)
        {
            if (rdbSpanish.Checked)
            {
                queryConfiguration.Language = Languages.Spanish;
            }
            else if (rdbEnglish.Checked)
            {
                queryConfiguration.Language = Languages.English;
            }
        }

        private void AddSearchTypes(IQueryConfiguration queryConfiguration)
        {
            if (rdbPopular.Checked)
            {
                queryConfiguration.SearchType = SearchTypes.Popular;
            }
            else if (rdbRecent.Checked)
            {
                queryConfiguration.SearchType = SearchTypes.Recent;
            }
            else if (rdbMixed.Checked)
            {
                queryConfiguration.SearchType = SearchTypes.Mixed;
            }
        }

        private void AddUntilDate(IQueryConfiguration queryConfiguration)
        {
            queryConfiguration.UntilDate = dtpUntilDate.Value;
        }

        private void AddLocation(IQueryConfiguration queryConfiguration)
        {
            if (rdbColombia.Checked)
            {
                queryConfiguration.Location = Locations.Colombia;
            }
            else if (rdbUsa.Checked)
            {
                queryConfiguration.Location = Locations.USA;
            }
        }

        private void AddKeyWords(IQueryConfiguration queryConfiguration)
        {
            IList<string> keywords = new List<string>();
            foreach (var item in cbxKeywords.Items)
            {
                if (item != null)
                {
                    keywords.Add(item.ToString());
                }
            }
            queryConfiguration.Keywords = keywords;
        }

        private void BtnRemoveKeyword_Click(object sender, EventArgs e)
        {
            object removedObject = cbxKeywords.SelectedItem;
            if (removedObject == null)
            {
                MessageBox.Show("Seleccione un elemento valido");
            }
            else
            {
                string removedKeyword = removedObject.ToString();

                if (String.IsNullOrEmpty(removedKeyword) || String.IsNullOrWhiteSpace(removedKeyword))
                {
                    MessageBox.Show("Seleccione un elemento valido");
                }
                else
                {
                    cbxKeywords.Items.Remove(removedKeyword);
                }
            }
            cbxKeywords.Text = "";
            cbxKeywords.SelectedItem =cbxKeywords.Items.Count>0 ?  cbxKeywords.Items[0] : "";
        }
    }
}
