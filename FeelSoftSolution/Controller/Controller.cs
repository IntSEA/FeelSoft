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


namespace Controller
{
    public class Controller
    {

        private string path;
        private IProcessor processor;
        private DictionaryAn dictionaryAn;
        private ISearchDataSet dataSet;
        private ISocialNetwork twitter;
        private ISocialNetwork facebook;

        public Controller(string path)
        {
            this.path = path;
            processor = new Processor();
            dictionaryAn = new DictionaryAn();
            dataSet = new SearchDataSet();
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


    }
}
