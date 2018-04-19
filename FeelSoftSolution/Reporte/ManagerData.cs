using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SocialNetworkConnection;
using NaiveBayes;
using AnalyticDictionary;

namespace Reporte
{

    public class ManagerData
    {
        public const int NAIVE = 1;
        private string folder = "..//..//";
        private NaiveAnalytic naive;
        private DictionaryAn dictionary;
        public ManagerData()
        {
            naive = new NaiveAnalytic();
            dictionary = new DictionaryAn();
        }
        
        public double[][] data(DateTime ini,DateTime fin,int tec,out string[] dom,out string[] ser)
        {
           dom= setDominio(ini, fin);
            DirectoryInfo dir= Directory.CreateDirectory(folder);
            FileInfo[] files = dir.GetFiles();
            List<FileInfo> toProces = new List<FileInfo>();
            foreach (FileInfo item in files)
            {
                string name = item.Name;
                string[] split = name.Split('.');
                string[] fechas = split[0].Split('_');
                string[] fecha1 = fechas[0].Split('-');
                string[] fecha2 = fechas[1].Split('-');
                DateTime time = new DateTime(int.Parse(fecha1[2]), int.Parse(fecha1[1]), int.Parse(fecha1[0]));
                DateTime timeF = new DateTime(int.Parse(fecha2[2]), int.Parse(fecha2[1]), int.Parse(fecha2[0]));
                if (IsInRange(time,timeF,ini,fin))
                {
                    toProces.Add(item);
                }

            }
            List<IPublication> publications = new List<IPublication>();
            foreach (FileInfo item in toProces)
            {
                StreamReader lec = new StreamReader(item.FullName);
                leer(lec, publications);
                lec.Close();
              
            }

            publications.Sort(new Comparison<IPublication>(compare));
            foreach (IPublication item in publications)
            {
                if (comparate(item.CreateDate,ini)<0)
                {
                    publications.Remove(item);
                }
                else
                {
                    break;
                }
            }
            for (int i = publications.Count-1; i >=0; i--)
            {
                IPublication tmp = publications[i];
                if (comparate(tmp.CreateDate, fin) >0)
                {
                    publications.Remove(tmp);
                   
                }
                else
                {
                    break;
                }
            }
            Dictionary<string, List<IPublication>> publication = new Dictionary<string, List<IPublication>>();
            foreach (IPublication item in publications)
            {
                string key = item.ConfigurationName;
                bool ret=publication.TryGetValue(key, out List<IPublication> lis);
                if (ret)
                {
                    lis.Add(item);
                }
                else
                {
                    lis = new List<IPublication>();
                    lis.Add(item);
                    
                    publication.Add(key,lis);
                }
            }
            ser = publication.Keys.ToList().ToArray();
            double[][] retorno = new double[ser.Length][];
            int k = 0;
            foreach (string item in ser)
            {
                publication.TryGetValue(item, out List<IPublication> lis);
                double[] dici = Decided(lis,tec,dom);
                retorno[k] = dici;
                k++;
            }
            return retorno;
        }

        private double[] Decided(List<IPublication> lis, int tec,string[] dom)
        {
            double[] retor = new double[dom.Length];
            int index = 0;
            foreach (string item in dom)
            {
                string[] fec = item.Split('/');
                DateTime time = new DateTime(int.Parse(fec[2]), int.Parse(fec[1]), int.Parse(fec[0]));
                List<IPublication> tmp = new List<IPublication>();
                for (; index < lis.Count; index++)
                {
                    if (comparate(lis[index].CreateDate, time) == 0)
                    {
                        tmp.Add(lis[index]);
                    }
                    else
                    {
                        break;
                    }
                }
                double retorno = 0;
                if (tec == NAIVE)
                {
                    retorno =DecidedNaive(lis);
                }
                else
                {
                    retorno=DecidedDiccionary(lis);
                }
                retor[index] = retorno;
                index++;
            }
            return retor;
            
        }

        private double DecidedDiccionary(List<IPublication> lis)
        {
            double ret = 0;
            foreach (IPublication item in lis)
            {
                int de = dictionary.Decided(item.LemmatizedMessage.Split(' '));
                if (de==1)
                {
                    ret++;
                }
            }
            ret = ret/lis.Count;
            return ret;
            
        }

        private double DecidedNaive(List<IPublication> lis)
        {
            double ret = 0;
            foreach (IPublication item in lis)
            {
                int de = naive.Decided(item.LemmatizedMessage.Split(' '));
                if (de == 1)
                {
                    ret++;
                }
            }
            ret = ret / lis.Count;
            return ret;
        }

        public string[] setDominio(DateTime ini, DateTime fin)
        {
            int range = fin.DayOfYear-ini.DayOfYear;
            List<string> dom = new List<string>();
            int i = 0;
            while (i < range)
            {
                string tmp = ini.ToString().Split(' ')[0];
                dom.Add(tmp);
                ini = ini.AddDays(1);
                i++;
            }
            string tmp1 = ini.ToString().Split(' ')[0];
            dom.Add(tmp1);
            return dom.ToArray();
        }

        private void leer(StreamReader lec, List<IPublication> publications)
        {
            string line;
            while ((line=lec.ReadLine())!=null)
            {
                while (!line.Contains(Publication.END_LINE))
                {
                    line += lec.ReadLine();
                }
               IPublication publication= Publication.ParsePublication(line);
                publications.Add(publication);
            }
        }

        private bool IsInRange(DateTime time, DateTime timeF, DateTime ini, DateTime fin)
        {
            bool ret = true;
            if (comparate(time,fin)>0)
            {
                ret = false;
            }else if (comparate(timeF, ini) < 0)
            {
                ret = false;
            }

            return ret;
        }

       
        public int comparate(DateTime a,DateTime b)
        {
            int Dt1 = a.Day;
            int Mt1 = a.Month;
            int Dt2 = b.Day;
            int Mt2 = b.Month;
            if (Mt1 < Mt2)
            {
                return -1;
            }
            else if (Mt1 > Mt2)
            {
                return 1;
            }
            else
            {
                if (Dt1 < Dt2)
                {
                    return -1;
                }
                else if (Dt1 == Dt2)
                {
                    return 0;
                }
                else{
                    return 1;
                }
            }

        }
        public int compare(IPublication a, IPublication b)
        {

            return comparate(a.CreateDate, b.CreateDate);
        }
    }
}
