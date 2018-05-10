using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;



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
        public string BaseName { get => baseName; set => baseName = value; }

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

        public void ExportDataSet(int quantity)
        {
            if (quantity > 0)
            {
                int totalThreads = publications.Values.Count / quantity;
                int init = 0;
                for (int i = 0; i < totalThreads; i++)
                {
                    Thread thread = new Thread(ThreadStartExport(init, quantity, BasePath + baseName + suffixName + ".dst"));
                    thread.Start();
                    suffixName++;
                    init += quantity;
                }
            }
            else
            {
                ExportDataSet();
            }


        }

        public void ExportDataSet()
        {
            Thread thread = new Thread(ThreadStartExport(0, totalPublications, BasePath + baseName + ".dst"));
            thread.Start();

        }

        private ThreadStart ThreadStartExport(int init, int quantity, string path)
        {
            return () => { Export(init, quantity, path); };
        }

        private void Export(int init, int quantity, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("ID|WroteBy|CreateDate|Message|Language|Language|Location|ConfigurationName|LemmatizedMessage|" + Publication.END_LINE);
            for (int i = init; i < init + quantity && i < TotalPublications; i++)
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
            while (!line.Contains(Publication.END_LINE))
            {
                line += sr.ReadLine();
            }

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

        public bool TranslateFromOldVersion(string directoryPath,IList<IQueryConfiguration> queryFilter,int version){
        
            bool response = true;
            string[] paths = Directory.GetFiles(directoryPath);
            IList<IPublication> publications = new List<IPublication>();
            IList<Thread> threads = new List<Thread>();

            
            foreach (var path in paths)
            {
                if (File.Exists(path))
                {
                    try{
                    
                     response = true;
                     Thread thread = new Thread(TranslateAsync(path, publications,queryFilter,version));
                     thread.Start();
                     threads.Add(thread);
                    }catch(ArgumentException){
                       response = false;
                       
                    }
                }

            }

            WaitThreads(threads);
            return response;
        
        }
        
        private ThreadStart TranslateAsync(string path, IList<IPublication> publications,IList<IQueryConfiguration> queryFilter,int version){
            return ()=> {Translate(path,publications,queryFilter,version);};
        }
        
        public void Translate(string path, IList<IPublication> publications,IList<IQueryConfiguration> queryFilter,int version){
            if(version ==0){
                TranslateFrom0Version(path,publications,queryFilter);
            }else{
                throw new Exception("TranslateFromVersion: "+version+" is not available");
            }
        }
        
        private void TranslateFrom0Version(string path, IList<IPublication> publications, IList<IQueryConfiguration> queryFilter){
            StreamReader sr = new StreamReader(path);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                while (!line.Contains(Publication.END_LINE))
                {
                    line += sr.ReadLine();
                }

                IPublication parsedPublication = ParsePublicationFrom0Version(line, queryFilter);
                lock (this)
                {
                    publications.Add(parsedPublication);
                }


            }
            sr.Close();
        }
        
        private IPublication ParsePublicationFrom0Version(string line, IList<IQueryConfiguration> queryFilter){
            string[] info = line.Split('|');
            if(info.Length<6){
                throw new ArgumentException("Non Date");
            }
            string id = info[0];
            string wroteBy = info[1];
            DateTime createdDate = QueryConfiguration.NONE_DATE;
            
            //ParseDate include THE BAYRON'S PROBLEM
            if(!DateTime.TryParse(info[2],out createdDate))
                {
                    string[] dates = info[2].Split('/');
                    string zero = "";
                    string zero2 = "";
                    if (Convert.ToInt32(dates[1]) < 10)
                    {
                        zero = "0";
                    }
                    if (Convert.ToInt32(dates[0]) < 10)
                    {
                        zero2 = "0";
                    }
                    string newDate = zero + dates[1] + "/" + zero2 + dates[0] + "/" + dates[2];
                    
                    if(!DateTime.TryParse(newDate, out createdDate)){
                        throw new ArgumentException("Non Date");
                    }
                }
                
            string message = info[3];
            Languages language = QueryConfiguration.ParseLanguage(info[4]);
            Locations location = QueryConfiguration.ParseLocation(info[5]);
            string configurationName = GetConfigurationName(message,queryFilter);
            
            
            IPublication publication = new Publication
            {
                Id = id,
                WroteBy = wroteBy,
                CreateDate = createdDate,
                Message = message,
                Language = language,
                Location = location,
                ConfigurationName = configurationName,
                LemmatizedMessage = "Not yet lemmatized"
            };
            
            return publication;
        }
        
        private string GetConfigurationName(string message, IList<IQueryConfiguration> queryFilter){
            string configurationName = "Not found";
            if(queryFilter!=null){
                var query = queryFilter.First(x=>IsMatch(message,x));
                if(query!=null){
                   configurationName = query.Name;
                }
            }
            return configurationName;
        }
        
        private bool IsMatch(string message,IQueryConfiguration queryConfiguration){
            bool isMatch = false;
            if(queryConfiguration!=null){
            
                if(queryConfiguration.Keywords!=null && queryConfiguration.Keywords.Any(x=> CreateRegularExpresion(x).IsMatch(message))){
                    isMatch = true;
                }
            }
            
            return isMatch;
        }
        
        public bool TranslateFromOldVersion(string directoryPath, IList<IQueryConfiguration> queryFilter){
        
           return TranslateFromOldVersion(directoryPath, queryFilter,0);
        
        }
        
        private Regex CreateRegularExpresion(string word)
        {
            string upperCasePattern = @"[\s|\W|]" + word.ToUpper() + @"+\w?\b";
            string lowerCasePattern = @"[\s|\W|]" + word.ToLower() + @"+\w?\b";
            string normalCasePattern = @"[\s|\W|]" + word + @"+\w?\b";
            return new Regex(normalCasePattern + "|" + lowerCasePattern + "|" + upperCasePattern);
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

        public IList<IPublication> GetPublications()
        {
            IList<IPublication> publications = this.publications.Values.ToList();
            return publications;
        }

        public void AddOrReplacePublications(IList<IPublication> publications)
        {
            for (int i = 0; i < Publications.Count; i++)
            {
                if (this.publications.TryGetValue(publications[i].Id, out IPublication value))
                {
                    this.publications[publications[i].Id] = publications[i];
                }
                else
                {
                    this.publications.Add(publications[i].Id, publications[i]);
                }
            }
        }
    }
}
