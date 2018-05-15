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

        public Osobnik WymieszajOsobnika()
        {
            Osobnik nowyOsobnik = new Osobnik();
            nowyOsobnik.genotyp = new List<int>(genotyp).OrderBy(x => Program.random.Next()).ToList();
            return nowyOsobnik;
        }
    }
}
