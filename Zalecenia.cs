using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Zalecenia
    {
        List<Lek> leki;
        string dawkowanie;
        string inneZalecenia;
        DateTime poczatekZwolnienia;
        DateTime koniecZwolnienia;

        public List<Lek> Leki { get => leki; set => leki = value; }
        public string Dawkowanie { get => dawkowanie; set => dawkowanie = value; }
        public string InneZalecenia { get => inneZalecenia; set => inneZalecenia = value; }
        public DateTime PoczatekZwolnienia { get => poczatekZwolnienia; set => poczatekZwolnienia = value; }
        public DateTime KoniecZwolnienia { get => koniecZwolnienia; set => koniecZwolnienia = value; }

        public Zalecenia(List<Lek> leki, string dawkowanie, string inneZalecenia, DateTime poczatekZwolnienia, DateTime koniecZwolnienia)
        {
            Leki = leki;
            Dawkowanie = dawkowanie;
            InneZalecenia = inneZalecenia;
            PoczatekZwolnienia = poczatekZwolnienia;
            KoniecZwolnienia = koniecZwolnienia;
        }

        public string WypiszLeki()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Lek lek in Leki)
            {
                sb.Append(lek.ToString);
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Leki: {WypiszLeki()} ...";
        }
    }
}
