using System;
using System.Collections.Generic;
using TextualProcessor;
using SocialNetworkConnection;
using System.Linq;
using Analytics;
using AnalyticDictionary;
using TwitterConnection;
using Tweetinvi;
using FacebookConnection;
using NaiveBayes;


namespace Controller
{
    public class Controller
    {
        
        private string path;
        private IProcessor processor;
        private DictionaryAn dictionaryAn;

        private INaiveBayes naive;
        private ISearchDataSet dataSet;
        private ISocialNetwork twitter;
        private ISocialNetwork facebook;

        public INaiveBayes Naive { get => naive; set => naive = value; }

        public Controller(string path)
        {
            this.path = path;
            processor = new Processor();
            dictionaryAn = new DictionaryAn();
            dataSet = new SearchDataSet();
            naive = new NaiveAnalytic();
            //InitializeFacebook();
            InitializeTwitter();
        }

        private void InitializeTwitter()
        {
            twitter = new Twitter();
            string consumerKey = System.Configuration.ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]; ;
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"];
            Tweetinvi.Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, secretToken);

        }

        private void InitializeFacebook()
        {
            facebook = new Facebook();
        }

        public void LoadPublications()
        {
            dataSet.BasePath = path;
            IList<IPublication> publications = dataSet.ImportDataset();
            dataSet.AddPublications(publications);
        }

        
        public void AutomaticSearch()
        {
            IList<string> words = new List<String>()
            {
                "Petro",
            };

            IQueryConfiguration configuration = new QueryConfiguration()
            {
                Keywords = words,
                Location = Locations.Colombia,
                Language = Languages.Spanish,
                Filter = Filters.None,
                SearchType = SearchTypes.Mixed,
                SinceDate = new DateTime(2018, 01, 1),
                UntilDate = DateTime.Now.AddDays(1),
                MaxPublicationCount = 5
            };

            IList<IPublication> publications = twitter.Search(configuration);
            dataSet.AddPublications(publications);
        }

        /**
         * Return pairs that contains specified days betweeen the dates 
         * and it s qualification for candidate;
         * 
         * */
        public Dictionary<DateTime,double[]> DailyAnalysis(DateTime firstDate, DateTime lastDate)

        {      
            LoadPublications();
            IList<IPublication> publicationsBetweenDates = new List<IPublication>();
            Dictionary<DateTime, double[]> dateAndCalification = new Dictionary<DateTime, double[]>();

            foreach (IPublication publication in dataSet.GetPublications())
            {
                if(BetweenDates(firstDate,lastDate, publication))
                {
                    publicationsBetweenDates.Add(publication);                   
                }
            }

            var groupsOfDates = publicationsBetweenDates.GroupBy(publica => publica.CreateDate);

            foreach(var group in groupsOfDates)
            {
                IList<string[]> toQualification = new List<string[]>();
                
                foreach(var publication in group)
                {
                    toQualification.Add(publication.LemmatizedMessage.Split(' '));
                }

                double[] favorAndDesfavor = dictionaryAn.DecidedSentences(toQualification);
                dateAndCalification.Add(group.Key, favorAndDesfavor);
            }


            return dateAndCalification;
        }

        

        private Boolean BetweenDates(DateTime firstDate, DateTime lastDate, IPublication publication)
        {
            bool betweenDates = false;

            if(publication.CreateDate.CompareTo(firstDate)>0 && publication.CreateDate.CompareTo(lastDate) < 0)
            {
                betweenDates = true;
            }
            return betweenDates;
        }
        public IDictionary<int,double> ReportWords(out int num)
        {
            IDictionary<string,int> words= naive.GetWordbank();
            IList<string> keys = words.Keys.ToList();
            num = keys.Count;
            IDictionary<int, IList<string>> ret = new Dictionary<int, IList<string>>();
            foreach(string tmp in keys)
            {
                words.TryGetValue(tmp, out int a);
                bool des=ret.TryGetValue(a,out IList<string> lis);
                if (des)
                {
                    lis.Add(tmp);

                }
                else
                {
                    lis = new List<string>();
                    lis.Add(tmp);
                    ret.Add(a,lis);
                }

            }
            IDictionary<int, double> retorno = new Dictionary<int, double>();
            IList<int> key = ret.Keys.ToList();

            foreach (int item in key)
            {
                ret.TryGetValue(item, out IList<string> lis);
                double value = (1.0 * lis.Count)/keys.Count;
                retorno.Add(item, value);
            }

            return retorno;
        }
        public IDictionary<int, double> ReportSentences(out int num)
        {
            int[] training = naive.DataTestOutputTrainig;
            num = training.Length;

            IDictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (int a in training)
            {
                int lis = 0;
                bool des = keyValuePairs.TryGetValue(a, out  lis);
                lis++;
                if (des)
                {
                    keyValuePairs[a] = lis;
                }
                else
                {
                    keyValuePairs.Add(a,lis);
                }

            }
            List<int> keys = keyValuePairs.Keys.ToList();
            IDictionary<int, double> retorno = new Dictionary<int,double>(); 
            foreach (int item in keys) 
            {
               
                retorno.Add(item, (1.0*keyValuePairs[item])/training.Length);
            }
            

            
            return retorno;
        }

    }
}
