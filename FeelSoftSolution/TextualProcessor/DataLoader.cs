using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SocialNetworkConnection;

namespace TextualProcessor
{
    public class DataLoader : IDataLoader

    {
        public const string path = "C:\\";

        private IList<string> stopWords;
        private IDictionary<string, string> compoundWords;
        

        public IList<string> StopWords { get => stopWords; set => stopWords = value; }
        public IDictionary<string, string> CompoundWords { get => compoundWords; set => compoundWords = value; }
        

        public DataLoader()
        {
            stopWords = new List<string>();
            compoundWords = new Dictionary<string, string>();
            
            LoadCompoundWords();
            LoadStopWord();

        }

        private void LoadCompoundWords()
        {
            string textCompoundsWord = Properties.Resources.compoundWords;
            string[] pairs =  textCompoundsWord.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string pair in pairs)
            {
                string[] keyAndValue = pair.Split('|');
                compoundWords.Add(keyAndValue[0], keyAndValue[1]);
            }
        }

        private void LoadStopWord()
        {
            string textStopWord = Properties.Resources.stopWords;
            stopWords = textStopWord.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }


        public IList<IPublication> LoadRawPublicationsWithResources(string resource)
        {
            IList<IPublication> defaultRawPublications = new List<IPublication>();

            string[] lines = resource.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                IPublication publication = Publication.ParsePublication(line);
                defaultRawPublications.Add(publication);
            }

            return defaultRawPublications;
        }


    }
}
