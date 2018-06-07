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
        public static int liczbaBaterii = int.Parse(ConfigurationManager.AppSettings["liczbaBaterii"] ?? "22");
        public static string selekcja = ConfigurationManager.AppSettings["selekcja"] ?? "turniejowa";
        public static double prawdopodobieństwoMutacji = double.Parse(ConfigurationManager.AppSettings["prawdopodobieństwoMutacji"] ?? "0.5", CultureInfo.InvariantCulture);

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
            Osobnik[] populacja;

            if (args.Length != 0)
            {
                if (args.Length == 2)
                {
                    nazwaPlikuWejściowego = args[0];
                    liczbaBaterii = Int32.Parse(args[1]);

                    populacja = StwórzPopulacjęZPliku(nazwaPlikuWejściowego + ".tsp");
                    AlgorytmZachłanny.Oblicz(populacja[0]);
                }
                else if (args.Length == 7)
                {
                    nazwaPlikuWejściowego = args[0];
                    wielkośćPopulacji = Int32.Parse(args[1]);
                    liczbaPokoleń = Int32.Parse(args[2]);
                    krzyżowanie = args[3];
                    liczbaBaterii = Int32.Parse(args[4]);
                    selekcja = args[5];
                    prawdopodobieństwoMutacji = Double.Parse(args[6]);

                    populacja = StwórzPopulacjęZPliku(nazwaPlikuWejściowego + ".tsp");
                    AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy plik .bat");
                }
            }

            //populacja = StwórzPopulacjęZPliku(nazwaPlikuWejściowego + ".tsp");
            //AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            //Console.ReadKey();




            //------------------------------------------------------------------ALGORYTM EWOLUCYJNY-------------------------------------------------------------------------
            //----------------------------------------------------KRZYŻOWANIE PRZEZ WYMIANĘ PODTRAS i TURNIEJ---------------------------------------------------------------
            //testy dla wymiany podtras i turnieju - zmiany wielkości populacji - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            krzyżowanie = "przezWymianePodtras";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 200;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany liczby pokoleń - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            liczbaPokoleń = 50;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            liczbaPokoleń = 100;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany prawdopodobieństwa mutacji - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            prawdopodobieństwoMutacji = 0.2;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);



            //testy dla wymiany podtras i turnieju - zmiany wielkości populacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 200;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany liczby pokoleń - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;
            

            liczbaPokoleń = 50;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            liczbaPokoleń = 100;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany prawdopodobieństwa mutacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "turniejowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            prawdopodobieństwoMutacji = 0.2;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);



            //---------------------------------------------------KRZYŻOWANIE PRZEZ WYMIANĘ PODTRAS i RULETKA WARTOŚCIOWA--------------------------------------------------
            //testy dla wymiany podtras i turnieju - zmiany wielkości populacji - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            krzyżowanie = "przezWymianePodtras";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 200;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany liczby pokoleń - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            liczbaPokoleń = 50;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            liczbaPokoleń = 100;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany prawdopodobieństwa mutacji - GRECJA
            nazwaPlikuWejściowego = "gr9882";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            prawdopodobieństwoMutacji = 0.2;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);



            //testy dla wymiany podtras i turnieju - zmiany wielkości populacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 100;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            wielkośćPopulacji = 200;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany liczby pokoleń - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;


            liczbaPokoleń = 50;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            liczbaPokoleń = 100;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);


            //testy dla wymiany podtras i turnieju - zmiany prawdopodobieństwa mutacji - SZWECJA
            nazwaPlikuWejściowego = "sw24978";
            selekcja = "ruletkaWartosciowa";
            wielkośćPopulacji = 50;
            populacja = StwórzPopulacjęZPliku("../../" + nazwaPlikuWejściowego + ".tsp");
            liczbaPokoleń = 10;
            liczbaBaterii = 50;
            prawdopodobieństwoMutacji = 0.5;

            prawdopodobieństwoMutacji = 0.2;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            prawdopodobieństwoMutacji = 0.8;
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);
            AlgorytmEwolucyjny.Oblicz(populacja, nazwaPlikuWejściowego, wielkośćPopulacji, liczbaPokoleń, krzyżowanie, liczbaBaterii, selekcja, prawdopodobieństwoMutacji);

            Console.ReadKey();
        }
    }
}
