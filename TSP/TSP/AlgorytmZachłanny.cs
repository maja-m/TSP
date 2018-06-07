using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TSP
{
    class AlgorytmZachłanny
    {
        public static Osobnik Oblicz(Osobnik trasa)
        {
            int czasObliczeń = 1000 * 60 * 30;  //30 minut

            Stopwatch stoper = new Stopwatch();
            stoper.Start();
            while (stoper.ElapsedMilliseconds <= czasObliczeń)
            {
                Osobnik sąsiad = new Osobnik();
                sąsiad.genotyp = trasa.genotyp.GetRange(0, trasa.genotyp.Count);

                int punkt1 = Program.random.Next(trasa.genotyp.Count);
                int punkt2 = Program.random.Next(trasa.genotyp.Count);
                int temp;

                temp = sąsiad.genotyp[punkt1];
                sąsiad.genotyp[punkt1] = sąsiad.genotyp[punkt2];
                sąsiad.genotyp[punkt2] = temp;

                if (sąsiad.SzybkośćTrasy() != 0 && sąsiad.SzybkośćTrasy() < trasa.SzybkośćTrasy())
                {
                    trasa = sąsiad;
                    //Console.WriteLine(trasa.SzybkośćTrasy());
                }
            }

            stoper.Stop();

            Console.WriteLine("Znaleziona ścieżka: ");
            for (int i = 0; i < trasa.genotyp.Count; i++)
                Console.Write(Osobnik.listaMiast[trasa.genotyp[i]].indeks + " ");
            Console.WriteLine("\nSzybkość trasy: " + trasa.SzybkośćTrasy());

            using (System.IO.StreamWriter zapisator =
            new System.IO.StreamWriter(@"../../Wyniki/Z" + Program.nazwaPlikuWejściowego + "-" + Program.liczbaBaterii + "-" + DateTime.Now.ToString().Replace(':', '-') + ".txt"))
            {
                zapisator.WriteLine("\nSzybkość trasy: " + trasa.SzybkośćTrasy());
                zapisator.WriteLine();

                for (int i = 0; i < trasa.genotyp.Count; i++)
                    zapisator.Write(Osobnik.listaMiast[trasa.genotyp[i]].indeks + " ");
                zapisator.WriteLine();
            }

            return trasa;
        }
    }
}
