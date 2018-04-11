using System;
using Analytics;
using AnalyticDictionary;
using NaiveBayes;
using System.IO;

namespace Console1
{
    class Program
    {
        private static string carp = "C:/Users/Administrador/Documents/GitHub/FeelSoft/FeelSoftSolution/Analytics";
        private static NaiveAnalytic analytic;
        public static void setUpStage1()
        {
            int[][] input =
            {
               new int[] {6,180,12},//1
               new int[] {4,190,11},//1
               new int[] {6,170,12},//1
               new int[] {7,165,10},//1
               new int[] {5,100,6},//0
               new int[] {6,150,8},//0
               new int[] {4,130,7},//0
               new int[] {6,150,9},//0

            };
            int[] output =
            {
                1,1,1,1,0,0,0,0
            };
            analytic = new NaiveAnalytic(input,output, 1);
        }
        static void Main(string[] args)
        {
            string m = Directory.GetCurrentDirectory();
            string misDatos = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string bin = Directory.GetParent(misDatos).FullName;
            string cons = Directory.GetParent(bin).FullName;
            string folder = Directory.GetParent(cons).FullName;

            misDatos.Replace('\'', '/');
            Console.Write(misDatos);
            Console.WriteLine();
            Console.Write(m);
            Console.WriteLine();
            Console.Write(folder);

            //Test();
            Console.ReadKey();

        }
        public static void Test()
        {
            setUpStage1();
            //NaiveAnalytic an = (NaiveAnalytic)analytic;
            int[][] input = {
            //new int[]{6,130,8},
            //new int[]{6,180,12},
            //new int[]{4,190,11}
              new int[] {6,180,12},//1
               new int[] {4,190,11},//1
               new int[] {6,170,12},//1
               new int[] {7,165,10},//1
               new int[] {5,100,6},//0
               new int[] {6,150,8},//0
               new int[] {4,130,7},//0
               new int[] {6,150,9},//0

            };
            int[] outp = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] res = analytic.Decided(input);
           // analytic.saveToProcesNumber(carp+"/PruebaInt.txt");
            for (int i = 0; i < res.Length; i++)
            {
                string resp = "Fail";
                if (outp[i]==res[i])
                {
                    resp = "Yes";
                }
                Console.Write(resp+" "+res[i]);
                Console.WriteLine();
            }
        }
    }
}
