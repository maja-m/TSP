using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public class Osobnik
    {
        public static List<Miasto> listaMiast;

        //genotyp to to kolejność występowania miast w ścieżce (po indeksach)
        public List<int> genotyp;
        public int liczbaBateriiOsobnika;

        public Osobnik()
        {
            genotyp = new List<int>();
            liczbaBateriiOsobnika = Program.liczbaBaterii;
        }

        public static Osobnik PorównajOsobników(Osobnik osobnik1, Osobnik osobnik2)
        {
            if (osobnik1.SzybkośćTrasy() < osobnik2.SzybkośćTrasy())
            {
                if (osobnik1.SzybkośćTrasy() != 0)
                    return osobnik1;
                else if (osobnik2.SzybkośćTrasy() != 0)
                    return osobnik2;
                else
                    return osobnik1;
            }
            else
                return osobnik2;
        }

        public double OdległośćMiędzyOSobnikami(int idPierwszego, int idDrugiego)
        {
            var x2 = Math.Pow(listaMiast[idDrugiego].x - listaMiast[idPierwszego].x, 2);
            var y2 = Math.Pow(listaMiast[idDrugiego].y - listaMiast[idPierwszego].y, 2);
            return Math.Sqrt(x2 + y2);
        }

        public Osobnik WymieszajOsobnika()
        {
            Osobnik nowyOsobnik = new Osobnik();
            nowyOsobnik.genotyp = new List<int>(genotyp).OrderBy(x => Program.random.Next()).ToList();
            return nowyOsobnik;
        }

        public Osobnik Mutacja()
        {
            int punkt1 = Program.random.Next(genotyp.Count);
            int punkt2 = Program.random.Next(genotyp.Count);
            int temp = genotyp[punkt1];
            genotyp[punkt1] = genotyp[punkt2];
            genotyp[punkt2] = temp;
            return this;
        }

        public double SzybkośćTrasy()
        {
            double t = 0;
            double ostatnieDobreT = 0;
            double tOdcinka;
            double sOdcinka;
            double sOdcinkaDoBaterii;
            double vOdcinka;
            double v0;
            int liczbaBaterii = liczbaBateriiOsobnika + 1;
            bool flaga = true;

            while (flaga) {
                if (flaga)
                {
                    ostatnieDobreT = t;
                    t = 0;
                    liczbaBaterii--;
                }

                List<double> baterie = new List<double>();
                for (int i = 0; i < liczbaBaterii; i++)
                    baterie.Add(1000);

                for (int i = 0; i < genotyp.Count - 1; i++)
                {
                    //rozładowywanie baterii
                    sOdcinka = OdległośćMiędzyOSobnikami(i, i + 1);
                    sOdcinkaDoBaterii = sOdcinka;

                    while (sOdcinkaDoBaterii > 0)
                    {
                        if (baterie.Count == 0)
                        {
                            t = 0;
                            flaga = false;
                            break;
                        }

                        if (baterie[baterie.Count - 1] < sOdcinkaDoBaterii)
                        {
                            sOdcinkaDoBaterii -= baterie[baterie.Count - 1];
                            baterie.RemoveAt(baterie.Count - 1);
                        }
                        else
                        {
                            baterie[baterie.Count - 1] -= sOdcinkaDoBaterii;
                            sOdcinkaDoBaterii = 0;
                        }
                    }

                    //ładowanie baterii
                    if (genotyp[i] % 5 == 1)
                    {
                        if (baterie.Count != 0)
                            baterie[baterie.Count - 1] = 1000;

                        for (int j = baterie.Count; j < liczbaBaterii; j++)
                            baterie.Add(1000);
                    }

                    //jeśli po dojechaniu nie mamy baterii i nie naładowaliśmy, musimy przerwać jazdę (trasa nie spełnia warunków); błędna trasa zwraca 0
                    if (baterie.Count == 0 || baterie[0] == 0)
                    {
                        t = 0;
                        flaga = false;
                        break;
                    }
                    else
                    {
                        v0 = 10 - (listaMiast[genotyp[i + 1]].z - listaMiast[genotyp[i]].z);
                        vOdcinka = v0 * (1 - 0.01 * baterie.Count);
                        tOdcinka = sOdcinka / vOdcinka;
                        t += tOdcinka;
                    }
                }
            }

            if (ostatnieDobreT != 0 && liczbaBateriiOsobnika > liczbaBaterii + 1)
                liczbaBateriiOsobnika = liczbaBaterii + 1;

            return ostatnieDobreT;
        }
    }
}
