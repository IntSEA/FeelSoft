using System;
using Analytics;
using AnalyticDictionary;
using NaiveBayes;
using System.IO;
using Reporte;

namespace Console1
{
    class Program
    {
        private static string carp = "..//..//..//Analytics";
        private static NaiveAnalytic analytic;
        public static void setUpStage1()
        {
            int[][] input =
            {
               new int[] {6,180,12},//1
               new int[] {5,100,6},//0
               new int[] {4,190,11},//1
               new int[] {6,150,8},//0
               new int[] {6,170,12},//1
               new int[] {4,130,7},//0
               new int[] {7,165,10},//1
               new int[] {6,150,9},//0

            };
            int[] output =
            {
                1,0,1,0,1,0,1,0
            };
            analytic = new NaiveAnalytic(input,output, 0.7);
        }
        static void Main(string[] args)
        {
            //Test();
            //Console.ReadKey();
            DateTime before = new DateTime(2018,3,29);
            DateTime now = DateTime.Now;
            ManagerData manager =new ManagerData();
            string[] tmp=manager.setDominio(before, now);

        }
        public static void Test()
        {
            setUpStage1();
            int[][] input = {
              new int[] {6,180,12},//
               new int[] {4,190,11},//1
               new int[] {6,170,12},//1
               new int[] {7,165,10},//1
               new int[] {5,100,6},//0
               new int[] {6,150,8},//0
               new int[] {4,130,7},//0
               new int[] {6,150,9},//0

            };
            int[] outp = { 1, 1, 1, 1, 0, 0, 0, 0 };
            double fail = analytic.FailTrainig*100;
            double fail2 = analytic.FailDecided*100;
            Console.Write(fail+"% Error "+fail2+"%");
            Console.WriteLine();
            int[] res = analytic.Decided(input);
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
