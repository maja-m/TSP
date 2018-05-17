using System;
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

            //algorytm ewolucyjny
            //AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            //testy dla OX i turnieju - zmiany wielkości populacji
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 10;
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 50;
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 500;
            liczbaPokoleń = 5;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            //testy dla OX i turnieju - zmiany liczby pokoleń
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 1;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 10;
            liczbaBaterii = 99;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            //testy dla OX i turnieju - zmiany liczby baterii
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.5;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            //testy dla OX i turnieju - zmiany prawdopodobieństwa mutacji
            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 85;
            prawdopodobieństwoMutacji = 0.1;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            nazwaPlikuWejściowego = "gr9882";
            wielkośćPopulacji = 100;
            liczbaPokoleń = 5;
            liczbaBaterii = 22;
            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.ReadKey();
        }
    }
}
