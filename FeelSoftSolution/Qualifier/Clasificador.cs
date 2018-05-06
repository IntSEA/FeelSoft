using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifier
{
    public class Clasificador
    {
        private IList<String> rawText;
        private IList<String> processedText;
        private IList<String> worldList;
        private IList<String> calificationList;
        private int counter;

        public Clasificador()
        { }

        public IList<string> RawText { get => rawText; set => rawText = value; }
        public IList<string> ProcessedText { get => processedText; set => processedText = value; }
        public IList<string> WorldList { get => worldList; set => worldList = value; }
        public IList<string> CalificationList { get => calificationList; set => calificationList = value; }
        public int Counter { get => counter; set => counter = value; }

        public void load(string address, string diccionario)
        {
            loadCount(address);
            StreamReader objReader = new StreamReader(address);

            RawText = new List<string>();
            ProcessedText = new List<string>();
            /*
            foreach (var line in linesCouples)
            {
                String[] pair = line.Split('|');
                RawText.Add(pair[0]);
                ProcessedText.Add(pair[1]);
            }
       */
            string sLine = " ";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    String[] pair = sLine.Split('|');
                    RawText.Add(pair[0]);
                    ProcessedText.Add(pair[1]);
                }

            }
            objReader.Close();

            updateWordList(diccionario);
        }

        public void updateWordList(string address)
        {
            WorldList = new List<string>();
            String[] words = ProcessedText[Counter].Split(' ');
            foreach (var line in words)
            {
                //Modificacion
                StreamReader reader = new StreamReader(address);
                string sLine = reader.ReadLine();
                Boolean esta = false;
                while (sLine != null)
                {
                    string[] dic = new string[2];
                    dic = sLine.Split('|');
                    if (line.Equals(dic[0]))
                    {
                        esta = true;
                    }
                    sLine = reader.ReadLine();
                }
                if (!esta)
                {
                    WorldList.Add(line);
                }
                reader.Close();
            }
        }

        public void loadWordList(string address)
        {
            calificationList = new List<string>();

            foreach (var item in worldList)
            {
                int i = calificationList.Count;
                StreamReader reader = new StreamReader(address);
                string sLine = reader.ReadLine();
                while (sLine != null)
                {

                    string[] dic = new string[2];
                    dic = sLine.Split('|');
                    if (item.Equals(dic[0]))
                    {
                        calificationList.Add(dic[1]);
                    }
                    sLine = reader.ReadLine();
                }
                int j = CalificationList.Count;
                if (i == j)
                {
                    calificationList.Add("none");
                }
                reader.Close();
            }
            /*
            public void loadCount()
            {
                try
                {
                    StreamWriter sw = new StreamWriter(Properties.Resources.contador);
                    //Write a line of text
                    sw.Write(Counter++);
                    //Close the file
                    sw.Close();
                }
                catch (Exception e){
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally{
                    Console.WriteLine("Executing finally block.");
                }
            }
            */
        }

        public void loadCount(string adress)
        {
            Counter = 0;
            Boolean found = true;
            StreamReader reader = new StreamReader("Counter.txt");
            string line = reader.ReadLine();
            while (line != null && found)
            {

                string befCounter = line.Split('|')[0];
                string befAdress = line.Split('|')[1];
                line = reader.ReadLine();

                if (befAdress.Equals(adress))
                {
                    Boolean reply = true;
                    while (line != null)
                    {
                        if (line.Split('|')[1].Equals(adress))
                        {

                            Counter = Int32.Parse(line.Split('|')[0]);
                            reply = false;
                        }
                        line = reader.ReadLine();
                    }
                    if (reply)
                    {
                        Counter = Int32.Parse(befCounter);
                        found = false;
                    }

                }
            }
            reader.Close();
        }

        public void saveCounter(int count, string adress)
        {
            StreamWriter writer = new StreamWriter("Counter.txt");
            writer.WriteLine(count + "|" + adress);
            writer.Close();

        }
    }
}
