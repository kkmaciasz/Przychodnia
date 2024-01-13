using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

        public string WypiszMozliweWizyty(EnumSpecjalizacja specjalizacja)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista możliwych wizyt: ");
            foreach(Lekarz lekarz in ListaLekarzy)
            {
                foreach(EnumSpecjalizacja spec in lekarz.Specjalizacje)
                {
                    if(spec == specjalizacja)
                    {
                        lekarz.Harmonogram.WolneTerminyAsc();
                        foreach (Termin termin in lekarz.Harmonogram.WolneTerminy)
                        {
                            sb.Append("\n" + termin.ToString());
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
