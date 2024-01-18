using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Wizyta
    {
        Termin termin;
        Pacjent pacjent;
        Lekarz lekarz;

        public Pacjent Pacjent { get => pacjent; set => pacjent = value; }
        public Termin Termin { get => termin; set => termin = value; } //exception do boola terminu
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }

        public Wizyta(Termin termin, Pacjent pacjent, Lekarz lekarz)
        {
            Termin = termin;
            Pacjent = pacjent;
            Lekarz = lekarz;
            termin.Wolny = false;
        }

        public override string ToString()
        {
            return $"{Termin.Data}, pacjent: {Pacjent}, lekarz: {Lekarz}";
        }


    }
}
