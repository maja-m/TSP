using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class Krzyżowanie
    {
        public Krzyżowanie ()
        {
            //----------------------------------------------------------------------------------------------------------------------
            //sprawdzanie które krzyżowaine z pliku konfiguracyjnego
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

            //Console.WriteLine("\nSzybkość trasy nieba: " + Program.niebo.SzybkośćTrasy());

            return dziecko;
        }

        public static Osobnik KrzyżowaniePrzezWymianęPodtras(Osobnik tata, Osobnik mama)
        {
            //----------------------------------------------------------------------------------------------------------------------
            SortedList<int, int> tataGenotypŚcieżkowy = ZmianaReprezentacjiNaŚcieżkową(tata);
            SortedList<int, int> mamaGenotypŚcieżkowy = ZmianaReprezentacjiNaŚcieżkową(mama);

            SortedList<int, int> dzieckoGenotypŚcieżkowy = new SortedList<int, int>();

            int przejścia = tataGenotypŚcieżkowy.Count;
            int długość = Program.random.Next(1, 3); //------------------zmienić na długość osobnika
            bool flag = true;       //true - tata, flase - mama

            for (int i = 0; i < przejścia; i++)
            {
                długość--;
                if (długość == 0)
                {
                    flag = !flag;
                    długość = Program.random.Next(1, 3);                               //------------------zmienić na długość osobnika
                }

                if (flag) //tata
                {
                    if (!dzieckoGenotypŚcieżkowy.ContainsValue(tataGenotypŚcieżkowy[i]))
                    {
                        dzieckoGenotypŚcieżkowy.Add(i, tataGenotypŚcieżkowy[i]);
                    }
                    else if (!dzieckoGenotypŚcieżkowy.ContainsValue(mamaGenotypŚcieżkowy[i]))
                    {
                        dzieckoGenotypŚcieżkowy.Add(i, mamaGenotypŚcieżkowy[i]);
                    }
                }
                else   //mama
                {
                    if (!dzieckoGenotypŚcieżkowy.ContainsValue(mamaGenotypŚcieżkowy[i]))
                    {
                        dzieckoGenotypŚcieżkowy.Add(i, mamaGenotypŚcieżkowy[i]);
                    }
                    else if (!dzieckoGenotypŚcieżkowy.ContainsValue(tataGenotypŚcieżkowy[i]))
                    {
                        dzieckoGenotypŚcieżkowy.Add(i, tataGenotypŚcieżkowy[i]);
                    }

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
            Console.WriteLine();
            return null;
        }

        public static SortedList<int, int> ZmianaReprezentacjiNaŚcieżkową(Osobnik osobnik)
        {
            SortedList<int, int> ścieżka = new SortedList<int, int>();

            for (int i = 0; i < osobnik.genotyp.Count - 1; i++)
                ścieżka.Add(osobnik.genotyp[i], osobnik.genotyp[i + 1]);

            ścieżka.Add(osobnik.genotyp[osobnik.genotyp.Count - 1], osobnik.genotyp[0]);
            

            ////int[] ścieżka = new int[osobnik.genotyp.Count];
            //bool flaga = false;

            //for (int i = 0; i < osobnik.genotyp.Count; i++)
            //{
            //    if (flaga == true)
            //        ścieżka[osobnik.genotyp[i]] = osobnik.genotyp[0];
            //    else
            //    {
            //        if (i == osobnik.genotyp.Count - 2)
            //            flaga = true;

            //        ścieżka[osobnik.genotyp[i]] = osobnik.genotyp[i + 1];
            //    }
            //}

            return ścieżka;
        }
    }
}
