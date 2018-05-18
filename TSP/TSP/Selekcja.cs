using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class Selekcja
    {
        public static Osobnik Selekcjonuj(string typ, Osobnik[] populacja)
        {
            //----------------------------------------------------------------------------------------------------------------------
            //sprawdzanie która selekcja z pliku konfiguracyjnego, wielkość populacji też
            if (typ == "turniejowa")
                return SelekcjaTurniejowa(populacja);
            else if (typ == "ruletkaWartościowa")
                return SelekcjaRuletkaWartościowa(populacja);
            else
            {
                Console.WriteLine("Podano błędny typ selekcji.");
                return null;
            }
        }

        public static Osobnik SelekcjaTurniejowa(Osobnik[] populacja)
        {
            Osobnik osobnik1 = populacja[Program.random.Next(Program.wielkośćPopulacji)];
            Osobnik osobnik2 = populacja[Program.random.Next(Program.wielkośćPopulacji)];

            return Osobnik.PorównajOsobników(osobnik1, osobnik2);
        }

        public static Osobnik SelekcjaRuletkaWartościowa(Osobnik[] populacja)
        {
            //----------------------------------------------------------------------------------------------------------------------
            int[] punktyOsobników = new int[populacja.Length];

            //najkrótsza trasa dostaje najwięcej punktów (odwrotność szybkości trasy)
            for (int i = 0; i < populacja.Length; i++)
                punktyOsobników[i] = (int)Math.Floor(1 / populacja[i].SzybkośćTrasy() * 1000000000);
                

            int sumaPunktów = 0;
            for (int i = 0; i < punktyOsobników.Length; i++)
                sumaPunktów += punktyOsobników[i];

            int wylosowanyOsobnik = Program.random.Next(sumaPunktów);

            for (int i = 0; i < populacja.Length; i++)
            {
                wylosowanyOsobnik -= punktyOsobników[i];
                if (wylosowanyOsobnik <= 0)
                    return populacja[i];
            }

            return populacja[Program.random.Next(Program.wielkośćPopulacji)];
        }
    }
}
