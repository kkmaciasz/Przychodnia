using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Pacjent : Osoba
    {
        long telefon;
        List<Wizyta> zaplanowaneWizyty;
        List<Wizyta> dotychczasoweWizyty;

        public List<Wizyta> DotychczasoweWizyty { get => dotychczasoweWizyty; set => dotychczasoweWizyty = value; }
        public long Telefon { get => telefon; set => telefon = value; }
        public List<Wizyta> ZaplanowaneWizyty { get => zaplanowaneWizyty; set => zaplanowaneWizyty = value; }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, long telefon) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Telefon = telefon;
            DotychczasoweWizyty = new List<Wizyta>();
            ZaplanowaneWizyty = new List<Wizyta>();
        }

        public void OdbytoWizyte(Wizyta wizyta) //dopisać do aktualizuj
        {
            if (ZaplanowaneWizyty.Contains(wizyta) && wizyta.Termin.Data < DateTime.Now)
            {
                ZaplanowaneWizyty.Remove(wizyta);
                DotychczasoweWizyty.Add(wizyta);
            }
        }

        public string WypiszOdbyteWizyty()
        {
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
    }
}