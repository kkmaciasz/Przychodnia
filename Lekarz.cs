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
    public class Lekarz
    {
        string imie;
        string nazwisko;
        List<EnumSpecjalizacja> specjalizacje;
        List<Termin> wolneTerminy;
        List<Wizyta> zajeteTerminy;
        List<OdbytaWizyta> odbyteWizyty;
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public List<EnumSpecjalizacja> Specjalizacje { get => specjalizacje; set => specjalizacje = value; }
        public List<Termin> WolneTerminy { get => wolneTerminy; set => wolneTerminy = value; }
        public List<Wizyta> ZajeteTerminy { get => zajeteTerminy; set => zajeteTerminy = value; }
        public List<OdbytaWizyta> OdbyteWizyty { get => odbyteWizyty; set => odbyteWizyty = value; }

        public Lekarz(string imie, string nazwisko, List<EnumSpecjalizacja> specjalizacje)
        {
            Imie = imie;
            Nazwisko = nazwisko;
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

        public void OdbytoWizyte(Wizyta wizyta)
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

        public List<Termin> Sortuj(List<Termin> list)
        {
            list.Sort((Termin a, Termin b) => a.DataWizyty.CompareTo(b.DataWizyty));
            return list;
        }

        public void WolneTerminyAsc()
        {
            WolneTerminy = Sortuj(WolneTerminy);
        }


    }
}
