using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using SocialNetworkConnection;

namespace View
{
    public partial class CreateQueryConfigurationViewer : Form
    {
        public CreateQueryConfigurationViewer()
        {
            InitializeComponent();
        }

        private IList extractData()
        {   
            // Return a ArrayList with data's queries configuraties in the next order:
            // 0. MaxPublication
            // 1. Name
            // 2. KeyWord List
            // 3.Lenguage
            // 4.Location
            // 5.Filter
            // 6.SinceDate
            // 7.UntilDate
            // 8.SearchType
            // 9. Geo

            IList configuritiesData = new ArrayList();
            IList<string> words = new List<string>();

            configuritiesData.Add(countPublication.Value);

            if (txtName.Text != "" && txtWordKey.Text != "")
            {
                configuritiesData.Add(txtName.Text);
                string[] wordS = txtWordKey.Text.Split(' ');
                
                words.CopyTo(wordS,0);
            }
            else
            {
                throw new Exception();
            }
            
            //TODO Add KeysWords
            configuritiesData.Add(words);
            configuritiesData.Add(cbLanguage.DataSource);
            configuritiesData.Add(cbLocation.DataSource);
            configuritiesData.Add(cbFilter.DataSource);
            configuritiesData.Add(dtpSinceDate.Value);
            configuritiesData.Add(dtpUntilDate.Value);
            configuritiesData.Add(cbSearchType.DataSource);
            configuritiesData.Add(lbGeo.Text);
            

            



            return configuritiesData;

        }

        private void btSave_Click(object sender, EventArgs e)
        {

            try
            {
                extractData();
            }
            catch
            {

            }
        }
    }


}
