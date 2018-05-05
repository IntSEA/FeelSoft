using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Analytics
{
   public class WordBank
    {
        private Dictionary<string,int> words;

        public WordBank()
        {
            words = new Dictionary<string, int>();
        }

        public void Load(string path)
        {
            StreamReader lec = new StreamReader(path);
            string line;
            while(( line = lec.ReadLine()) != null){
                string[] lin = line.Split('|');
                bool con=int.TryParse(lin[1], out int result);
                if (con)
                {
                    words[lin[0]] = result;

                }
            }
            lec.Close();


        }
     
        public void addWord(string word,int pon)
        {
            words.Add(word, pon);
        }

        public int getValue(string keyWord)
        {
            if (words.ContainsKey(keyWord))
            {
                return words[keyWord];
            }
            else
            {
                return 0;
            }
            
        }

        public bool consult(string word,out int ponder)
        {
            return words.TryGetValue(word,out ponder);

        }
        public Dictionary<string,int> GetWords()
        {
            return words;
        }
        public void save(string path)
        {
            StreamWriter es = new StreamWriter(path);
            List<String> keys = words.Keys.ToList();
            foreach(string tmp in keys)
            {
                string msm = tmp + " " + words[tmp];
                es.WriteLine(msm);

            }
            es.Close();
        }
    }
}
