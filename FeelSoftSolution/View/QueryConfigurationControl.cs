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
using System.IO;
using System.Threading;
using static System.Windows.Forms.ComboBox;

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
                AddKeywordToCBX(keyword);
               

            }

        }

        private delegate void AddKeywordToCBXDelegate(string keyword);

        private void AddKeywordToCBX(string keyword)
        {
            cbxKeywords.Items.Add(keyword);
            cbxKeywords.SelectedItem = cbxKeywords.Items.Count > 0 ? cbxKeywords.Items[0] : "";
        }

        internal void SetQueryConfiguration(IQueryConfiguration queryConfiguration)
        {
            SetName(queryConfiguration.Name);
            SetKeywords(queryConfiguration.Keywords.ToArray());
            SetLocation(queryConfiguration.Location);
            SetSearchType(queryConfiguration.SearchType);
            SetLanguage(queryConfiguration.Language);
            SetFilter(queryConfiguration.Filter);
            SetSinceDate(queryConfiguration.SinceDate);
            SetUntilDate(queryConfiguration.UntilDate);
            SetTotalPublicationsToSearch(queryConfiguration.MaxPublicationCount);
            SetTotalResponsesInPublication(queryConfiguration.MaxResponsesCount);
      
        }

        private void SetName(string name)
        {
            tbxName.Text = name;
        }

        private void SetTotalResponsesInPublication(int maxResponsesCount)
        {
            nudTotalResponses.Value = maxResponsesCount;
        }

        private void SetTotalPublicationsToSearch(int maxPublicationCount)
        {
            nudTotalPublications.Value = maxPublicationCount;
        }

        private void SetUntilDate(DateTime untilDate)
        {
            dtpUntilDate.Value = untilDate;
        }

        private void SetSinceDate(DateTime sinceDate)
        {
            dtpSinceDate.Value = sinceDate;
        }

        private void SetFilter(Filters filter)
        {
            switch (filter)
            {
                case Filters.None:
                    {
                        rdbNone.Checked = true;
                        break;
                    }
                case Filters.Video:
                    {
                        rdbVideo.Checked = true;
                        break;
                    }
                case Filters.Image:
                    {
                        rdbImage.Checked=true;
                        break;
                    }
                case Filters.News:
                    {
                        rdbNews.Checked = true;
                        break;
                    }
                case Filters.Hashtag:
                    {
                        rdbHashtag.Checked = true;
                        break;
                    }
            }
        }

        private void SetLanguage(Languages language)
        {
            switch (language)
            {
                case Languages.Spanish:
                    {
                        rdbSpanish.Checked = true;
                        break;
                    }
                case Languages.English:
                    {
                        rdbEnglish.Checked = true;
                        break;
                    }
            }
        }

        private void SetSearchType(SearchTypes searchType)
        {
            switch (searchType)
            {
                case SearchTypes.Mixed:
                    {
                        rdbMixed.Checked = true;
                        break;
                    }
                case SearchTypes.Popular:
                    {
                        rdbPopular.Checked = true;
                        break;
                    }
                case SearchTypes.Recent:
                    {
                        rdbRecent.Checked = true;
                        break;
                    }
            }
        }

        private void SetLocation(Locations location)
        {
            switch (location)
            {
                case Locations.Colombia:
                    {
                        rdbColombia.Checked = true;
                        break;
                    }
                case Locations.USA:
                    {
                        rdbUsa.Checked = true;
                        break;
                    }

            }
        }

        private void SetKeywords(string[] keywords)
        {
            cbxKeywords.Items.Clear();
            cbxKeywords.Items.AddRange(keywords);

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
            AddName(queryConfiguration);
            AddKeywords(queryConfiguration);
            AddLocation(queryConfiguration);
            AddSearchTypes(queryConfiguration);
            AddLanguajes(queryConfiguration);
            AddFilter(queryConfiguration);
            AddSinceDate(queryConfiguration);
            AddUntilDate(queryConfiguration);
            AddTotalSearches(queryConfiguration);
            AddTotalResponses(queryConfiguration);

            return queryConfiguration;
        }

        private void AddName(IQueryConfiguration queryConfiguration)
        {
            queryConfiguration.Name = tbxName.Text;
        }

        private void AddTotalResponses(IQueryConfiguration queryConfiguration)
        {
            queryConfiguration.MaxResponsesCount = (int)nudTotalResponses.Value;
        }

        private void AddTotalSearches(IQueryConfiguration queryConfiguration)
        {
            decimal value = nudTotalPublications.Value;
            if (value > 0 && value <= 10000)
            {
                queryConfiguration.MaxPublicationCount = (int)value;
            }
            else
            {
                queryConfiguration.MaxPublicationCount = 2000;

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

        private void AddKeywords(IQueryConfiguration queryConfiguration)
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
            cbxKeywords.SelectedItem = cbxKeywords.Items.Count > 0 ? cbxKeywords.Items[0] : "";
        }

      

        private void BtnExportQueryConfiguration_Click(object sender, EventArgs e)
        {
            GetQueryConfiguration();

        }

        private void BtnImportClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(OpenDialogInThread());
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            
        }

        private ThreadStart OpenDialogInThread()
        {
            return () => { ShowOpenDialog(); };
        }

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        private async void ShowOpenDialog()
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (DialogResult.OK == openDialog.ShowDialog())
            {
                StreamReader sr = new StreamReader(openDialog.OpenFile());
                string keyword = "";
                AddKeywordToCBXDelegate delegateMethod = new AddKeywordToCBXDelegate(AddKeywordToCBX);
                while ((keyword = sr.ReadLine()) != null)
                {
                    this.Invoke(delegateMethod,keyword);
                }

                sr.Close();
            }
        }

       
    }
}
