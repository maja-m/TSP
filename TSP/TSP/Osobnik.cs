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

        public static Osobnik PorównajOsobników(Osobnik osobnik1, Osobnik osobnik2)
        {
            if (osobnik1.DługośćTrasy < osobnik2.DługośćTrasy)
                return osobnik1;
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
            double suma = 0;
            var x2 = Math.Pow(listaMiast[idDrugiego].x - listaMiast[idPierwszego].x, 2);
            var y2 = Math.Pow(listaMiast[idDrugiego].y - listaMiast[idPierwszego].y, 2);
            suma += Math.Sqrt(x2 + y2);
            return suma;
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

        //public bool CzySpełniaOgraniczenia()                                      //-----------------------------------------------BATERIE i inne ograniczenia
        //{
        //    double t = 0;
        //    double v0;

        //    List<double> baterie = new List<double>(); ;      //------------------------------------------------------------liczba baterii
        //    for (int i = 0; i < 500; i++)
        //        baterie.Add(1000);

        //    int pierwszeMiasto = genotyp[0];

        //    for (int i = 1; i < genotyp.Count - 1; i++)
        //    {
        //        //ładowanie baterii
        //        if (genotyp[i] % 5 == 0)
        //        {
        //            if (baterie.Count != 0)
        //                baterie[baterie.Count - 1] = 1000;

        //            for (int j = baterie.Count; j < 500; j++)
        //                baterie.Add(1000);
        //        }

        //        v0 = 10 - (listaMiast[genotyp[i + 1]].z - listaMiast[genotyp[i]].z);

                

        //    }
        //    double t = S / V;
        //}
    }
}
