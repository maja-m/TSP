using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class Krzyżowanie
    {
        public Krzyżowanie ()
        {
            //----------------------------------------------------------------------------------------------------------------------
            //sprawdzanie które krzyżowaine z pliku konfiguracyjnego
        }

        public static Osobnik KrzyżowanieOX(Osobnik tata, Osobnik mama)
        {
            int punkt1 = Program.random.Next(tata.genotyp.Count);
            int punkt2 = Program.random.Next(tata.genotyp.Count);

            if (punkt1 > punkt2)
            {
                int temp = punkt1;
                punkt1 = punkt2;
                punkt2 = temp;
            }

            Osobnik dziecko = new Osobnik();
            for (int i = punkt1 + 1; i <= punkt2; i++)
                dziecko.genotyp.Add(tata.genotyp[i]);

            for (int i = 0; i < tata.genotyp.Count; i++)
            {
                if (!dziecko.genotyp.Contains(mama.genotyp[i]))
                    dziecko.genotyp.Add(mama.genotyp[i]);
            }

            if (Program.random.NextDouble() < Program.prawdopodobieństwoMutacji)
                dziecko = dziecko.Mutacja();

            Program.niebo = Osobnik.PorównajOsobników(dziecko, Program.niebo);

            //Console.WriteLine("\nSzybkość trasy nieba: " + Program.niebo.SzybkośćTrasy());

            return dziecko;
        }

        //public Osobnik KrzyżowaniePrzezWymianęPodtras(Osobnik tata, Osobnik mama)
        //{
        //    //----------------------------------------------------------------------------------------------------------------------
        //}

    }
}
