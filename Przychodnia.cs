using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Przychodnia
    {
        //przetestowac dzialanie WSZYSTKICH funkcji
        //ZROBIĆ SERIALIZACJĘ
        List<Lekarz> listaLekarzy;
        List<Pacjent> listaPacjentow;
        List<Wizyta> listaWizyt;

        public List<Lekarz> ListaLekarzy { get => listaLekarzy; set => listaLekarzy = value; }
        public List<Pacjent> ListaPacjentow { get => listaPacjentow; set => listaPacjentow = value; }
        public List<Wizyta> ListaWizyt { get => listaWizyt; set => listaWizyt = value; }

        //te konstruktory nie wszystkie sa potrzebne - na razie uzywam niektorych od testowania, pozniej sie je usunie
        public Przychodnia(List<Lekarz> listaLekarzy, List<Pacjent> listaPacjentow, List<Wizyta> listaWizyt)
        {
            ListaLekarzy = listaLekarzy;
            ListaPacjentow = listaPacjentow;
            ListaWizyt = listaWizyt;
        }
        public Przychodnia(List<Lekarz> listaLekarzy)
        {
            ListaLekarzy = listaLekarzy;
        }
        public Przychodnia(List<Pacjent> listaPacjentow)
        {
            ListaPacjentow = listaPacjentow;
        }

        private int WiekLekarza(Lekarz lekarz)
        {
            DateTime dzisiaj = DateTime.Today;
            int wiek = dzisiaj.Year - lekarz.DataUrodzenia.Year;

            // Sprawdzenie, czy urodziny lekarza już były w tym roku
            if (dzisiaj.Month < lekarz.DataUrodzenia.Month || (dzisiaj.Month == lekarz.DataUrodzenia.Month && dzisiaj.Day < lekarz.DataUrodzenia.Day))
            {
                wiek--;
            }
            return wiek;
        }

        public void DodajLekarza(Lekarz lekarz)
        {
            foreach (Lekarz l in ListaLekarzy)
            {
                if (l.Pesel == lekarz.Pesel)
                {
                    throw new TakiSamPeselException();
                }
            }
            if (WiekLekarza(lekarz) < 26)
            {
                throw new NiedozwoloneZatrudnienieException();
            }
            else
            {
                ListaLekarzy.Add(lekarz);
            }
        }

        public void DodajPacjenta(Pacjent pacjent) 
        {
            foreach (Pacjent p in ListaPacjentow)
            {
                if (p.Pesel == pacjent.Pesel)
                {
                    throw new TakiSamPeselException();
                }
            }
            ListaPacjentow.Add(pacjent);
        }

        public void UsunLekarza(Lekarz lekarz)
        {
            if (ListaLekarzy.Contains(lekarz))
            {
                ListaLekarzy.Remove(lekarz);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego lekarza!");
            }
        }

        public void UsunPacjenta(Pacjent pacjent)
        {

            if (ListaPacjentow.Contains(pacjent))
            {
                ListaPacjentow.Remove(pacjent);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego pacjenta!");
            }
        }

        public string WypiszLekarzy()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lista lekarzy: ");
            foreach (Lekarz lekarz in ListaLekarzy)
            {
                sb.Append("\n" + lekarz.ToString());
            }
            return sb.ToString();
        }

        public string WypiszLekarzyPoSpecjalizacji(EnumSpecjalizacja specjalizacja)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lista lekarzy: ");
            foreach (Lekarz lekarz in ListaLekarzy)
            {
                foreach (EnumSpecjalizacja spec in lekarz.Specjalizacje)
                {
                    if (spec == specjalizacja)
                    {
                        sb.Append($"\n {lekarz.Imie} {lekarz.Nazwisko}");
                    }
                }
            }
            return sb.ToString();
        }

        public string WypiszPacjentow()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lista pacjentów: ");
            foreach (Pacjent pacjent in ListaPacjentow)
            {
                sb.Append("\n" + pacjent.ToString());
            }
            return sb.ToString();
        }

        public string WypiszWizyty()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista nadchodzących wizyt: ");
            foreach (Wizyta wizyta in ListaWizyt)
            {
                sb.Append("\n" + wizyta.ToString());
            }
            return sb.ToString();
        }

        public string WypiszTerminyPoSpecjalizacji(EnumSpecjalizacja specjalizacja)
        {
            List<Termin> wolneTerm = new List<Termin>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista możliwych wizyt: ");
            foreach (Lekarz lekarz in ListaLekarzy)
            {
                foreach (EnumSpecjalizacja spec in lekarz.Specjalizacje)
                {
                    if (spec == specjalizacja)
                    {
                        
                        foreach (Termin termin in lekarz.WolneTerminy)
                        {
                            wolneTerm.Add(termin);
                        }
                    }
                }
            }
            wolneTerm.Sort((Termin a, Termin b) => a.Data.CompareTo(b.Data));

            foreach (Termin term in wolneTerm)
            {
                foreach (Lekarz l in ListaLekarzy)
                {
                    foreach (Termin t in l.WolneTerminy)
                    {
                        if (t == term)
                        {
                            sb.AppendLine($"{t.ToString()}, {l.Imie} {l.Nazwisko}");
                        }
                    }
                }
            }
            return sb.ToString();
        }
         
        public string WypiszTerminyPoLekarzu(Lekarz lekarz)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista możliwych wizyt: ");
            sb.Append("\n" + lekarz.Imie.ToString() + " " + lekarz.Nazwisko.ToString() + ":");
            lekarz.TerminyAsc();
            foreach (Termin termin in lekarz.WolneTerminy)
            {
                sb.Append("\n" + termin.ToString());
            }
            return sb.ToString();
        }

        public void Aktualizuj()
        {
            foreach (Lekarz lekarz in ListaLekarzy)
            {
                lekarz.WolneTerminy.RemoveAll(term => term.Data < DateTime.Now);
                ListaWizyt.RemoveAll(wiz => wiz.Termin.Data < DateTime.Now);
            }
            foreach (Pacjent pacjent in ListaPacjentow)
            {
                foreach (Wizyta wizyta in pacjent.ZaplanowaneWizyty)
                {
                    if(wizyta.Termin.Data < DateTime.Now)
                    {
                        pacjent.DotychczasoweWizyty.Add(wizyta);
                    }
                }
                pacjent.ZaplanowaneWizyty.RemoveAll(wiz => wiz.Termin.Data < DateTime.Now);
            }
        }

        private void Zapisz(Pacjent pacjent)
        {
            string lekarz = Console.ReadLine();
            Lekarz wybranyLekarz = new Lekarz();
            int licznik = 0;
            foreach (Lekarz l in ListaLekarzy)
            {
                if (l.Nazwisko == lekarz)
                {
                    Console.WriteLine(WypiszTerminyPoLekarzu(l));
                    wybranyLekarz = l;
                    licznik++;
                }
            }
            if (licznik == 0)
            {
                Console.WriteLine("Nie ma w bazie takiego lekarza.");
            }
            Console.WriteLine("Wybierz datę z powyższych [wpisz w formacie yyyy-MM-dd HH:mm np. 2024-05-04 13:30]:"); 
            string data = Console.ReadLine();
            DateTime.TryParseExact(data, new[] { "yyyy-MM-dd HH:mm" }, null, DateTimeStyles.None, out DateTime date);
            DateTime wybranaData = date;
            Termin termin = new Termin(wybranaData);
            Wizyta wizyta = new Wizyta(termin, pacjent, wybranyLekarz);
            Aktualizuj();
            Console.WriteLine("-----");
            Console.WriteLine(pacjent.WypiszZaplanowaneWizyty());
            pacjent.ZaplanowaneWizyty.Add(wizyta);
            Console.WriteLine(pacjent.WypiszZaplanowaneWizyty());
            Console.WriteLine("-----");
            Console.WriteLine(WypiszWizyty());
            ListaWizyt.Add(wizyta);
            Console.WriteLine(WypiszWizyty());
            Console.WriteLine("-----");
            Console.WriteLine(wybranyLekarz.WypiszWolneTerminy());
            Console.WriteLine(wybranyLekarz.WypiszZajeteTerminy());
            wybranyLekarz.WolneTerminy.RemoveAll(term => term.Data == wybranaData);
            wybranyLekarz.ZajeteTerminy.Add(wizyta);
            Console.WriteLine(wybranyLekarz.WypiszWolneTerminy());
            Console.WriteLine(wybranyLekarz.WypiszZajeteTerminy());
            Console.WriteLine("-----");
            Console.WriteLine(wybranyLekarz.WypiszWolneTerminy());
        }

        public void ZapiszNaWizyte(Pacjent pacjent, EnumSpecjalizacja specjalizacja)
        {
            Console.WriteLine("1.Wybierz termin wizyty u wybranego lekarza. \n2.Wybierz termin wizyty niezależnie od lekarza.");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine($"Wszyscy lekarze o specjalizacji {specjalizacja}:");
                Console.WriteLine(WypiszLekarzyPoSpecjalizacji(specjalizacja));
                Console.WriteLine("Wybierz lekarza (nazwisko):");
                Zapisz(pacjent);
            }
            else if (n == 2)
            {
                Console.WriteLine(WypiszTerminyPoSpecjalizacji(specjalizacja));
                Console.WriteLine("Wybierz lekarza z powyższych (nazwisko):");
                Zapisz(pacjent);
            }
            else { Console.WriteLine("Wybrałeś niepoprawny numer!"); }
        }
    }
}
