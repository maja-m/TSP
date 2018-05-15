﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace TSP
{
    class Program
    {
        public static Random random = new Random();
        public static int wielkośćPopulacji = 100;// int.Parse(ConfigurationManager.AppSettings["wielkośćPopulacji"] ?? "100");
        public static int liczbaPokoleń = 100;// int.Parse(ConfigurationManager.AppSettings["liczbaPokoleń"] ?? "100");
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
            Osobnik[] populacja = StwórzPopulacjęZPliku("../../gr9882.tsp");

            //for (int i = 0; i < liczbaPokoleń; i++)
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds <= 1000 * 60 * 10)
            {
                Osobnik[] nowaPopulacja = new Osobnik[wielkośćPopulacji];

                for (int j = 0; j < wielkośćPopulacji; j++)
                {
                    Osobnik tata = Selekcja.SelekcjaZwykła(populacja);
                    Osobnik mama = Selekcja.SelekcjaZwykła(populacja);
                    Osobnik dziecko = Krzyżowanie.KrzyżowanieOX(tata, mama);
                    nowaPopulacja[j] = dziecko;
                }

                populacja = nowaPopulacja;
            }
            stopwatch.Stop();

            Console.WriteLine("Znaleziona ścieżka: ");
            for (int i = 0; i < niebo.genotyp.Count; i++)
                Console.Write(Osobnik.listaMiast[niebo.genotyp[i]].indeks + " ");
            Console.WriteLine("\nDługość trasy: " + niebo.DługośćTrasy);

            Console.ReadKey();
        }
    }
}
