using System.Collections.Generic;
using System.IO;
using System.Linq;
using SocialNetworkConnection;

namespace Analytics
{
    public abstract class Analytic : IAnalityc
    {
        public const int TYPE_STRING = 1;
        public const int TYPE_INT = 2;

        private WordBank wordBank;
        private List<string[]> toProces;
        private List<int[]> toProcesNumber;
       

        public WordBank WordBank { get => wordBank; set => wordBank = value; }
        public List<string[]> ToProces { get => toProces; set => toProces = value; }
        public List<int[]> ToProcesNumber { get => toProcesNumber; set => toProcesNumber = value; }

        public Analytic()
        {
            ToProces = new List<string[]>();
            toProcesNumber = new List<int[]>();
            wordBank = new WordBank();
            ImportWordBank("..//..//..//Analytics/Dicccionario.txt");


        }
        public Analytic(string path)
        {
            ToProces = new List<string[]>();
            toProcesNumber = new List<int[]>();
            wordBank = new WordBank();
            ImportWordBank(path);
        }
       public void convertToProces()
        {
            toProcesNumber = new List<int[]>();

            List<int[]> lis = new List<int[]>();
            foreach(string[] tmp in ToProces)
            {
                int[] con = ConvertTextInNumber(tmp);
                lis.Add(con);
            }


            toProcesNumber = lis;
        }
        public int[] ConvertTextInNumber(string[] msm)
        {
          
            int[] retor = null;
            if (wordBank != null)
            {
                retor = new int[WordBank.GetWords().Count];
                List<string> words = WordBank.GetWords().Keys.ToList();
                Dictionary<string, int> mens = new Dictionary<string, int>();

                foreach (string tmp in msm)
                {
                    bool a = mens.TryGetValue(tmp, out int rep);
                    rep = a ? rep + 1 : 1;
                    if (!a)
                    {
                        mens.Add(tmp, rep);
                    }
                    else
                    {
                        mens[tmp] = rep;
                    }
                }
                int i = 0;
                foreach (string tmp in words)
                {
                    if (mens.TryGetValue(tmp, out int ret))
                    {
                        retor[i] = ret;
                    }
                    else
                    {
                        retor[i] = 0;
                    }
                    i++;
                }

            }
            return retor;
        }
       

    
        public void addWordsToWordBank(string[] words, int[] ponde)
        {
            
            for(int i = 0; i < words.Length; i++)
            {
                string tmp = words[i];
                int tmp1 = ponde[i];
                addWordToWordBank(tmp, tmp1);
            }
        }

        public void addWordToWordBank(string word, int pon)
        {
            wordBank.addWord(word, pon);
        }
        
        public void addToProces(string path)
        {
            StreamReader lec = new StreamReader(path);
            toProces = new List<string[]>();

            string line;
            while ((line = lec.ReadLine()) != null&&!line.Equals(""))
            {
                string[] data = line.Split('|');
                string[] data1 = data[1].Split(' ');
                ToProces.Add(data1);

            }
            convertToProces();
            lec.Close();

        }
        public void addToProcesNumber(string path)
        {
            StreamReader lec = new StreamReader(path);
            toProcesNumber = new List<int[]>();

            string line;
            while ((line = lec.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                int[] tmp = new int[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    int.TryParse(data[i],out tmp[i]);

                }
                toProcesNumber.Add(tmp);

            }
            lec.Close();
        }

        public void Classify(string path,int state)
        {
            if (state==TYPE_STRING)
            {
                addToProces(path);
            }
            else
            {
                addToProcesNumber(path);

            }
        }      
        
        public void ExportWordBank(string path)
        {
            wordBank.save(path);
        }

        public int GetPond(string word)
        {
           bool b= wordBank.consult(word,out int a);
            a = b ? a : int.MaxValue;
            return a;
        }

        public IDictionary<string, int> GetWordbank()
        {
            return wordBank.GetWords();
        }

        public void ImportWordBank(string path)
        {
            wordBank.Load(path);
        }

        public void mergeWordBanks(string path)
        {
            ImportWordBank(path);
        }

        public  int[] Decided(int[][] input)
        {
            int[] ret = new int[input.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Decided(input[i]);
            }
            return ret;
        }
        
        public abstract int Decided(int[] input);

        public  int[] Decided(string path,int type)
        {
            Classify(path, type);
            int[][] input = ToProcesNumber.ToArray();
            return Decided(input);
        }
        public void saveToProcesNumber(string path)
        {
            StreamWriter es = new StreamWriter(path);
            foreach(int[] tmm in toProcesNumber)
            {
                string line = "";
                string sep = "";
                foreach (int tmp in tmm)
                {
                    line += sep+tmp;
                    sep = " ";
                }
                es.Write(line);
                es.WriteLine();
            }
            es.Close();
        }

        public int Decided(string[] input)
        {
            int[] inp = ConvertTextInNumber(input);
            return Decided(inp);
        }

        public IDictionary<string, int> Decided(IList<IPublication> publications)
        {
            IDictionary<string, int> ret = new Dictionary<string,int>();
            foreach (var item in publications)
            {
                int a = Decided(item.LemmatizedMessage.Split(' '));
                ret.Add(item.Id, a);
            }
            return ret;
        }
    }
}
