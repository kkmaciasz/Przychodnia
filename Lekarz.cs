using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public enum EnumSpecjalizacja
    {
        lekarzRodzinny,
        kardiologia,
        neurologia,
        pediatria,
        geriatria,
        chirurgia,
        ortopedia,
        psychiatria,
        ginekologia,
        urologia,
        dermatologia,
        laryngologia,
        gastrologia,
        anestezjologia,
        fizjoterapia
    }
    public class Lekarz : Osoba
    {
        List<EnumSpecjalizacja> specjalizacje;
        List<Termin> wolneTerminy;
        List<Wizyta> zajeteTerminy;
        List<OdbytaWizyta> odbyteWizyty;

        public List<EnumSpecjalizacja> Specjalizacje { get => specjalizacje; set => specjalizacje = value; }
        public List<Termin> WolneTerminy { get => wolneTerminy; set => wolneTerminy = value; } //ustawic get set zeby przedawnione terminy sie usuwaly
        public List<Wizyta> ZajeteTerminy { get => zajeteTerminy; set => zajeteTerminy = value; }
        public List<OdbytaWizyta> OdbyteWizyty { get => odbyteWizyty; set => odbyteWizyty = value; }

        public Lekarz():base()
        {

        }
        public Lekarz(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, List<EnumSpecjalizacja> specjalizacje) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Specjalizacje = specjalizacje;
            WolneTerminy = new List<Termin>();
            ZajeteTerminy = new List<Wizyta>();
            OdbyteWizyty = new List<OdbytaWizyta>();
        }

        public void DodajTermin(Termin termin)
        {
            WolneTerminy.Add(termin);
        }

        public void ZajmijTermin(Wizyta wizyta)
        {
            if (WolneTerminy.Contains(wizyta.Termin))
            {
                WolneTerminy.Remove(wizyta.Termin);
                ZajeteTerminy.Add(wizyta);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego terminu!");
            }
        }

        public void OdwolajWizyte(Wizyta wizyta)
        {
            if (ZajeteTerminy.Contains(wizyta))
            {
                ZajeteTerminy.Remove(wizyta);
                WolneTerminy.Add(wizyta.Termin);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego terminu!");
            }
        }

        public void OdbytoWizyte(Wizyta wizyta) //do sprawdzenia czy działa
        {

            if (ZajeteTerminy.Contains(wizyta) && wizyta.Termin.Data < DateTime.Now)
            {
                ZajeteTerminy.Remove(wizyta);
                OdbytaWizyta wizyta1 = new OdbytaWizyta(wizyta);
                OdbyteWizyty.Add(wizyta1);
            }
        }

        public string WypiszWolneTerminy()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Termin t in WolneTerminy)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

        // wypisz wolne terminy

        // wypisz zajete terminy

        // wypisz odbyte wizyty

        public List<Termin> Sortuj(List<Termin> list) // sortuj list<wizyta> i sortuj list<odbytaWizyta>
        {
            list.Sort((Termin a, Termin b) => a.Data.CompareTo(b.Data));
            return list;
        }

        public void WolneTerminyAsc()
        {
            WolneTerminy = Sortuj(WolneTerminy);
        }

    }
}
