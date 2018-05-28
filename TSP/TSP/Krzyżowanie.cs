using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class Krzyżowanie
    {
        public static Osobnik Krzyżuj(string typ, Osobnik tata, Osobnik mama)
        {
            if (typ == "OX")
                return KrzyżowanieOX(tata, mama);
            else if (typ == "przezWymianePodtras")
                return KrzyżowaniePrzezWymianęPodtras(tata, mama);
            else
            {
                Console.WriteLine("Podano błędny typ krzyżowania.");
                return null;
            }
        }

        public static Osobnik KrzyżowanieOX(Osobnik tata, Osobnik mama)
        {
            int punkt1 = Program.random.Next(tata.genotyp.Count);
            int punkt2 = Program.random.Next(tata.genotyp.Count);

            if (punkt1 > punkt2)
            {
                int temp = punkt1;
                punkt1 = punkt2;
                punkt2 = temp;
            }

            Osobnik dziecko = new Osobnik();
            for (int i = punkt1 + 1; i <= punkt2; i++)
                dziecko.genotyp.Add(tata.genotyp[i]);

            for (int i = 0; i < tata.genotyp.Count; i++)
            {
                if (!dziecko.genotyp.Contains(mama.genotyp[i]))
                    dziecko.genotyp.Add(mama.genotyp[i]);
            }

            if (Program.random.NextDouble() < Program.prawdopodobieństwoMutacji)
                dziecko = dziecko.Mutacja();

            Program.niebo = Osobnik.PorównajOsobników(dziecko, Program.niebo);

            return dziecko;
        }

        public static Osobnik KrzyżowaniePrzezWymianęPodtras(Osobnik tata, Osobnik mama)
        {
            SortedList<int, int> tataGenotypŚcieżkowy = ZmianaReprezentacjiNaŚcieżkową(tata);
            SortedList<int, int> mamaGenotypŚcieżkowy = ZmianaReprezentacjiNaŚcieżkową(mama);

            SortedList<int, int> dzieckoGenotypŚcieżkowy = new SortedList<int, int>();

            int przejścia = tataGenotypŚcieżkowy.Count;
            int długość = Program.random.Next(1, przejścia);
            bool flaga = true;       //true - tata, flase - mama

            for (int i = 0; i < przejścia; i++)
            {
                długość--;
                if (długość == 0)
                {
                    flaga = !flaga;
                    długość = Program.random.Next(1, przejścia);
                }

                if (flaga) //tata
                {
                    if (!dzieckoGenotypŚcieżkowy.ContainsValue(tataGenotypŚcieżkowy[i]))
                        dzieckoGenotypŚcieżkowy.Add(i, tataGenotypŚcieżkowy[i]);
                    else if (!dzieckoGenotypŚcieżkowy.ContainsValue(mamaGenotypŚcieżkowy[i]))
                        dzieckoGenotypŚcieżkowy.Add(i, mamaGenotypŚcieżkowy[i]);
                }
                else   //mama
                {
                    if (!dzieckoGenotypŚcieżkowy.ContainsValue(mamaGenotypŚcieżkowy[i]))
                        dzieckoGenotypŚcieżkowy.Add(i, mamaGenotypŚcieżkowy[i]);
                    else if (!dzieckoGenotypŚcieżkowy.ContainsValue(tataGenotypŚcieżkowy[i]))
                        dzieckoGenotypŚcieżkowy.Add(i, tataGenotypŚcieżkowy[i]);
                }
            }

            if (dzieckoGenotypŚcieżkowy.Count < przejścia)
            {
                for (int i = 0; i < przejścia; i++)
                {
                    if (!dzieckoGenotypŚcieżkowy.ContainsValue(tataGenotypŚcieżkowy[i]))
                    {
                        for (int j = 0; j < przejścia; j++)
                        {
                            if (!dzieckoGenotypŚcieżkowy.ContainsKey(j))
                            {
                                dzieckoGenotypŚcieżkowy.Add(j, tataGenotypŚcieżkowy[i]);
                                break;
                            }
                        }
                    }
                }
            }

            return ZmianaReprezentacjiNaŚcieżkową(dzieckoGenotypŚcieżkowy);
        }

        public static SortedList<int, int> ZmianaReprezentacjiNaŚcieżkową(Osobnik osobnik)
        {
            SortedList<int, int> ścieżka = new SortedList<int, int>();

            for (int i = 0; i < osobnik.genotyp.Count - 1; i++)
                ścieżka.Add(osobnik.genotyp[i], osobnik.genotyp[i + 1]);

            ścieżka.Add(osobnik.genotyp[osobnik.genotyp.Count - 1], osobnik.genotyp[0]);

            return ścieżka;
        }

        public static Osobnik ZmianaReprezentacjiNaŚcieżkową(SortedList<int, int> ścieżka)
        {
            Osobnik osobnik = new Osobnik();
            int indeks = 0;
            int element = 0;
            osobnik.genotyp.Add(ścieżka.Keys[indeks]);
            
            for (int i = 0; i < ścieżka.Count; i++)
            {
                element = ścieżka.Values[indeks];
                osobnik.genotyp.Add(element);
                indeks = ścieżka.IndexOfKey(element);
            }

            osobnik.genotyp.RemoveAt(osobnik.genotyp.Count - 1);

            return osobnik;
        }
    }
}
