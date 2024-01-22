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

        public Lekarz():base()
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

        private List<Termin> SortujTerminy(List<Termin> list)
        {
            list.Sort((Termin a, Termin b) => a.Data.CompareTo(b.Data));
            return list;
        }

        private List<Wizyta> SortujWizyty(List<Wizyta> list)
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
            OdbyteWizyty = SortujWizyty(OdbyteWizyty);
        }

        public string WypiszWolneTerminy()
        {
            TerminyAsc();
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
            WizytyAsc();
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
            OdbyteWizytyAsc();
            StringBuilder sb = new StringBuilder();
            foreach (Wizyta ow in OdbyteWizyty)
            {
                sb.AppendLine(ow.ToString());
            }
            return sb.ToString();
        }

        public string WypiszSpecjalizacje()
        {
            StringBuilder sb = new StringBuilder();
            foreach(EnumSpecjalizacja spec in Specjalizacje)
            {
                sb.Append("  " + spec.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, specjalizacja:{WypiszSpecjalizacje()}";
        }
    }
}
