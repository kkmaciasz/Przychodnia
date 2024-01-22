using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Pacjent : Osoba, IComparable<Pacjent>
    {
        string telefon;
        List<Wizyta> zaplanowaneWizyty;
        List<Wizyta> dotychczasoweWizyty;

        public string Telefon
        {
            get => telefon;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{9}$"))
                {
                    throw new ArgumentException("Niepoprawny numer telefonu!");
                }
                telefon = value;
            }
        }
        public List<Wizyta> ZaplanowaneWizyty { get => zaplanowaneWizyty; set => zaplanowaneWizyty = value; }
        public List<Wizyta> DotychczasoweWizyty { get => dotychczasoweWizyty; set => dotychczasoweWizyty = value; }

        public Pacjent() : base()
        {

        }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, string telefon) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Telefon = telefon;
            DotychczasoweWizyty = new List<Wizyta>();
            ZaplanowaneWizyty = new List<Wizyta>();
        }
        private List<Wizyta> SortujWizyty(List<Wizyta> list)
        {
            list.Sort((Wizyta a, Wizyta b) => a.Termin.Data.CompareTo(b.Termin.Data));
            return list;
        }

        public void WizytyAsc()
        {
            ZaplanowaneWizyty = SortujWizyty(ZaplanowaneWizyty);
        }

        public void OdbyteWizytyAsc()
        {
            DotychczasoweWizyty = SortujWizyty(DotychczasoweWizyty);
        }

        public string WypiszOdbyteWizyty()
        {
            OdbyteWizytyAsc();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Odbyte wizyty:");
            foreach (Wizyta w in DotychczasoweWizyty)
            {
                sb.AppendLine(w.ToString());
            }
            return sb.ToString();
        }

        public string WypiszZaplanowaneWizyty()
        {
            WizytyAsc();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zaplanowane wizyty:");
            foreach (Wizyta w in ZaplanowaneWizyty)
            {
                sb.AppendLine(w.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }

        public int CompareTo(Pacjent other)
        {
            if (other == null) { return -1; }
            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0) { return cmp; }
            return Imie.CompareTo(other.Imie);
        }
    }
}