using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varosok
{
    internal class Varos
    {
        public string Varos_nev { get; set; }
        public string Orszag { get; set; }
        public double Nepesseg { get; set; }


        public Varos(string sor)
        {
            string[] row = sor.Split(';');
            Varos_nev = row[0];
            Orszag = row[1];
            Nepesseg = Convert.ToDouble(row[2]);
        }

        public override string ToString()
        {
            return $"{Varos_nev} ({Orszag})\t {Nepesseg:.00}M fő";
        }
    }
}
