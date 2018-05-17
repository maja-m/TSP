using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class AlgorytmZachłanny
    {
        public static Osobnik Oblicz(Osobnik trasa)
        {
            Osobnik wynik = new Osobnik();
            int pierwszeMiasto = trasa.genotyp[0];
            wynik.genotyp.Add(pierwszeMiasto);
            int najbliższeMiasto;
            double odległość = 0; 
            int liczbaMiast = trasa.genotyp.Count;
            trasa.genotyp.Remove(pierwszeMiasto);

            for (int j = 1; j < liczbaMiast; j++)
            {
                najbliższeMiasto = trasa.genotyp[0];
                odległość = trasa.OdległośćMiędzyOSobnikami(pierwszeMiasto, najbliższeMiasto);
                
                for (int i = 0; i < trasa.genotyp.Count; i++)
                {
                    if (pierwszeMiasto != trasa.genotyp[i])
                    {
                        if (trasa.OdległośćMiędzyOSobnikami(pierwszeMiasto, trasa.genotyp[i]) < odległość)
                        {
                            najbliższeMiasto = trasa.genotyp[i];
                        }
                    }

                }
                wynik.genotyp.Add(najbliższeMiasto);
                trasa.genotyp.Remove(najbliższeMiasto);
                pierwszeMiasto = najbliższeMiasto;
            }

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

            return wynik;
        }
    }
}
