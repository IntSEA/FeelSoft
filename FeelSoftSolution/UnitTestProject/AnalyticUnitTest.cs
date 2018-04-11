using Microsoft.VisualStudio.TestTools.UnitTesting;
using Analytics;
using NaiveBayes;
using System;

namespace UnitTestProject
{

   
    [TestClass]
    public class AnalyticUnitTest
    {
       private NaiveAnalytic analytic;
        public string directory = "..//..//..//";
        public void setUpStage1()
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
            analytic = new NaiveAnalytic(input,output,1);
           
        }
        public void setUpStage2()
        {
            analytic = new NaiveAnalytic(directory+"Analytics/PruebaNaiveBayes.txt", Analytic.TYPE_INT, 1);
        }
        public void setUpStage3()
        {

        }

        [TestMethod]
        public void TestMatriz()
        {
            setUpStage1();
           
            int[][] input = {
            new int[]{6,130,8},
            new int[]{6,180,12},
            new int[]{4,190,11}

            };
            int[] outp = {0,1,1};
            double failTra = analytic.FailTrainig;
            Assert.IsTrue(failTra == 0);

            int[] res =analytic.Decided(input);
            for (int i = 0; i < res.Length; i++)
            {
                Assert.IsTrue(outp[i] == res[i]);
                Console.Write(""+res[i]);
            }
        }
        [TestMethod]
        public void TestFile()
        {
            setUpStage2();

            int[][] input = {
            new int[]{6,130,8},
            new int[]{6,180,12},
            new int[]{4,190,11}

            };
            int[] outp = { 0, 1, 1 };
            int[] res = analytic.Decided(input);
            for (int i = 0; i < res.Length; i++)
            {
                Assert.IsTrue(outp[i] == res[i]);
                Console.Write("" + res[i]);
            }
        }
        [TestMethod]
        public void TestFileIn()
        {
            setUpStage2();
            int[] outp = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] res = analytic.Decided(directory+"Analytics/PruebaNaiveBayesInputs.txt", Analytic.TYPE_INT);
            for (int i = 0; i < res.Length; i++)
            {
                Assert.IsTrue(outp[i] == res[i],"el valor: "+res[i] );
               
                Console.Write("" + res[i]);
            }
        }
        [TestMethod]
        public void TestMatrizIn()
        {
            setUpStage1();

            int[] outp = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] res = analytic.Decided(directory+"Analytics/PruebaNaiveBayesInputs.txt", Analytic.TYPE_INT);
            for (int i = 0; i < res.Length; i++)
            {
                Assert.IsTrue(outp[i] == res[i]);
                Console.Write("" + res[i]);
            }
        }

    }
}
