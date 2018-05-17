using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public class Osobnik
    {
        public static List<Miasto> listaMiast;

        //genotyp to to kolejność występowania 29 miast w ścieżce (po indeksach)
        public List<int> genotyp;

        public Osobnik()
        {
            genotyp = new List<int>();
        }

        public static Osobnik PorównajOsobników(Osobnik osobnik1, Osobnik osobnik2)             //-----------------------todo sprawdzaj czy osobnik się nadaje (t != 0)
        {
            if (osobnik1.SzybkośćTrasy() < osobnik2.SzybkośćTrasy())
            {
                if (osobnik1.SzybkośćTrasy() != 0)
                    return osobnik1;
                else if (osobnik2.SzybkośćTrasy() != 0)
                    return osobnik2;
                else
                    return osobnik1;
            }
            else
                return osobnik2;
        }

        public double DługośćTrasy
        {
            get
            {
                double suma = 0;

                for (int i = 0; i < listaMiast.Count - 1; i++)
                {
                    var miasto1 = genotyp[i];
                    var miasto2 = genotyp[i + 1];
                    var x2 = Math.Pow(listaMiast[miasto2].x - listaMiast[miasto1].x, 2);
                    var y2 = Math.Pow(listaMiast[miasto2].y - listaMiast[miasto1].y, 2);
                    suma += Math.Sqrt(x2 + y2);
                }
                return suma;
            }
        }

        public double OdległośćMiędzyOSobnikami(int idPierwszego, int idDrugiego)
        {
            var x2 = Math.Pow(listaMiast[idDrugiego].x - listaMiast[idPierwszego].x, 2);
            var y2 = Math.Pow(listaMiast[idDrugiego].y - listaMiast[idPierwszego].y, 2);
            return Math.Sqrt(x2 + y2);
        }

        public Osobnik WymieszajOsobnika()
        {
            Osobnik nowyOsobnik = new Osobnik();
            nowyOsobnik.genotyp = new List<int>(genotyp).OrderBy(x => Program.random.Next()).ToList();
            return nowyOsobnik;
        }

        public Osobnik Mutacja()
        {
            int punkt1 = Program.random.Next(genotyp.Count);
            int punkt2 = Program.random.Next(genotyp.Count);
            int temp = genotyp[punkt1];
            genotyp[punkt1] = genotyp[punkt2];
            genotyp[punkt2] = temp;
            return this;
        }

        public double SzybkośćTrasy()                                      //-----------------------------------------------BATERIE
        {
            double t = 0;
            double tOdcinka;
            double s = DługośćTrasy;
            double sOdcinka;
            double sOdcinkaDoBaterii;
            double vOdcinka;
            double v0;
            int liczbaBaterii = 85;                          //------------------------------------------------------------liczba baterii

            List<double> baterie = new List<double>(); ;      
            for (int i = 0; i < liczbaBaterii; i++)
                baterie.Add(1000);
            
            for (int i = 0; i < genotyp.Count - 1; i++)
            {
                //rozładowywanie baterii
                sOdcinka = OdległośćMiędzyOSobnikami(i, i + 1);
                sOdcinkaDoBaterii = sOdcinka;

                while (sOdcinkaDoBaterii > 0)
                {
                    if (baterie.Count == 0)
                        return 0;

                    if (baterie[baterie.Count - 1] < sOdcinkaDoBaterii)
                    {
                        baterie.RemoveAt(baterie.Count - 1);
                        sOdcinkaDoBaterii -= 1000;
                    }
                    else
                    {
                        baterie[baterie.Count - 1] -= sOdcinkaDoBaterii;
                        sOdcinkaDoBaterii = 0;
                    }
                }

                //ładowanie baterii
                if (genotyp[i] % 5 == 1)
                {
                    if (baterie.Count != 0)
                        baterie[baterie.Count - 1] = 1000;

                    for (int j = baterie.Count; j < liczbaBaterii; j++)
                        baterie.Add(1000);
                }

                //jeśli po dojechaniu nie mamy baterii i nie naładowaliśmy, musimy przerwać jazdę (trasa nie spełnia warunków)
                if (baterie.Count == 0 || baterie[0] == 0)
                    return 0;                                                                                                       //błędna trasa zwraca 0

                v0 = 10 - (listaMiast[genotyp[i + 1]].z - listaMiast[genotyp[i]].z);
                vOdcinka = v0 * (1 - 0.01 * baterie.Count);
                tOdcinka = sOdcinka / vOdcinka;
                t += tOdcinka;
            }

            return t;
        }

        //public double SzybkośćOdcinkaTrasy()
        //{

        //}
    }
}
