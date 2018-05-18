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
        public static int liczbaPokoleń = int.Parse(ConfigurationManager.AppSettings["liczbaPokoleń"] ?? "5");
        public static string krzyżowanie = ConfigurationManager.AppSettings["krzyżowanie"] ?? "OX";
        public static int liczbaBaterii = int.Parse(ConfigurationManager.AppSettings["liczbaBaterii"] ?? "22");
        public static string selekcja = ConfigurationManager.AppSettings["selekcja"] ?? "turniejowa";
        public static double prawdopodobieństwoMutacji = double.Parse(ConfigurationManager.AppSettings["prawdopodobieństwoMutacji"] ?? "0.5");

        public static Osobnik niebo;

        static Osobnik[] StwórzPopulacjęZPliku(string ścieżka)
        {
            int licznik = 0;
            string linijka;

            System.IO.StreamReader plik = new System.IO.StreamReader(@ścieżka);
            Osobnik osobnik = new Osobnik();
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

            for (int i = 0; i < wielkośćPopulacji; i++)
                populacja[i] = osobnik.WymieszajOsobnika();

            niebo = populacja[0];

            return populacja;
        }

        static void Main(string[] args)
        {
            Osobnik[] populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");

            //algorytm zachłanny
            //Osobnik nieboZZachłannego = AlgorytmZachłanny.Algorytm(populacja[0]);

            //algorytm ewolucyjny
            //AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            //-------------------------------------------------------------------------OX i TURNIEJ-------------------------------------------------------------------------
            //testy dla OX i turnieju - zmiany wielkości populacji - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 10;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 500;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany liczby pokoleń
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            wielkośćPopulacji = 100;
            liczbaPokoleń = 1;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany liczby baterii
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany prawdopodobieństwa mutacji
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.1;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);



            //testy dla OX i turnieju - zmiany wielkości populacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            wielkośćPopulacji = 10;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 500;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany liczby pokoleń
            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 1;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany liczby baterii
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i turnieju - zmiany prawdopodobieństwa mutacji
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.1;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);





            //-------------------------------------------------------------------------OX i RULETKA WARTOŚCIOWA-------------------------------------------------------------
            //testy dla OX i ruletki wartościowej -zmiany wielkości populacji - GRECJA
            selekcja = "ruletkaWartościowa";
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 10;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 500;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany liczby pokoleń
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            wielkośćPopulacji = 100;
            liczbaPokoleń = 1;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany liczby baterii
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany prawdopodobieństwa mutacji
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.1;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);



            //testy dla OX i ruletki wartościowej - zmiany wielkości populacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            wielkośćPopulacji = 10;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 500;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany liczby pokoleń
            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 1;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany liczby baterii
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.Clear();
            //testy dla OX i ruletki wartościowej - zmiany prawdopodobieństwa mutacji
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.1;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            Console.ReadKey();
        }
    }
}
