using System;
using System.Collections.Generic;
using Analytics;
using System.IO;

namespace NaiveBayes
{
    public class NaiveAnalytic : Analytic
    {
        private MachingLearn machingLearn;
        private string pathTraining;
        private double failTrainig;
        private double failDecided;
        private int[][] dataTestinputTrainig;
        private int[] dataTestOutputTraining;
        private double porcentTrining;
        private int[][] dataTestinput;
        private int[] dataTestOutput;


        public double FailTrainig { get => failTrainig; set => failTrainig = value; }
        public double FailDecided { get => failDecided; set => failDecided = value; }
        public int[] DataTestOutputTrainig { get => dataTestOutputTraining; set => dataTestOutputTraining = value; }
        public int[][] DataTestinputTraining { get => dataTestinputTrainig; set => dataTestinputTrainig = value; }
        public int[][] DataTestinput { get => dataTestinput; set => dataTestinput = value; }
        public int[] DataTestOutput { get => dataTestOutput; set => dataTestOutput = value; }

        public NaiveAnalytic(string pathTraining, int type, double porcent) 
        {
            this.pathTraining = pathTraining;
            machingLearn = new MachingLearn();
            porcentTrining = porcent;
            loadDataTraining(pathTraining, type);
        }
        public NaiveAnalytic( int[][] dataTraining, int[] outDataTrainig, double porcent) 
        {
            porcentTrining = porcent;

            separate(dataTraining, outDataTrainig);
            
            machingLearn = new MachingLearn();
            machingLearn.Learn(DataTestinputTraining, DataTestOutputTrainig);
            CalculateFailTrainig();
            CalculateFailDecided();

        }
        public NaiveAnalytic(string wordBank, string pathTraining, int type, double porcent) : base(wordBank)
        {
            this.pathTraining = pathTraining;
            machingLearn = new MachingLearn();
            porcentTrining = porcent;
            loadDataTraining(pathTraining, type);
        }
        public NaiveAnalytic(string wordBank, int[][] dataTraining, int[] outDataTrainig, double porcent) : base(wordBank)
        {
            porcentTrining = porcent;

            separate(dataTraining, outDataTrainig);

            machingLearn = new MachingLearn();
            machingLearn.Learn(DataTestinputTraining, DataTestOutputTrainig);
            CalculateFailTrainig();
            CalculateFailDecided();

        }
        public void loadDataTraining(string path, int type)
        {
            if (type == TYPE_STRING)
            {
                StreamReader lec = new StreamReader(path);
                List<int[]> input = new List<int[]>();
                List<int> output = new List<int>();
                string line;
                while ((line = lec.ReadLine()) != null)
                {
                    string[] linep = line.Split('|');
                    string[] phrase = linep[1].Split(' ');
                    int category = int.Parse(linep[2]);
                    if (phrase.Length>1)
                    {
                        int[] con = ConvertTextInNumber(phrase);
                        input.Add(con);
                        output.Add(category);
                    }
                   

                }
                int[][] inp = input.ToArray();
                int[] outp = output.ToArray();
                separate(inp, outp);
                machingLearn.Learn(dataTestinputTrainig, dataTestOutputTraining);
            }
            else
            {
                loadDataNumber(path);
            }
            CalculateFailTrainig();
            CalculateFailDecided();


        }

        private void separate(int[][] inp, int[] outp)
        {
           
            int numberCase = (int)(porcentTrining * outp.Length);
            List<int[]> training = new List<int[]>();
            List<int> trainingOut = new List<int>();
            for (int i = 0; i < numberCase; i++)
            {
               training.Add(inp[i]);
                trainingOut.Add(outp[i]);
            }
            dataTestinputTrainig = training.ToArray();
            dataTestOutputTraining = trainingOut.ToArray();
             training = new List<int[]>();
             trainingOut = new List<int>();
            for (int i = numberCase; i < outp.Length; i++)
            {
               
                    training.Add(inp[i]);
                    trainingOut.Add(outp[i]);
                
            }
            dataTestinput = training.ToArray();
            dataTestOutput = trainingOut.ToArray();

        }

        private void CalculateFailDecided()
        {
            int[] res = Decided(dataTestinput);
            double good = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (dataTestOutput[i] == res[i])
                {
                    good++;
                }
            }
            failDecided = (res.Length - good) / (double)res.Length;
        }

        private void CalculateFailTrainig()
        {
            int[] res = Decided(dataTestinputTrainig);
            double good = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (dataTestOutputTraining[i]==res[i])
                {
                    good++;
                }
            }
            failTrainig = (res.Length - good)/(double)res.Length;
        }

        private void loadDataNumber(string path)
        {
            StreamReader lec = new StreamReader(path);
            List<int[]> input = new List<int[]>();
            List<int> output = new List<int>();
            string line;
            while ((line = lec.ReadLine()) != null)
            {
                string[] linep = line.Split('|');
                string[] phrase = linep[1].Split(' ');
                int category = int.Parse(linep[2]);
                int[] con = parseIntToArray(phrase);
                input.Add(con);
                output.Add(category);

            }
            int[][] inp = input.ToArray();
            int[] outp = output.ToArray();
            separate(inp, outp);

            machingLearn.Learn(dataTestinputTrainig , dataTestOutputTraining);

        }
        public int[] parseIntToArray(string[] arr)
        {
            int[] ret = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int.TryParse(arr[i], out ret[i]);
            }
            return ret;
        }


        
        public override int Decided(int[] input)
        {
            machingLearn.Decide(input, out int ret);
            return ret;
        }

       

        
    }
}