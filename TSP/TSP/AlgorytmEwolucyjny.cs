﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class AlgorytmEwolucyjny
    {
        public static void Oblicz(Osobnik[] populacja, string nazwaPlikuWejściowego, int wielkośćPopulacji, int liczbaPokoleń, string krzyżowanie, int liczbaBaterii, string selekcja, double prawdopodobieństwoMutacji)
        {
            for (int i = 0; i < liczbaPokoleń; i++)
            {
                Osobnik[] nowaPopulacja = new Osobnik[wielkośćPopulacji];

                for (int j = 0; j < wielkośćPopulacji; j++)
                {
                    Osobnik tata = Selekcja.Selekcjonuj(Program.selekcja, populacja);
                    Osobnik mama = Selekcja.Selekcjonuj(Program.selekcja, populacja);
                    Osobnik dziecko = Krzyżowanie.Krzyżuj(krzyżowanie, tata, mama);

                    //konkurencja między rodzicami i dzieckiem
                    if (tata.SzybkośćTrasy() < mama.SzybkośćTrasy())
                        nowaPopulacja[j] = tata;
                    else
                        nowaPopulacja[j] = mama;

                    if (dziecko.SzybkośćTrasy() < nowaPopulacja[j].SzybkośćTrasy())
                        nowaPopulacja[j] = dziecko;
                }
                populacja = nowaPopulacja;
            }

            Console.WriteLine("Znaleziona ścieżka: ");
            for (int i = 0; i < Program.niebo.genotyp.Count; i++)
                Console.Write(Osobnik.listaMiast[Program.niebo.genotyp[i]].indeks + " ");
            Console.WriteLine("\nSzybkość trasy: " + Program.niebo.SzybkośćTrasy());
            Console.WriteLine("\nLiczba baterii: " + Program.niebo.liczbaBateriiOsobnika);

            using (System.IO.StreamWriter zapisator =
            new System.IO.StreamWriter(@"../../Wyniki/" + nazwaPlikuWejściowego + "-" + wielkośćPopulacji + "-" + liczbaPokoleń + "-" + krzyżowanie + "-" + liczbaBaterii + "-" + prawdopodobieństwoMutacji + "-" + selekcja + "-" + DateTime.Now.ToString().Replace(':', '-') + ".txt"))
            {
                zapisator.WriteLine("\nSzybkość trasy: " + Program.niebo.SzybkośćTrasy());
                zapisator.WriteLine("\nLiczba baterii: " + Program.niebo.liczbaBateriiOsobnika);
                zapisator.WriteLine();

                for (int i = 0; i < Program.niebo.genotyp.Count; i++)
                    zapisator.Write(Osobnik.listaMiast[Program.niebo.genotyp[i]].indeks + " ");
                zapisator.WriteLine();
            }
        }
    }
}
