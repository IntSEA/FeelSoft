using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Tweetinvi;
using Tweetinvi.Models;

namespace SocialNetworkConnection
{
    public class SearchDataSet : ISearchDataSet
    {
        HtmlDocument doc = new HtmlDocument();
        WebClient client = new WebClient();
        private string basePath;
        string baseName;
        int suffixName;
        int totalPublications;
        private IDictionary<string, IPublication> publications;
        private IDictionary<string, IQueryConfiguration> queriesConfigurations;

        public IDictionary<string, IPublication> Publications { get => publications; set => publications = value; }
        public IDictionary<string, IQueryConfiguration> QueriesConfigurations { get => queriesConfigurations; set => queriesConfigurations = value; }
        public string BasePath { get => basePath; set => basePath = value; }
        public int TotalPublications { get => totalPublications; set => totalPublications = value; }

        public SearchDataSet()
        {
            publications = new Dictionary<string, IPublication>();
            queriesConfigurations = new Dictionary<string, IQueryConfiguration>();
            BasePath = "..//..//..//SocialNetworkConnection/Resources/SocialNetworks/";
            baseName = "DataSet";
            suffixName = 1;

        }

        public void AddPublications(IList<IPublication> publications)
        {
            Thread thread = new Thread(ThreadStartSavePublications(publications));
            thread.Start();

            Thread waitThread = new Thread(Wait(thread));
            waitThread.Start();
            while (waitThread.IsAlive)
            {
                Thread.Sleep(500);
            }

        }

        private ThreadStart Wait(Thread thread)
        {
            return () =>
            {
                while (thread.IsAlive)
                {
                    Thread.Sleep(500);
                }
            };
        }

        private ThreadStart ThreadStartSavePublications(IList<IPublication> publications)
        {
            return () => { SavePublications(publications); };
        }

        private void SavePublications(IList<IPublication> publications)
        {
            if (publications != null)
            {
                foreach (var publication in publications)
                {
                    AddPublications(publication);
                }
            }
        }

        public void ExportDataSet()
        {
            int totalThreads = publications.Values.Count / 1000;
            int init = 0;
            for (int i = 0; i < totalThreads; i++)
            {
                Thread thread = new Thread(ThreadStartExport(init, BasePath + baseName + suffixName + ".dst"));
                thread.Start();
                suffixName++;
                init += 1000;
            }


        }

        private ThreadStart ThreadStartExport(int init, string path)
        {
            return () => { Export(init, path); };
        }

        private void Export(int init, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = init; i < init + 1000 && i < TotalPublications; i++)
            {
                IPublication publication = GetPublicationInIndex(i);
                sw.WriteLine(publication.ToExportFormat());
            }

            sw.Close();

        }

        public IPublication[] ImportDataSet(string directoryPath)
        {

            string[] paths = Directory.GetFiles(directoryPath);
            List<IPublication> publications = new List<IPublication>();
            IList<Thread> threads = new List<Thread>();

            //Thread thread = new Thread(ImportFileAsync(paths[0]));
            //thread.Start();
            //threads.Add(thread);
            foreach (var path in paths)
            {
                if (File.Exists(path))
                {

                    Thread thread = new Thread(ImportFileAsync(path, publications));
                    thread.Start();
                    threads.Add(thread);
                }

            }

            WaitThreads(threads);

            return publications.ToArray();
        }


        private void WaitThreads(IList<Thread> threads)
        {
            while (threads.Count > 0)
            {
                if (threads.ElementAt(0).IsAlive)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    threads.RemoveAt(0);
                }
            }
        }

        private ThreadStart ImportFileAsync(string path, List<IPublication> publications)
        {
            return () => { ImportFile(path, publications); };
        }
        private void ImportFile(string path, List<IPublication> publications)
        {
            StreamReader sr = new StreamReader(path);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                while (!line.Contains(Publication.END_LINE))
                {
                    line += sr.ReadLine();
                }
                IPublication parsedPublication = Publication.ParsePublication(line);
                lock (this)
                {
                    publications.Add(parsedPublication);
                }


            }
            sr.Close();

        }



        public IPublication[] ImportDataset()
        {
            return ImportDataSet(basePath);
        }

        private IPublication GetPublicationInIndex(int i)
        {
            lock (this)
            {
                return publications.Values.ElementAt(i);

            }
        }

        private IPublication GetPublication(string id, string line, IPublication publication)
        {

            lock (this)
            {
                if (publications.TryGetValue(id, out IPublication pub))
                {
                    return pub;
                }
                return null;
            }
        }

        public void AddPublications(IPublication publication)
        {
            lock (this)
            {
                string id = publication.Id;
                if (!(publications.TryGetValue(id, out IPublication saved)))
                {
                    if (saved != null)
                    {
                        throw new ArgumentException("Problem in dictionary, found a no exist publication");
                    }
                    publications.Add(id, publication);
                    TotalPublications++;
                }
            }
        }

        public void AddQueriesConfigurations(IList<IQueryConfiguration> queriesConfigurations)
        {
            if (queriesConfigurations != null)
            {
                foreach (var queryConfig in queriesConfigurations)
                {
                    AddQueriesConfigurations(queryConfig);
                }
            }
        }

        public void AddQueriesConfigurations(IQueryConfiguration queryConfiguration)
        {
            string name = queryConfiguration.Name;
            if (!(this.publications.TryGetValue(name, out IPublication saved)))
            {
                if (saved != null)
                {
                    throw new ArgumentException("Problem in dictionary, found a no exist publication");
                }
                this.queriesConfigurations.Add(name, queryConfiguration);
            }
        }

        public IPublication[] GetPublications()
        {
            return publications.Values.ToArray();
        }
    }
}