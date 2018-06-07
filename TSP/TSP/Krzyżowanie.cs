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

        static Osobnik KrzyżowanieOX(Osobnik tata, Osobnik mama)
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

        static Osobnik KrzyżowaniePrzezWymianęPodtras(Osobnik tata, Osobnik mama)
        {
            SortedList<int, int> tataGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(tata);
            SortedList<int, int> mamaGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(mama);

            SortedList<int, int> dzieckoGenotypSąsiedztwa = new SortedList<int, int>();

            int długośćOsobnika = tataGenotypSąsiedztwa.Count;
            bool flaga = false;  //mama
            int punktPoczątkowy = Program.random.Next(1, tataGenotypSąsiedztwa.Count);
            int długośćObecnejPodtrasy = Program.random.Next(1, tataGenotypSąsiedztwa.Count);
            int losowyIndeksRodzica = 0;
            int wylosowanaWartość = 0;

            dzieckoGenotypSąsiedztwa.Add(punktPoczątkowy, tataGenotypSąsiedztwa[punktPoczątkowy]);
            int ostatnioDodanyKluczDziecka = punktPoczątkowy;
            int ostatnioDodanaWartośćDziecka = tataGenotypSąsiedztwa[punktPoczątkowy];

            tataGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
            tataGenotypSąsiedztwa.RemoveAt(tataGenotypSąsiedztwa.IndexOfValue(ostatnioDodanyKluczDziecka));
            mamaGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
            mamaGenotypSąsiedztwa.RemoveAt(mamaGenotypSąsiedztwa.IndexOfValue(ostatnioDodanyKluczDziecka));

            while (dzieckoGenotypSąsiedztwa.Count < długośćOsobnika - 1)
            {
                if (tataGenotypSąsiedztwa.Count < mamaGenotypSąsiedztwa.Count)
                    długośćObecnejPodtrasy = Program.random.Next(1, tataGenotypSąsiedztwa.Count);
                else
                    długośćObecnejPodtrasy = Program.random.Next(1, mamaGenotypSąsiedztwa.Count);

                if (flaga == true)      //tata
                {
                    for (int i = 0; i < długośćObecnejPodtrasy; i++)
                    {
                        if (tataGenotypSąsiedztwa.ContainsKey(ostatnioDodanaWartośćDziecka) && !dzieckoGenotypSąsiedztwa.ContainsValue(tataGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka]))
                        {
                            dzieckoGenotypSąsiedztwa.Add(ostatnioDodanaWartośćDziecka, tataGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka]);

                            ostatnioDodanyKluczDziecka = ostatnioDodanaWartośćDziecka;
                            ostatnioDodanaWartośćDziecka = tataGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka];
                            if (mamaGenotypSąsiedztwa.ContainsValue(ostatnioDodanaWartośćDziecka))
                                mamaGenotypSąsiedztwa.RemoveAt(mamaGenotypSąsiedztwa.IndexOfValue(ostatnioDodanaWartośćDziecka));
                            tataGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
                        }
                        else //jeśli dziecko już zawiera tę wartość, losujemy jakąś inną z puli wartości taty
                        {
                            losowyIndeksRodzica = Program.random.Next(tataGenotypSąsiedztwa.Count);
                            wylosowanaWartość = tataGenotypSąsiedztwa[tataGenotypSąsiedztwa.Keys[losowyIndeksRodzica]];
                            if (!dzieckoGenotypSąsiedztwa.ContainsValue(wylosowanaWartość))
                            {
                                dzieckoGenotypSąsiedztwa.Add(ostatnioDodanaWartośćDziecka, wylosowanaWartość);

                                ostatnioDodanyKluczDziecka = ostatnioDodanaWartośćDziecka;
                                ostatnioDodanaWartośćDziecka = wylosowanaWartość;
                                if (mamaGenotypSąsiedztwa.ContainsValue(ostatnioDodanaWartośćDziecka))
                                    mamaGenotypSąsiedztwa.RemoveAt(mamaGenotypSąsiedztwa.IndexOfValue(ostatnioDodanaWartośćDziecka));
                                tataGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
                            }
                        }
                    }
                    flaga = false;
                }
                else  //mama
                {
                    for (int i = 0; i < długośćObecnejPodtrasy; i++)
                    {
                        if (mamaGenotypSąsiedztwa.ContainsKey(ostatnioDodanaWartośćDziecka) && !dzieckoGenotypSąsiedztwa.ContainsValue(mamaGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka]))
                        {
                            dzieckoGenotypSąsiedztwa.Add(ostatnioDodanaWartośćDziecka, mamaGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka]);

                            ostatnioDodanyKluczDziecka = ostatnioDodanaWartośćDziecka;
                            ostatnioDodanaWartośćDziecka = mamaGenotypSąsiedztwa[ostatnioDodanaWartośćDziecka];
                            if (tataGenotypSąsiedztwa.ContainsValue(ostatnioDodanaWartośćDziecka))
                                tataGenotypSąsiedztwa.RemoveAt(tataGenotypSąsiedztwa.IndexOfValue(ostatnioDodanaWartośćDziecka));
                            mamaGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
                        }
                        else
                        {
                            losowyIndeksRodzica = Program.random.Next(mamaGenotypSąsiedztwa.Count);
                            wylosowanaWartość = mamaGenotypSąsiedztwa[mamaGenotypSąsiedztwa.Keys[losowyIndeksRodzica]];

                            if (!dzieckoGenotypSąsiedztwa.ContainsValue(wylosowanaWartość))
                            {
                                dzieckoGenotypSąsiedztwa.Add(ostatnioDodanaWartośćDziecka, wylosowanaWartość);

                                ostatnioDodanyKluczDziecka = ostatnioDodanaWartośćDziecka;
                                ostatnioDodanaWartośćDziecka = wylosowanaWartość;
                                if (tataGenotypSąsiedztwa.ContainsValue(ostatnioDodanaWartośćDziecka))
                                    tataGenotypSąsiedztwa.RemoveAt(tataGenotypSąsiedztwa.IndexOfValue(ostatnioDodanaWartośćDziecka));
                                mamaGenotypSąsiedztwa.Remove(ostatnioDodanyKluczDziecka);
                            }
                        }
                    }
                    flaga = true;
                }
            }

            dzieckoGenotypSąsiedztwa.Add(ostatnioDodanaWartośćDziecka, punktPoczątkowy);

            Osobnik dziecko = ZmianaReprezentacjiNaŚcieżkową(dzieckoGenotypSąsiedztwa);

            if (Program.random.NextDouble() < Program.prawdopodobieństwoMutacji)
                dziecko = dziecko.Mutacja();

            Program.niebo = Osobnik.PorównajOsobników(dziecko, Program.niebo);

            return dziecko;
        }

        static SortedList<int, int> ZmianaReprezentacjiNaSąsiedztwa(Osobnik osobnik)
        {
            SortedList<int, int> listaSąsiedztwa = new SortedList<int, int>();

            for (int i = 0; i < osobnik.genotyp.Count - 1; i++)
                listaSąsiedztwa.Add(osobnik.genotyp[i], osobnik.genotyp[i + 1]);

            listaSąsiedztwa.Add(osobnik.genotyp[osobnik.genotyp.Count - 1], osobnik.genotyp[0]);

            return listaSąsiedztwa;
        }

        static Osobnik ZmianaReprezentacjiNaŚcieżkową(SortedList<int, int> listaSąsiedztwa)
        {
            Osobnik osobnik = new Osobnik();
            int indeks = 0;
            int element = 0;
            osobnik.genotyp.Add(listaSąsiedztwa.Keys[indeks]);

            for (int i = 0; i < listaSąsiedztwa.Count; i++)
            {
                element = listaSąsiedztwa.Values[indeks];
                osobnik.genotyp.Add(element);
                indeks = listaSąsiedztwa.IndexOfKey(element);
            }

            osobnik.genotyp.RemoveAt(osobnik.genotyp.Count - 1);

            return osobnik;
        }
    }
}
