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

        public Pacjent Pacjent { get => pacjent; set => pacjent = value; }
        public Termin Termin { get => termin; set => termin = value; } //exception do boola terminu
        public Wizyta(Termin termin, Pacjent pacjent)
        {
            Termin = termin;
            Pacjent = pacjent;
            Termin.Wolny = false;
        }

    }
}
