using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    class AlgorytmZachłanny
    {
        public static Osobnik Algorytm(Osobnik trasa)
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

            return wynik;
        }
    }
}
