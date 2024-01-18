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
        List<OdbytaWizyta> dotychczasoweWizyty;

        public List<OdbytaWizyta> DotychczasoweWizyty { get => dotychczasoweWizyty; set => dotychczasoweWizyty = value; }
        public long Telefon { get => telefon; set => telefon = value; }
        public List<Wizyta> ZaplanowaneWizyty { get => zaplanowaneWizyty; set => zaplanowaneWizyty = value; }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, long telefon) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Telefon = telefon;
            DotychczasoweWizyty = new List<OdbytaWizyta>();
            ZaplanowaneWizyty = new List<Wizyta>();
        }

        public void OdbytoWizyte(Wizyta wizyta) //do sprawdzenia czy działa
        {
            if (ZaplanowaneWizyty.Contains(wizyta) && wizyta.Termin.Data < DateTime.Now)
            {
                ZaplanowaneWizyty.Remove(wizyta);
                OdbytaWizyta odbWizyta = new OdbytaWizyta(wizyta);
                DotychczasoweWizyty.Add(odbWizyta);
            }
        }
        // wypisz odbyte wizyty


    }
}