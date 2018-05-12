using System.Collections.Generic;
using Analytics;
using System.Linq;

namespace AnalyticDictionary
{

    public class DictionaryAn : Analytic
    {
      
        public DictionaryAn(string rout):base(rout) 
        {
        
        }
        public DictionaryAn()
        {

        }

       
        public int DecidedSentence(string[] sentence)
        {
            int qualification = 0;

            foreach (string word in sentence)
            {
              qualification += WordBank.getValue(word);
            }

            return qualification; 
        }
        //Retorna un arreglo donde [0] es el numero de positivos y [1] el numero de negativos
        public double[] numPositiveAndNegative(IList<string[]> sentences)
        {
            double[] favorAndDesfavor = new double[2];
            double countPositive = 0.0;
            double countNegative = 0.0;

            foreach (string[] words in sentences)
            {
                int qualification = DecidedSentence(words);

                if (qualification > 5)
                {
                    countPositive++;
                }
                else if (qualification < -5)
                {
                    countNegative++;
                }
            }
            favorAndDesfavor[0] = countPositive;
            favorAndDesfavor[1] = countNegative;

            return favorAndDesfavor;
        }

  /*      public double[] DecidedSentences(IList<string[]> sentences)
        {
            double[] favorAndDesfavor = new double[2];

            double favorability = 0.0;
            double desfavorability = 0.0;

            double countPositive = 0.0;
            double countNegative = 0.0;                

            foreach (string[] words in sentences)
            {
                int qualification =  DecidedSentence(words);

                if (qualification > 5 )
                {
                    countPositive++;  
                }
                else if(qualification < -5)
                {
                    countNegative++;
                }
            }

            favorability = (countPositive / sentences.Count);
            desfavorability = (countNegative / sentences.Count);
            favorAndDesfavor[0] = favorability;
            favorAndDesfavor[1] = desfavorability;

            return favorAndDesfavor;
        }*/

        public override int Decided(int[] input)
        {
            int max = 5 * input.Length;
            int min = -5 * input.Length;
            Dictionary<string,int> bank = WordBank.GetWords();
            List<string> words = bank.Keys.ToList();
            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bank.TryGetValue(words[i], out int a);
                total += input[i] *a ;
            }
            int ret = -2;
            int negativo = (max+2*min)/3;
            int positivo = (2*max + min) / 3;

            if (total<negativo)
            {
                ret = -1; 
            }else if (total>=negativo&&total<=positivo)
            {
                ret = 0;
            }
            else
            {
                ret = 1;
            }
            return ret;
        }

        

        
    }
}
