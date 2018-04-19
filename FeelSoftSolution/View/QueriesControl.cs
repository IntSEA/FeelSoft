using SocialNetworkConnection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    public partial class QueriesControl : UserControl
    {
        public QueriesControl() : base()
        {
            InitializeComponent();
            InitializeDataContainers();

        }

        public void SetMain(WebScrapperViewer main)
        {
            this.main = main;
        }

        private void InitializeDataContainers()
        {
            configurations = new List<IQueryConfiguration>();
        }



        private void BtnInitSearchClick(object sender, EventArgs e)
        {
            MakeQueryRequest();
        }

        private void MakeQueryRequest()
        {

            main.Search(configurations);
        }


        private void BtnCreateQuery_Click(object sender, EventArgs e)
        {

            queryForm = new QueryConfigurationForm();
            DialogResult result = queryForm.ShowDialog();

            if (DialogResult.OK == result)
            {
                currentConfiguration = queryForm.GetQueryConfiguration();
                int index = configurations.FindLastIndex(x => x.Name.Equals(currentConfiguration));
                if (index != -1)
                {
                    configurations.RemoveAt(index);
                    configurations.Insert(index, currentConfiguration);

                }
                else
                {
                    configurations.Add(currentConfiguration);
                }

                cbxQueries.Items.Add(currentConfiguration);
                cbxQueries.SelectedItem = currentConfiguration;
            }

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveQueryConfiguration();

        }

        private void RemoveQueryConfiguration()
        {
            IQueryConfiguration removedObject = (IQueryConfiguration)cbxQueries.SelectedItem;
            if (removedObject != null)
            {
                cbxQueries.Items.Remove(removedObject);
                int index = configurations.FindLastIndex(x => x.Name.Equals(removedObject.Name));
                configurations.RemoveAt(index);
                MessageBox.Show(removedObject.ToString() + " was removed");
            }
            else
            {
                MessageBox.Show("Seleccione un elemento valido");
            }
        }

        private void CbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxQueries.SelectedItem != null)
            {
                currentConfiguration = (IQueryConfiguration)cbxQueries.SelectedItem;
            }
        }

        private void BtnImportQueryConfigurationClick(object sender, EventArgs e)
        {
            main.ImportQueryConfiguration();

        }

        public void AddQueryConfigurations(IQueryConfiguration queryConfiguration)
        {
            if (queryConfiguration != null)
            {
                cbxQueries.Items.Add(queryConfiguration);
                int index = configurations.FindLastIndex(x => x.Name.Equals(currentConfiguration));
                if (index != -1)
                {
                    configurations.RemoveAt(index);
                    configurations.Insert(index, currentConfiguration);

                }
                else
                {
                    configurations.Add(currentConfiguration);
                }

                cbxQueries.Text = queryConfiguration.Name;
            }
            else
            {
                cbxQueries.Text = "";
            }
        }

        private void BtnExportQueryConfigurationClick(object sender, EventArgs e)
        {
            if (currentConfiguration == null)
            {
                MessageBox.Show("Selecione una configuración de busqueda");
            }
            else
            {
                main.ExportQueryConfiguration(currentConfiguration);
            }
        }

        internal IQueryConfiguration GetCurrentQueryConfiguration()
        {
            if (currentConfiguration == null)
            {
                BtnCreateQuery_Click(btnCreateQuery, null);

            }
            return currentConfiguration;

        }

        private void ModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentConfiguration != null)
            {

                queryForm = new QueryConfigurationForm();
                queryForm.SetQueryConfiguration(currentConfiguration);
                DialogResult result = queryForm.ShowDialog();


                if (DialogResult.OK == result)
                {
                    currentConfiguration = queryForm.GetQueryConfiguration();
                    if (currentConfiguration.Name.Equals(((IQueryConfiguration)cbxQueries.SelectedItem).Name))
                    {
                        cbxQueries.Items.RemoveAt(cbxQueries.SelectedIndex);
                        cbxQueries.Items.Add(currentConfiguration);
                    }
                    int index = configurations.FindLastIndex(x => x.Name.Equals(currentConfiguration));
                    if (index != -1)
                    {
                        configurations.RemoveAt(index);
                        configurations.Insert(index, currentConfiguration);
                    }
                    else
                    {
                        configurations.Add(currentConfiguration);
                    }

                }

            }
            else
            {
                MessageBox.Show("Primero seleccione una configuración valida");
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentConfiguration != null)
            {
                cbxQueries.Items.Remove(currentConfiguration);
                cbxQueries.Text = "";
            }
            else
            {
                MessageBox.Show("Primero seleccione una configuración valida");
            }
        }
    }
}
