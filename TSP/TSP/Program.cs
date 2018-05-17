﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Configuration;

namespace TSP
{
    class Program
    {
        public static Random random = new Random();

        public static string nazwaPlikuWejściowego = ConfigurationManager.AppSettings["nazwaPlikuWejściowego"] ?? "gr9882";
        public static int wielkośćPopulacji = int.Parse(ConfigurationManager.AppSettings["wielkośćPopulacji"] ?? "100");
        public static int liczbaPokoleń = int.Parse(ConfigurationManager.AppSettings["liczbaPokoleń"] ?? "1");
        public static string krzyżowanie = ConfigurationManager.AppSettings["krzyżowanie"] ?? "OX";
        public static int liczbaBaterii = int.Parse(ConfigurationManager.AppSettings["liczbaBaterii"] ?? "85");
        public static string selekcja = ConfigurationManager.AppSettings["selekcja"] ?? "turniejowa";
        public static double prawdopodobieństwoMutacji = double.Parse(ConfigurationManager.AppSettings["prawdopodobieństwoMutacji"] ?? "0.5");

        public static Osobnik niebo;

        static Osobnik[] StwórzPopulacjęZPliku(string ścieżka)
        {
            int licznik = 0;
            string linijka;

            System.IO.StreamReader plik = new System.IO.StreamReader(@ścieżka);
            Osobnik osobnik = new Osobnik();
            niebo = osobnik;
            Osobnik.listaMiast = new List<Miasto>();
            while ((linijka = plik.ReadLine()) != "EOF")
            {
                if (licznik >= 7)
                {
                    string[] słowa = linijka.Split(' ');
                    var indeks = int.Parse(słowa[0]) - 1;
                    Osobnik.listaMiast.Add(new Miasto(indeks, double.Parse(słowa[1], CultureInfo.InvariantCulture), double.Parse(słowa[2], CultureInfo.InvariantCulture)));
                    osobnik.genotyp.Add(indeks);
                }
                licznik++;
            }
            plik.Close();

            Osobnik[] populacja = new Osobnik[wielkośćPopulacji];
            populacja[0] = osobnik;

            for (int i = 1; i < wielkośćPopulacji; i++)
                populacja[i] = osobnik.WymieszajOsobnika();

            return populacja;
        }

        static void Main(string[] args)
        {
            Osobnik[] populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");

            //algorytm zachłanny
            //Osobnik nieboZZachłannego = AlgorytmZachłanny.Algorytm(populacja[0]);

            //using (System.IO.StreamWriter plik =
            //new System.IO.StreamWriter(@"../../Wyniki/Z" + nazwaPlikuWejściowego + "-" + wielkośćPopulacji + "-" + czasObliczeń + "-" + krzyżowanie + "-" + liczbaBaterii + "-" + prawdopodobieństwoMutacji + "-" + selekcja + "-" + DateTime.Now.ToString().Replace(':', '-') + ".txt")))
            //{
            //    for (int i = 0; i < nieboZZachłannego.genotyp.Count; i++)
            //        plik.Write(Osobnik.listaMiast[nieboZZachłannego.genotyp[i]].indeks + " ");
            //    plik.WriteLine();
            //    plik.WriteLine("\nDługość trasy: " + nieboZZachłannego.DługośćTrasy);
            //    plik.WriteLine();
            //    plik.Close();
            //}

            //algorytm ewolucyjny
            for (int i = 0; i < liczbaPokoleń; i++)
            //Stopwatch stoper = new Stopwatch();
            //stoper.Start();
            //while (stoper.ElapsedMilliseconds <= czasObliczeń)
            {
                Osobnik[] nowaPopulacja = new Osobnik[wielkośćPopulacji];

                for (int j = 0; j < wielkośćPopulacji; j++)
                {
                    Osobnik tata = Selekcja.SelekcjaTurniejowa(populacja);
                    Osobnik mama = Selekcja.SelekcjaTurniejowa(populacja);
                    Osobnik dziecko = Krzyżowanie.KrzyżowanieOX(tata, mama);

                    //konkurencja między rodzicami i dzieckiem
                    if (tata.DługośćTrasy < mama.DługośćTrasy)
                        nowaPopulacja[j] = tata;
                    else
                        nowaPopulacja[j] = mama;

                    if (dziecko.DługośćTrasy < nowaPopulacja[j].DługośćTrasy)
                        nowaPopulacja[j] = dziecko;
                }
                populacja = nowaPopulacja;
            }
            //stoper.Stop();

            Console.WriteLine("Znaleziona ścieżka: ");
            for (int i = 0; i < niebo.genotyp.Count; i++)
                Console.Write(Osobnik.listaMiast[niebo.genotyp[i]].indeks + " ");
            Console.WriteLine("\nSzybkość trasy: " + niebo.SzybkośćTrasy());

            using (System.IO.StreamWriter zapisator =
            new System.IO.StreamWriter(@"../../Wyniki/" + nazwaPlikuWejściowego + "-" + wielkośćPopulacji + "-" + liczbaPokoleń + "-" + krzyżowanie + "-" + liczbaBaterii + "-" + prawdopodobieństwoMutacji + "-" + selekcja + "-" + DateTime.Now.ToString().Replace(':', '-') + ".txt"))
            {
                for (int i = 0; i < niebo.genotyp.Count; i++)
                    zapisator.Write(Osobnik.listaMiast[niebo.genotyp[i]].indeks + " ");
                zapisator.WriteLine();
                zapisator.WriteLine("\nSzybkość trasy: " + niebo.SzybkośćTrasy());
                zapisator.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
