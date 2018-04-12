using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification
{
    class TheDictionary : Dictionary<string,int>
    {

        public TheDictionary() : base()
        {
            loadDictionary();
        }

        public void loadDictionary()
        {
            String dictionary = Properties.Resources.Diccionario;
            String[]lines = dictionary.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in lines)
            {
                String[] keyWordAndValue = line.Split('|');

                Add(keyWordAndValue[0], Convert.ToInt32(keyWordAndValue[1]));
            }

        }
    }
}
