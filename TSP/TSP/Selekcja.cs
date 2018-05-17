using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class Selekcja
    {
        public Selekcja()
        {
            //----------------------------------------------------------------------------------------------------------------------
            //sprawdzanie która selekcja z pliku konfiguracyjnego, wielkość populacji też
        }

        public static Osobnik SelekcjaTurniejowa(Osobnik[] populacja)
        {
            Osobnik osobnik1 = populacja[Program.random.Next(Program.wielkośćPopulacji)];
            Osobnik osobnik2 = populacja[Program.random.Next(Program.wielkośćPopulacji)];

            return Osobnik.PorównajOsobników(osobnik1, osobnik2);
        }

        static Osobnik SelekcjaRuletkaWartościowa(Osobnik[] populacja)
        {
            //----------------------------------------------------------------------------------------------------------------------
            double[] punktyOsobników = new double[populacja.Length];

            for (int i = 0; i < populacja.Length; i++)
                punktyOsobników[i] = 1 / populacja[i].SzybkośćTrasy();

            double sumaPunktów = 0;
            for (int i = 0; i < punktyOsobników.Length; i++)
                sumaPunktów += punktyOsobników[i];






            return populacja[0];
        }
    }
}
