using System;

namespace Przychodnia
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<EnumSpecjalizacja> specLek1 = new List<EnumSpecjalizacja>();
            specLek1.Add(EnumSpecjalizacja.kardiologia);
            Lekarz lekarz1 = new Lekarz("Adam", "Nowak", specLek1);
            Termin termin1 = new Termin(new DateTime(2028, 2, 22), lekarz1);
            Termin termin2 = new Termin(new DateTime(2020,1, 23), lekarz1);
            Termin termin3 = new Termin(new DateTime(2023, 5, 4), lekarz1);
            lekarz1.Harmonogram.WolneTerminy.Add(termin1);
            lekarz1.Harmonogram.WolneTerminy.Add(termin2);
            lekarz1.Harmonogram.WolneTerminy.Add(termin3);

            //Console.WriteLine(lekarz1.Harmonogram.WypiszWolneTerminy());

            List<Lekarz> listaLekarzy = new List<Lekarz>();
            listaLekarzy.Add(lekarz1);
            Przychodnia przychodnia = new Przychodnia(listaLekarzy);

            Console.WriteLine(przychodnia.WypiszMozliweWizyty(EnumSpecjalizacja.kardiologia));

        }
    }
}