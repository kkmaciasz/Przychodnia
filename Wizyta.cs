using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Wizyta : Termin
    {
        Pacjent pacjent;
        List<string> powodWizyty;
        string diagnoza;

        public Pacjent Pacjent { get => pacjent; set => pacjent = value; }
        public List<string> PowodWizyty { get => powodWizyty; set => powodWizyty = value; }
        public string Diagnoza { get => diagnoza; set => diagnoza = value; }

        public Wizyta(Pacjent pacjent, List<string> powodWizyty, string diagnoza, DateTime dataWizyty, Lekarz lekarz) : base(dataWizyty, lekarz)
        {
            Pacjent = pacjent;
            PowodWizyty = powodWizyty;
            Diagnoza = diagnoza;
            DataWizyty = dataWizyty;
            Lekarz = lekarz;
        }
    }
}
