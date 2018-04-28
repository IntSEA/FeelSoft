using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualProcessor;
using SocialNetworkConnection;
using System.IO;


namespace Qualification
{
    public class QualifiedText: IQualifiedText
    {
        private TheDictionary dictionary;
        private Processor processor;
        private IList<string> unqualifiedWords;
        private IList<IPublication> qualifiedPublications;

        public QualifiedText()
        {
            dictionary = new TheDictionary();
            processor = new Processor();
            unqualifiedWords = new List<string>();
        }

        private int Qualify(string message)
        {
            string[] words = message.Split();

            int favorability = 0;

            Boolean nextToNot = false;

            foreach(string word in words)
            {
                if (word.Equals("no")|| word.Equals("No") || word.Equals("NO"))
                {
                    nextToNot = true;
                }else if (dictionary.ContainsKey(word))
                {
                    if (nextToNot) 
                       favorability += - dictionary[word];
                    else
                       favorability += dictionary[word];
                }
                else
                {
                    unqualifiedWords.Add(word);
                }
            }

            return favorability;
        }

        private Boolean QualifyPetro(string message)
        {
            return false;
        }

        private Boolean QualifyFajardo(string message)
        {
            return false;
        }

        public IList<IPublication> DefaultQualifiedPublications(string resource)
        {
            IList<IPublication> lematizedPublications = processor.LemmatizedPublicationsWithResources(resource);
            IList<IPublication> publications = processor.RawPublications;
            
            foreach(IPublication publication in lematizedPublications)
            {
                string message = publication.Message;
                int favorability = Qualify(message);
                //publication.Favorability = favorability;

            }

            return lematizedPublications;
            
        }

    }
}
