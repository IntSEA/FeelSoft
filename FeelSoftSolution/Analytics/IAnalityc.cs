using System.Collections.Generic;
using SocialNetworkConnection;

namespace Analytics
{
    public interface IAnalityc
    {
       
        int[] Decided(int[][] input);
        IDictionary<string,int> Decided(IList<IPublication> publications);

        int Decided(int[] input);
        int Decided(string[] input);
        int[] Decided(string path,int type);
        void ImportWordBank(string path);
        int[] ConvertTextInNumber(string[] msm);
        void mergeWordBanks(string path);
        void addWordsToWordBank(string[] words,int[] ponde);
        void addWordToWordBank(string word,int pon);
        int GetPond(string word);
        IDictionary<string, int> GetWordbank();
        void ExportWordBank(string path);
        void saveToProcesNumber(string path);



    }
}
