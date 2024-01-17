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
        List<OdbytaWizyta> dotychczasoweWizyty;

        public List<OdbytaWizyta> DotychczasoweWizyty { get => dotychczasoweWizyty; set => dotychczasoweWizyty = value; }
        public long Telefon { get => telefon; set => telefon = value; }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, long telefon, List<OdbytaWizyta> dotychczasoweWizyty) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Telefon = telefon;
            DotychczasoweWizyty = new List<OdbytaWizyta>();
        }

        // metoda odbycia wizyty - dodania jej do listy odbytych wizyt
        // wypisz odbyte wizyty
    }
}