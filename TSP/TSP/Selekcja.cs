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
            Console.WriteLine("jestem");
            //----------------------------------------------------------------------------------------------------------------------
            int[] punktyOsobników = new int[populacja.Length];

            //najkrótsza trasa dostaje najwięcej punktów (odwrotność szybkości trasy)
            for (int i = 0; i < populacja.Length; i++)
            {
                double szybkość = populacja[i].SzybkośćTrasy();

                if (szybkość == 0)
                {
                    punktyOsobników[i] = 0;
                    break;
                }
                    
                double ułamek = 1 / szybkość;
                double mnoż = ułamek * 1000000000;
                int floor = Convert.ToInt32(Math.Floor(mnoż));

                punktyOsobników[i] = Convert.ToInt32(Math.Floor(1 / szybkość * 1000000000));
            }
                

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
