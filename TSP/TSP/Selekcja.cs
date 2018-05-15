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

        public static Osobnik SelekcjaZwykła(Osobnik[] populacja)
        {
            Osobnik osobnik1 = populacja[Program.random.Next(Program.wielkośćPopulacji)];
            Osobnik osobnik2 = populacja[Program.random.Next(Program.wielkośćPopulacji)];

            return Osobnik.PorównajOsobników(osobnik1, osobnik2);
        }

        //static Osobnik SelekcjaTurniej(Osobnik[] populacja)
        //{
        //    //--------------------------------------------------------------------------------------------------------------------
        //}

        //static Osobnik SelekcjaRuletkaWartościowa(Osobnik[] populacja)
        //{
        //    //----------------------------------------------------------------------------------------------------------------------
        //}
    }
}
