using System;
using System.Collections.Generic;
using System.Text;

namespace TSP
{
    public class Miasto
    {
        public int indeks;
        public double x;
        public double y;
        public double z;

        public Miasto(int indeks, double x, double y)
        {
            this.indeks = indeks;
            this.x = x;
            this.y = y;
            this.z = indeks % 7;
        }
    }
}
