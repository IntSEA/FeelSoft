using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetworkConnection;
using Lematization;

namespace TextualProcessor
{
   public class Processor : IProcessor
    {

        private IList<IPublication> rawPublications;
        private IDataLoader dataLoader;
        private ISearchDataSet dataSet;
        private Stemmer lemmatizer;

        
        public ISearchDataSet DataSet { get => dataSet; set => dataSet = value; }
        public Stemmer Lemmatizer { get => lemmatizer; set => lemmatizer = value; }
        public IDataLoader DataLoader { get => dataLoader; set => dataLoader = value; }
        public IList<IPublication> RawPublications { get => rawPublications; }

        public Processor()
        {
            
            dataLoader = new DataLoader();
            dataSet = new SearchDataSet();
            lemmatizer = new Stemmer();


        }

        private void ImportRawPublication(String path)
        {
           rawPublications =  dataSet.ImportDataSet(path);
        }

        public string LemmatizedMessage(string message)
        {
            string normalizeText = DeleteSymbols(message);
            string analyzedText = CompoundWordsAnalysis(normalizeText);
            string analyzedText2 = "";
            if (analyzedText.Contains("Twitter"))
            {
                analyzedText2 = StopWordsAnalysisTwitter(analyzedText);
            }
            else
            {
                analyzedText2 = StopWordsAnalysis(analyzedText);
            }
            analyzedText2 = DeleteSymbols2(analyzedText2);
            analyzedText2 = StopWordsAnalysis(analyzedText2);


            string textLematized = Lemmatize(analyzedText2);

            return textLematized;
        }

        private IList<IPublication> completedAnalysis()
        {
            IList<IPublication> lemmatizedPublications = new List<IPublication>();

            foreach (IPublication publication in RawPublications)
            {

                string textLematized = LemmatizedMessage(publication.Message);

                Publication lemmatizedPublication = new Publication()
                {
                    Id = publication.Id,
                    WroteBy = publication.WroteBy,
                    Message = publication.Message,
                    CreateDate = publication.CreateDate,
                    Language = publication.Language,
                    Location = publication.Location,
                    LemmatizedMessage = textLematized

                };

                lemmatizedPublications.Add(lemmatizedPublication);
            }

            return lemmatizedPublications;
        }

        public IList<IPublication> LemmatizedPublications(String path)

        {
            ImportRawPublication(path);
            return completedAnalysis();   
        }

        public IList<IPublication> LemmatizedPublications(IList<IPublication> publications)
        {
            rawPublications = publications;
            return completedAnalysis();
        }

        public IList<IPublication> LemmatizedPublications(ISearchDataSet dataSet)
        {
            rawPublications = dataSet.GetPublications();
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

        private string StopWordsAnalysisTwitter(string message)
        {
            String[] words = message.Split(' ');
            String newText = "";
            Boolean foundInTwitter = false;

            foreach (String word in words)
            {
                if (!dataLoader.StopWords.Contains(word) && !word.StartsWith("https:") && !word.StartsWith("co/") && !word.Contains("?") && !word.StartsWith("@") && foundInTwitter)
                {
                    newText += word + " ";
                }
                else
                {
                    if (word.Equals("Twitter:"))
                    {
                        foundInTwitter = true;
                    }
                }
            }
            return newText;
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
                if (!word.StartsWith("_"))
                {
                    try
                    {
                        if (word != "" && word != " ") {
                            newMessage += lemmatizer.Execute(word) + " ";
                        }
                    }
                    catch
                    {
                        newMessage += word + " ";
                    }
                }
                else
                {
                    newMessage += word + " ";
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
            message = message.Replace('¿', ' ');
            message = message.Replace('!', ' ');
            message = message.Replace('¡', ' ');
            message = message.Replace('…', ' ');
            message = message.Replace('(', ' ');
            message = message.Replace(')', ' ');
            message = message.Replace('\t', ' ');
            //message = message.ToLower();
            newMessage = message;
            
            return newMessage;

        }

        private string DeleteSymbols2(string message)
        {
            string newMessage = "";

            message = message.Replace('.', ' ');
            message = message.Replace('/', ' ');
            message = message.Replace('\\', ' ');
            message = message.Replace(':', ' ');
            newMessage = message;
         
            return newMessage;

        }



    }
}
