using System;

namespace Przychodnia
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<EnumSpecjalizacja> specLek1 = new List<EnumSpecjalizacja>();
            specLek1.Add(EnumSpecjalizacja.kardiologia);
            Lekarz lekarz1 = new Lekarz("Adam", "Nowak", "123456789", new DateTime(1985, 5, 5), specLek1);
            Lekarz lekarz2 = new Lekarz("Wiktor", "Kowalski", "119283745", new DateTime(1975, 5, 3), specLek1);
            Termin termin1 = new Termin(new DateTime(2028, 2, 22, 15, 30, 0));
            Termin termin2 = new Termin(new DateTime(2020,1, 23, 12, 0, 0));
            Termin termin3 = new Termin(new DateTime(2023, 5, 4));
            Termin termin4 = new Termin(new DateTime(2023, 5, 4));
            Termin termin5 = new Termin(new DateTime(2021, 2, 4));
            lekarz1.WolneTerminy.Add(termin1);
            lekarz1.WolneTerminy.Add(termin2);
            lekarz1.WolneTerminy.Add(termin3);
            lekarz2.WolneTerminy.Add(termin4);
            lekarz2.WolneTerminy.Add(termin5);
            //Console.WriteLine(lekarz1.WypiszWolneTerminy());

            List<Wizyta> listaWizyt = new List<Wizyta>();
            


            List<Lekarz> listaLekarzy = new List<Lekarz>();
            listaLekarzy.Add(lekarz1);
            listaLekarzy.Add(lekarz2);

            //Console.WriteLine(przychodnia.WypiszMozliweTerminy(EnumSpecjalizacja.kardiologia));
            

            Pacjent pacjent1 = new Pacjent("Fede", "Valverde", "98072206615", new DateTime(1998, 7, 25), 151515151);
            List<Pacjent> listaPacjentow = new List<Pacjent>();
            Przychodnia przychodnia = new Przychodnia(listaLekarzy, listaPacjentow, listaWizyt);
            przychodnia.DodajPacjenta(pacjent1);
            //Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            //Console.WriteLine(przychodnia.WypiszPacjentow());

            przychodnia.ZapiszNaWizyte(pacjent1, EnumSpecjalizacja.kardiologia);
            /*Wizyta wizyta = new Wizyta(termin1, pacjent1);
            Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            lekarz1.ZajmijTermin(wizyta);
            Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));*/
        }
    }
}
