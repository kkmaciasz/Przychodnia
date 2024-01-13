﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public enum EnumPlec { K, M }
    public class Pacjent
    {
        string imie;
        string nazwisko;
        string pesel;
        DateTime dataUrodzenia;
        EnumPlec plec;
        string chorobyPrzewlekle;
        List<Wizyta> dotychczasoweWizyty;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public EnumPlec Plec { get => plec; set => plec = value; }
        public string ChorobyPrzewlekle { get => chorobyPrzewlekle; set => chorobyPrzewlekle = value; }
        public List<Wizyta> DotychczasoweWizyty { get => dotychczasoweWizyty; set => dotychczasoweWizyty = value; }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, EnumPlec plec)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            DataUrodzenia = dataUrodzenia;
            Plec = plec;
        }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, EnumPlec plec, string chorobyPrzewlekle)
            : this(imie, nazwisko, pesel, dataUrodzenia, plec)
        {
            ChorobyPrzewlekle = chorobyPrzewlekle;
        }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, EnumPlec plec, List<Wizyta> dotychczasoweWizyty)
            : this(imie, nazwisko, pesel, dataUrodzenia, plec)
        {
            DotychczasoweWizyty = dotychczasoweWizyty;
        }

        public Pacjent(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, EnumPlec plec, string chorobyPrzewlekle, List<Wizyta> dotychczasoweWizyty)
            : this(imie, nazwisko, pesel, dataUrodzenia, plec)
        {
            ChorobyPrzewlekle = chorobyPrzewlekle;
            DotychczasoweWizyty = dotychczasoweWizyty;
        }






    }
}