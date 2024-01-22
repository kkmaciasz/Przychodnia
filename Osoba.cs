using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Przychodnia
{
    public abstract class Osoba
    {
        string imie;
        string nazwisko;
        string pesel;
        DateTime dataUrodzenia;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{11}$"))
                {
                    throw new ArgumentException("Niepoprawny numer PESEL!");
                }
                pesel = value;
            }
        }
        public DateTime DataUrodzenia
        { 
            get => dataUrodzenia;
            set
            {
                if (value <= DateTime.Now)
                {
                    dataUrodzenia = value;
                }
                else
                {
                    throw new ArgumentException("Data urodzenia nie może być większa niż dzisiejsza data!");
                }
            }
        }

        protected Osoba()
        {

        }
        protected Osoba(string imie, string nazwisko, string pesel, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            DataUrodzenia = dataUrodzenia;
        }
    }
}
