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
                return KrzyżowaniePrzezWymianęPodtras();//tata, mama);
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

        //public static Osobnik KrzyżowaniePrzezWymianęPodtras(Osobnik tata, Osobnik mama)
        //{
        //    SortedList<int, int> tataGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(tata);
        //    SortedList<int, int> mamaGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(mama);

        //    SortedList<int, int> dzieckoGenotypSąsiedztwa = new SortedList<int, int>();

        //    int przejścia = tataGenotypSąsiedztwa.Count;
        //    int długość = Program.random.Next(1, przejścia);
        //    bool flaga = true;       //true - tata, flase - mama

        //    for (int i = 0; i < przejścia; i++)
        //    {
        //        długość--;
        //        if (długość == 0)
        //        {
        //            flaga = !flaga;
        //            długość = Program.random.Next(1, przejścia);
        //        }

        //        if (flaga) //tata
        //        {
        //            if (!dzieckoGenotypSąsiedztwa.ContainsValue(tataGenotypSąsiedztwa[i]))
        //                dzieckoGenotypSąsiedztwa.Add(i, tataGenotypSąsiedztwa[i]);
        //            else if (!dzieckoGenotypSąsiedztwa.ContainsValue(mamaGenotypSąsiedztwa[i]))
        //                dzieckoGenotypSąsiedztwa.Add(i, mamaGenotypSąsiedztwa[i]);
        //        }
        //        else   //mama
        //        {
        //            if (!dzieckoGenotypSąsiedztwa.ContainsValue(mamaGenotypSąsiedztwa[i]))
        //                dzieckoGenotypSąsiedztwa.Add(i, mamaGenotypSąsiedztwa[i]);
        //            else if (!dzieckoGenotypSąsiedztwa.ContainsValue(tataGenotypSąsiedztwa[i]))
        //                dzieckoGenotypSąsiedztwa.Add(i, tataGenotypSąsiedztwa[i]);
        //        }
        //    }

        //    if (dzieckoGenotypSąsiedztwa.Count < przejścia)
        //    {
        //        for (int i = 0; i < przejścia; i++)
        //        {
        //            if (!dzieckoGenotypSąsiedztwa.ContainsValue(tataGenotypSąsiedztwa[i]))
        //            {
        //                for (int j = 0; j < przejścia; j++)
        //                {
        //                    if (!dzieckoGenotypSąsiedztwa.ContainsKey(j))
        //                    {
        //                        dzieckoGenotypSąsiedztwa.Add(j, tataGenotypSąsiedztwa[i]);
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return ZmianaReprezentacjiNaŚcieżkową(dzieckoGenotypSąsiedztwa);
        //}

        public static Osobnik KrzyżowaniePrzezWymianęPodtras()//Osobnik tata, Osobnik mama)
        {
            //SortedList<int, int> tataGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(tata);
            //SortedList<int, int> mamaGenotypSąsiedztwa = ZmianaReprezentacjiNaSąsiedztwa(mama);
            SortedList<int, int> tataGenotypSąsiedztwa = new SortedList<int, int>();
            tataGenotypSąsiedztwa.Add(1, 2); tataGenotypSąsiedztwa.Add(2, 3); tataGenotypSąsiedztwa.Add(3, 8); tataGenotypSąsiedztwa.Add(4, 7); tataGenotypSąsiedztwa.Add(5, 9);
            tataGenotypSąsiedztwa.Add(6, 1); tataGenotypSąsiedztwa.Add(7, 4); tataGenotypSąsiedztwa.Add(8, 5); tataGenotypSąsiedztwa.Add(9, 6);

            SortedList<int, int> mamaGenotypSąsiedztwa = new SortedList<int, int>();
            mamaGenotypSąsiedztwa.Add(1, 7); mamaGenotypSąsiedztwa.Add(2, 5); mamaGenotypSąsiedztwa.Add(3, 1); mamaGenotypSąsiedztwa.Add(4, 6); mamaGenotypSąsiedztwa.Add(5, 9);
            mamaGenotypSąsiedztwa.Add(6, 2); mamaGenotypSąsiedztwa.Add(7, 8); mamaGenotypSąsiedztwa.Add(8, 4); mamaGenotypSąsiedztwa.Add(9, 3);

            SortedList<int, int> dzieckoGenotypSąsiedztwa = new SortedList<int, int>();

            int długośćOsobnika = tataGenotypSąsiedztwa.Count;
            int długośćPodtrasy = Program.random.Next(1, długośćOsobnika);
            bool flaga = true;       //true - tata, flase - mama
            int ostatniElementDziecka = 0;
            int nowyOstatniElementDziecka = 0;

            int losowaKrawędź = 1;// Program.random.Next(długośćOsobnika);
            dzieckoGenotypSąsiedztwa.Add(losowaKrawędź, tataGenotypSąsiedztwa[losowaKrawędź]);
            tataGenotypSąsiedztwa.Remove(losowaKrawędź);
            flaga = false;

            for (int i = 0; i < długośćOsobnika-1; i++)
            {
                if (flaga == true) //tata
                {
                    ostatniElementDziecka = dzieckoGenotypSąsiedztwa[losowaKrawędź];        //pamiętaj o zmiennej losowa krawędź!
                    do
                    {
                        if (dzieckoGenotypSąsiedztwa.ContainsKey(ostatniElementDziecka) || dzieckoGenotypSąsiedztwa.ContainsValue(tataGenotypSąsiedztwa[ostatniElementDziecka]))
                        {
                            losowaKrawędź = tataGenotypSąsiedztwa.Keys[Program.random.Next(1, tataGenotypSąsiedztwa.Count - 1)];

                            dzieckoGenotypSąsiedztwa.Add(ostatniElementDziecka, losowaKrawędź);
                            losowaKrawędź = ostatniElementDziecka;
                            mamaGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            tataGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            flaga = true;
                        }
                        else
                        {
                            dzieckoGenotypSąsiedztwa.Add(ostatniElementDziecka, tataGenotypSąsiedztwa[ostatniElementDziecka]);
                            losowaKrawędź = ostatniElementDziecka;
                            tataGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            mamaGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            flaga = false;
                        }
                    } while (flaga == true);
                        
                }
                else //mama
                {
                    ostatniElementDziecka = dzieckoGenotypSąsiedztwa[losowaKrawędź];
                    do
                    {
                        if (dzieckoGenotypSąsiedztwa.ContainsKey(ostatniElementDziecka) || dzieckoGenotypSąsiedztwa.ContainsValue(mamaGenotypSąsiedztwa[ostatniElementDziecka]))
                        {
                            losowaKrawędź = mamaGenotypSąsiedztwa.Keys[Program.random.Next(1, mamaGenotypSąsiedztwa.Count - 1)];

                            dzieckoGenotypSąsiedztwa.Add(ostatniElementDziecka, losowaKrawędź);
                            losowaKrawędź = ostatniElementDziecka;
                            mamaGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            tataGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            flaga = true;

                        }
                        else
                        {
                            dzieckoGenotypSąsiedztwa.Add(ostatniElementDziecka, mamaGenotypSąsiedztwa[ostatniElementDziecka]);
                            losowaKrawędź = ostatniElementDziecka;
                            mamaGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            tataGenotypSąsiedztwa.Remove(ostatniElementDziecka);
                            flaga = true;
                        }
                    } while (flaga == false);
                }
            }

            return ZmianaReprezentacjiNaŚcieżkową(dzieckoGenotypSąsiedztwa);
        }

        public static SortedList<int, int> ZmianaReprezentacjiNaSąsiedztwa(Osobnik osobnik)
        {
            SortedList<int, int> listaSąsiedztwa = new SortedList<int, int>();

            for (int i = 0; i < osobnik.genotyp.Count - 1; i++)
                listaSąsiedztwa.Add(osobnik.genotyp[i], osobnik.genotyp[i + 1]);

            listaSąsiedztwa.Add(osobnik.genotyp[osobnik.genotyp.Count - 1], osobnik.genotyp[0]);

            return listaSąsiedztwa;
        }

        public static Osobnik ZmianaReprezentacjiNaŚcieżkową(SortedList<int, int> listaSąsiedztwa)
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
