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

        public void DodajLekarza(Lekarz lekarz)
        {
            ListaLekarzy.Add(lekarz);
        }

        public void DodajPacjenta(Pacjent pacjent)
        {
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
                sb.Append($"\n {lekarz.Imie} {lekarz.Nazwisko}");
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
                sb.Append($"\n {pacjent.Imie} {pacjent.Nazwisko}");
            }
            return sb.ToString();
        }

        public string WypiszMozliweTerminy(EnumSpecjalizacja specjalizacja)
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
            lekarz.WolneTerminyAsc();
            foreach (Termin termin in lekarz.WolneTerminy)
            {
                sb.Append("\n" + termin.ToString());
            }
            return sb.ToString();
        }

        public void Zapisz(Pacjent pacjent) //nie bede tej funkcji uzywac bezposrednio w programie, ale tylko w innych funkcjach - czy mam zmienic jej dostep albo cos tego typu?
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
            Console.WriteLine("Wybierz datę z powyższych [wpisz w formacie yyyy-MM-dd HH:mm:ss np. 2024-05-04 13:30:00]:"); 
            string data = Console.ReadLine();
            /*if (DateTime.TryParse(data, out DateTime wybranaData)) // dotąd działa ta funkcja, ogólnie jest jeszcze w fazie testow i poprawek
            {
                Console.WriteLine($"Wprowadzona data i godzina: {wybranaData}");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format daty i godziny."); // trzeba jakiegos breaka przy bledach tylko ze break jest do petli
            }*/
            DateTime.TryParseExact(data, new[] { "yyyy-MM-dd HH:mm:ss" }, null, DateTimeStyles.None, out DateTime date);
            DateTime wybranaData = date;
            Termin termin = new Termin(wybranaData);
            Wizyta wizyta = new Wizyta(termin, pacjent, wybranyLekarz);
            Console.WriteLine(wybranyLekarz.WypiszWolneTerminy());
            pacjent.ZaplanowaneWizyty.Add(wizyta);
            ListaWizyt.Add(wizyta);
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
                Console.WriteLine(WypiszMozliweTerminy(specjalizacja));
                Console.WriteLine("Wybierz lekarza z powyższych (nazwisko):");
                Zapisz(pacjent);
            }
            else { Console.WriteLine("Wybrałeś niepoprawny numer!"); }
        }
    }
}
