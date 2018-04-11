using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    class Category
    {
        private double proba;
        private int[][] values;
        private int name;
        private double[] averege;
        private double[] vari;
        private int propiedades;
        public Category(int name, double pr,int[][] values)
        {
            Proba = pr;
            this.name = name;
            this.values = values;
            Propiedades = values[0].Length;
            Averege = new double[Propiedades];
            Vari = new double[Propiedades];

            calculateAverage();
            calculateVar();

        }

        public int Propiedades { get => propiedades; set => propiedades = value; }
        public double[] Averege { get => averege; set => averege = value; }
        public int Name { get => name; set => name = value; }
        public double[] Vari { get => vari; set => vari = value; }
        public double Proba { get => proba; set => proba = value; }

        private void calculateAverage()
        {
            for (int i = 0; i < values[0].Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    sum += values[j][i];
                }
                Averege[i] = sum / values.Length;
            }
        }

        private void calculateVar()
        {
            for (int i = 0; i < values[0].Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    sum += (values[j][i]-Averege[i])* (values[j][i] - Averege[i]);
                }
                
                vari[i] = sum / (values.Length-1);
            }
        }
    }
}
