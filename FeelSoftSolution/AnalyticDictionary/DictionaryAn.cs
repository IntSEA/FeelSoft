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
