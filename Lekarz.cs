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
        List<Wizyta> odbyteWizyty;

        public List<EnumSpecjalizacja> Specjalizacje { get => specjalizacje; set => specjalizacje = value; }
        public List<Termin> WolneTerminy { get => wolneTerminy; set => wolneTerminy = value; } 
        public List<Wizyta> ZajeteTerminy { get => zajeteTerminy; set => zajeteTerminy = value; }
        public List<Wizyta> OdbyteWizyty { get => odbyteWizyty; set => odbyteWizyty = value; }

        public Lekarz():base() //po coś mi to było ale zapomniałam po co
        {

        }
        public Lekarz(string imie, string nazwisko, string pesel, DateTime dataUrodzenia, List<EnumSpecjalizacja> specjalizacje) : base(imie, nazwisko, pesel, dataUrodzenia)
        {
            Specjalizacje = specjalizacje;
            WolneTerminy = new List<Termin>();
            ZajeteTerminy = new List<Wizyta>();
            OdbyteWizyty = new List<Wizyta>();
        }

        public void DodajTermin(Termin termin)
        {
            if(!WolneTerminy.Contains(termin))
            {
                WolneTerminy.Add(termin);
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
                OdbyteWizyty.Add(wizyta);
            }
        }

        public string WypiszWolneTerminy()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wolne terminy:");
            foreach (Termin t in WolneTerminy)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

        public string WypiszZajeteTerminy()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zajęte terminy:");
            foreach (Wizyta w in ZajeteTerminy)
            {
                sb.AppendLine(w.ToString());
            }
            return sb.ToString();
        }

        public string WypiszOdbyteWizyty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Wizyta ow in OdbyteWizyty)
            {
                sb.AppendLine(ow.ToString());
            }
            return sb.ToString();
        }

        public List<Termin> SortujTerminy(List<Termin> list)
        {
            list.Sort((Termin a, Termin b) => a.Data.CompareTo(b.Data));
            return list;
        }

        public List<Wizyta> SortujWizyty(List<Wizyta> list)
        {
            list.Sort((Wizyta a, Wizyta b) => a.Termin.Data.CompareTo(b.Termin.Data));
            return list;
        }

        public List<Wizyta> SortujOdbyteWizyty(List<Wizyta> list)
        {
            list.Sort((Wizyta a, Wizyta b) => a.Termin.Data.CompareTo(b.Termin.Data));
            return list;
        }
        public void TerminyAsc()
        {
            WolneTerminy = SortujTerminy(WolneTerminy);
        }

        public void WizytyAsc()
        {
            ZajeteTerminy = SortujWizyty(ZajeteTerminy);
        }

        public void OdbyteWizytyAsc()
        {
            OdbyteWizyty = SortujOdbyteWizyty(OdbyteWizyty);
        }

        public string WypiszSpecjalizacje()
        {
            StringBuilder sb = new StringBuilder();
            foreach(EnumSpecjalizacja spec in Specjalizacje)
            {
                sb.Append(spec.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, specjalizacja: {WypiszSpecjalizacje()}";
        }
    }
}
