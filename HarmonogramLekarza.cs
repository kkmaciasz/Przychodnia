using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class HarmonogramLekarza
    {
        List<Termin> wolneTerminy;
        List<Termin> zajeteTerminy;

        public List<Termin> WolneTerminy { get => wolneTerminy; set => wolneTerminy = value; }
        public List<Termin> ZajeteTerminy { get => zajeteTerminy; set => zajeteTerminy = value; }

        public HarmonogramLekarza()
        {
            WolneTerminy = new List<Termin>();
            ZajeteTerminy = new List<Termin>();
        }

        public void DodajTermin(Termin termin)
        {
            WolneTerminy.Add(termin);
        }

        public void ZajmijTermin(Termin termin)
        {
            if (WolneTerminy.Contains(termin))
            {
                WolneTerminy.Remove(termin);
                ZajeteTerminy.Add(termin);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego terminu!");
            }
        }

        public void OdwolajWizyte(Termin termin)
        {
            if (ZajeteTerminy.Contains(termin))
            {
                ZajeteTerminy.Remove(termin);
                WolneTerminy.Add(termin);
            }
            else
            {
                Console.WriteLine("Nie ma w bazie takiego terminu!");
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
