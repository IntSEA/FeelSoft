using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using Lematization;
using System.Text.RegularExpressions;

namespace TextualProcessor
{
   public class Processor : IProcessor
    {

        private IList<IPublication> rawPublications;
        private IDataLoader dataLoader;
        private ISearchDataSet dataSet;
        private ISearchDataSet dataSetLemmatized;
        private Stemmer lemmatizer;

        
        public ISearchDataSet DataSet { get => dataSet; set => dataSet = value; }
        public Stemmer Lemmatizer { get => lemmatizer; set => lemmatizer = value; }
        public IDataLoader DataLoader { get => dataLoader; set => dataLoader = value; }
        public IList<IPublication> RawPublications { get => rawPublications; }
        public ISearchDataSet DataSetLemmatized { get => dataSetLemmatized; set => dataSetLemmatized = value; }

        public Processor()
        {
            
            dataLoader = new DataLoader();
            dataSet = new SearchDataSet();
            dataSetLemmatized = new SearchDataSet();
            lemmatizer = new Stemmer();


        }

        public Processor(ISearchDataSet dataSet)
        {

            dataLoader = new DataLoader();
            this.dataSet = dataSet;
            rawPublications = dataSet.GetPublications();
            dataSetLemmatized = new SearchDataSet();
            lemmatizer = new Stemmer();


        }

        private void ImportRawPublication(String path)
        {
           rawPublications =  dataSet.ImportDataSet(path);
        }


        private IList<IPublication> completedAnalysis()
        {
            IList<IPublication> lemmatizedPublications = new List<IPublication>();

            foreach (IPublication publication in RawPublications)
            {
                string rawText = publication.Message;
                string normalizeText = DeleteSymbols(rawText);
                string analyzedText = CompoundWordsAnalysis(normalizeText);
                string analyzedText2 = StopWordsAnalysis(analyzedText);
                analyzedText2 = DeleteSymbols2(analyzedText2);
                analyzedText2 = StopWordsAnalysis(analyzedText2);


                string textLematized = Lemmatize(analyzedText2);

                Publication lemmatizedPublication = new Publication()
                {
                    Id = publication.Id,
                    WroteBy = publication.WroteBy,
                    Message = textLematized,
                    CreateDate = publication.CreateDate,
                    Favorability = publication.Favorability,
                    Language = publication.Language,
                    Location = publication.Location

                };

                lemmatizedPublications.Add(lemmatizedPublication);
                
            }

            dataSetLemmatized.AddPublications(lemmatizedPublications);

            return lemmatizedPublications;
        }

        public IList<IPublication> LemmatizedPublications(String path)

        {
            ImportRawPublication(path);
            return completedAnalysis();   
        }

        public IList<IPublication> LemmatizedPublications()

        {
            return completedAnalysis();
        }

        public IList<IPublication> LemmatizedPublicationsWithResources(string resource)

        {
            rawPublications = dataLoader.LoadRawPublicationsWithResources(resource);
            return completedAnalysis();
        }

        private string CompoundWordsAnalysis(string message)
        {
            String newMessage = message;
            foreach (KeyValuePair<string, string> pairCompoundWord in dataLoader.CompoundWords)
            {
                if (message.Contains(pairCompoundWord.Key))
                {
                    int index = 0;

                    Boolean finished = false;

                    for (index = 0; index < (message.Length - pairCompoundWord.Key.Length) && !finished; index++)
                    {
                        String text = message.Substring(index, pairCompoundWord.Key.Length);
                        if (text.Equals(pairCompoundWord.Key))
                        {
                            finished = true;
                        }
                    }
                    if (index > 0)
                        index--;
                    newMessage = message.Remove(index, pairCompoundWord.Key.Count());
                    newMessage = newMessage.Insert(index, pairCompoundWord.Value);
                }
            }

            return newMessage;
        }



        private string StopWordsAnalysis(string message)
        {
            String[] words = message.Split(' ');
            String newText = "";

            foreach (String word in words)
            {
                if (!dataLoader.StopWords.Contains(word) && !word.StartsWith("https:") && !word.StartsWith("co/") && !word.Contains("?"))
                {
                    newText += word + " ";
                }
            }

            return newText;


        }

        private string Lemmatize(string message)
        {
            string newMessage = "";

            String[] words = message.Split(' ');

            foreach (string word in words)
            {
                if (word != "" && word != " ")
                {
                    if (!word.StartsWith("_"))
                    {
                        newMessage += lemmatizer.Execute(word) + " ";
                    }
                    else
                    {
                        newMessage += word + " ";
                    }

                }
            }

            return newMessage;
        }

    

        private string DeleteSymbols(string message)
        {
            string newMessage = "";

            message = message.Replace(';', ' ');
            message = message.Replace(',', ' ');
            message = message.Replace('&', ' ');
            message = message.Replace(':', ' ');
            message = message.Replace('¿', ' ');
            message = message.Replace('!', ' ');
            message = message.Replace('¡', ' ');
            message = message.Replace('…', ' ');
            message = message.Replace('(', ' ');
            message = message.Replace(')', ' ');
            message = message.Replace('	', ' ');
            Regex.Replace(message, @"[^a-zA-z0-9 ]+", "");


            newMessage = message;
            return newMessage;

        }

        private string DeleteSymbols2(string message)
        {
            string newMessage = "";

            message = message.Replace('.', ' ');
            message = message.Replace('/', ' ');
            message = message.Replace('\\', ' ');
            

            newMessage = message;
            return newMessage;

        }

     

    }
}
