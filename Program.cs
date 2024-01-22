using System;

namespace Przychodnia
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*List<EnumSpecjalizacja> specLek1 = new List<EnumSpecjalizacja>();
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
            

            Pacjent pacjent1 = new Pacjent("Fryderyk", "Wójcik", "98072206615", new DateTime(1998, 7, 25), "151515151"); //tel jednak string!
            List<Pacjent> listaPacjentow = new List<Pacjent>();
            Przychodnia przychodnia = new Przychodnia(listaLekarzy, listaPacjentow, listaWizyt);
            przychodnia.DodajPacjenta(pacjent1);
            //Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            //Console.WriteLine(przychodnia.WypiszPacjentow());

            Wizyta wizyta = new Wizyta(termin1, pacjent1, lekarz1);
            //Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            przychodnia.ZapiszNaWizyte(pacjent1, EnumSpecjalizacja.kardiologia);*/

            List<Wizyta> listaWizyt = new List<Wizyta>();
            List<Lekarz> listaLekarzy = new List<Lekarz>();
            List<Pacjent> listaPacjentow = new List<Pacjent>();

            Przychodnia przychodnia = new Przychodnia(listaLekarzy, listaPacjentow, listaWizyt);


            List<EnumSpecjalizacja> specLek1 = new List<EnumSpecjalizacja>();
            specLek1.Add(EnumSpecjalizacja.kardiologia);
            specLek1.Add(EnumSpecjalizacja.pediatria);
            List<EnumSpecjalizacja> specLek2 = new List<EnumSpecjalizacja>();
            specLek2.Add(EnumSpecjalizacja.ortopedia);
            List<EnumSpecjalizacja> specLek3 = new List<EnumSpecjalizacja>();
            specLek3.Add(EnumSpecjalizacja.lekarzRodzinny);
            List<EnumSpecjalizacja> specLek4 = new List<EnumSpecjalizacja>();
            specLek4.Add(EnumSpecjalizacja.chirurgia);
            specLek4.Add(EnumSpecjalizacja.kardiologia);
            List<EnumSpecjalizacja> specLek5 = new List<EnumSpecjalizacja>();
            specLek5.Add(EnumSpecjalizacja.laryngologia);
            Lekarz lekarz1 = new Lekarz("Adam", "Nowak", "12345678999", new DateTime(1985, 5, 5), specLek1);
            Lekarz lekarz2 = new Lekarz("Wiktor", "Kowalski", "11928374555", new DateTime(1975, 10, 12), specLek2);
            Lekarz lekarz3 = new Lekarz("Anna", "Kot", "12324486999", new DateTime(1989, 12, 5), specLek3);
            Lekarz lekarz4 = new Lekarz("Piotr", "Wójcik", "14589678999", new DateTime(1995, 9, 27), specLek4);
            Lekarz lekarz5 = new Lekarz("Adam", "Wróbel", "69845678999", new DateTime(1965, 11, 5), specLek5);
            Termin termin1 = new Termin(new DateTime(2028, 2, 22, 15, 30, 0));
            Termin termin2 = new Termin(new DateTime(2024, 1, 23, 12, 0, 0));
            Termin termin3 = new Termin(new DateTime(2025, 5, 4, 13, 30, 0));
            Termin termin4 = new Termin(new DateTime(2024, 5, 4, 15, 0, 0));
            Termin termin5 = new Termin(new DateTime(2024, 2, 4, 14, 15, 0));
            Termin termin6 = new Termin(new DateTime(2024, 8, 10, 9, 15, 0));
            Termin termin7 = new Termin(new DateTime(2024, 11, 17, 14, 45, 0));
            Termin termin8 = new Termin(new DateTime(2024, 7, 8, 18, 30, 0));
            Termin termin9 = new Termin(new DateTime(2024, 3, 12, 10, 0, 0));
            Termin termin10 = new Termin(new DateTime(2024, 6, 5, 16, 20, 0));
            Termin termin11 = new Termin(new DateTime(2025, 9, 5, 16, 0, 0));
            Termin termin12 = new Termin(new DateTime(2025, 12, 20, 11, 30, 0));
            Termin termin13 = new Termin(new DateTime(2024, 4, 8, 14, 45, 0));
            Termin termin14 = new Termin(new DateTime(2024, 6, 15, 10, 0, 0));
            Termin termin15 = new Termin(new DateTime(2024, 1, 28, 13, 15, 0));

            lekarz1.WolneTerminy.Add(termin1);
            lekarz1.WolneTerminy.Add(termin2);
            lekarz1.WolneTerminy.Add(termin3);

            lekarz2.WolneTerminy.Add(termin4);
            lekarz2.WolneTerminy.Add(termin5);

            lekarz3.WolneTerminy.Add(termin6);
            lekarz3.WolneTerminy.Add(termin7);
            lekarz3.WolneTerminy.Add(termin8);

            lekarz4.WolneTerminy.Add(termin9);
            lekarz4.WolneTerminy.Add(termin10);

            lekarz5.WolneTerminy.Add(termin11);
            lekarz5.WolneTerminy.Add(termin12);
            lekarz5.WolneTerminy.Add(termin13);
            lekarz5.WolneTerminy.Add(termin14);
            lekarz5.WolneTerminy.Add(termin15);

            //Console.WriteLine(lekarz1.WypiszWolneTerminy());

            przychodnia.DodajLekarza(lekarz1);
            przychodnia.DodajLekarza(lekarz2);
            przychodnia.DodajLekarza(lekarz3);
            przychodnia.DodajLekarza(lekarz4);
            przychodnia.DodajLekarza(lekarz5);

            //Console.WriteLine(przychodnia.WypiszPacjentow());
            
            //Console.WriteLine(przychodnia.WypiszMozliweTerminy(EnumSpecjalizacja.kardiologia));


            Pacjent pacjent1 = new Pacjent("Fryderyk", "Sikora", "98072206615", new DateTime(1998, 7, 25), "151515151");
            Pacjent pacjent2 = new Pacjent("Anna", "Wiśniewska", "02121578932", new DateTime(2002, 12, 15), "252525252");
            Pacjent pacjent3 = new Pacjent("Michał", "Kowalski", "90060123456", new DateTime(1990, 6, 1), "363636363");
            Pacjent pacjent4 = new Pacjent("Alicja", "Wiśniewska", "83040211223", new DateTime(1983, 4, 2), "474747474");
            Pacjent pacjent5 = new Pacjent("Karol", "Dąbrowski", "75081234567", new DateTime(1975, 8, 12), "585858585");

            przychodnia.DodajPacjenta(pacjent1);
            przychodnia.DodajPacjenta(pacjent2);
            przychodnia.DodajPacjenta(pacjent3);
            przychodnia.DodajPacjenta(pacjent4);
            przychodnia.DodajPacjenta(pacjent5);

            przychodnia.ZapiszXML("przychodnia.xml");

            //Console.WriteLine(przychodnia.WypiszPacjentow());

            //Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            //Console.WriteLine(lekarz5.WypiszWolneTerminy());
            /*
            Wizyta wizyta1 = new Wizyta(termin1, pacjent1, lekarz1);
            Wizyta wizyta2 = new Wizyta(termin2, pacjent2, lekarz2);
            Wizyta wizyta3 = new Wizyta(termin3, pacjent3, lekarz3);
            Wizyta wizyta4 = new Wizyta(termin4, pacjent4, lekarz4);
            Wizyta wizyta5 = new Wizyta(termin5, pacjent5, lekarz5);

            //Console.WriteLine(przychodnia.WypiszTerminyPoLekarzu(lekarz1));
            przychodnia.ZapiszNaWizyte(pacjent1, EnumSpecjalizacja.kardiologia);

            */
        }
    }
}
