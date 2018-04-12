using System;
using System.Collections.Generic;
using System.Linq;


namespace NaiveBayes
{
    class MachingLearn
    {
        private Dictionary<int,Category> categories;
        private int[][] dataInputTraining;
        private int[] dataOutputTraining;


        public MachingLearn()
        {
            categories = new Dictionary<int, Category>();   
        }
        public double rule(double aver,double var,int par)
        {
            double arg = -1*(Math.Pow(par - aver,2))/(2*var);
            double div = Math.Sqrt(2 * Math.PI*var);
            double exp = Math.Exp(arg)/div;
            return exp;
        }
        public bool Decide(int[][] input, out int[] ret)
        {
            bool res = true;
            ret =new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                res = res && Decide(input[i], out ret[i]);
               
            }
            return res;
        }
        public bool Decide(int[] input,out int ret)
        {
            ret = -1;
            List<int> keys= categories.Keys.ToList<int>();
            bool ret1 = keys.Count > 0;
            if (ret1)
            {
                double pro = Double.MinValue;

                foreach (int a in keys){
                    categories.TryGetValue(a, out Category tmp);
                    int prop = tmp.Propiedades;
                    double[] average = tmp.Averege;
                    double[] var = tmp.Vari;
                    double sum = tmp.Proba;
                    for (int i = 0; i < prop; i++)
                    {
                        sum *= rule(average[i], var[i], input[i]);
                    }
                    ret = sum > pro ? a : ret;
                    pro = sum > pro ? sum : pro;
                    //Console.Write("" + sum + " " + pro);
                    //Console.WriteLine();

                }
            }
            return ret1;
        }
        public void Learn(int[][] input,int[] output)
        {
            Dictionary<int,List<int[]>> moment = new Dictionary<int, List<int[]>>();
            for (int i = 0; i < input.Length; i++)
            {
                int[] tmp = input[i];
                int clas = output[i];
                List<int[]> lis;
               bool a= moment.TryGetValue(clas, out lis);
                if (!a)
                {
                  lis = new List<int[]>();

                }
                lis.Add(tmp);
                if (!a)
                {
                    moment.Add(clas, lis);

                }

            }
            List<int> keys = moment.Keys.ToList();
            foreach(int a in keys)
            {

               bool s= moment.TryGetValue(a, out List<int[]>  lis);
                if (s)
                {
                    int[][] tmp = lis.ToArray();
                    Category ca = new Category(a,((double)lis.Count/ input.Length),tmp);
                    categories.Add(a, ca);


                }

            }
            dataInputTraining = input;
            dataOutputTraining = output;

        }
    }
}
