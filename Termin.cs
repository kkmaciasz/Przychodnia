using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Termin
    {
        DateTime dataWizyty;
        Lekarz lekarz;

        public DateTime DataWizyty { get => dataWizyty; set => dataWizyty = value; }
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public Termin(DateTime dataWizyty, Lekarz lekarz)
        {
            DataWizyty = dataWizyty;
            Lekarz = lekarz;
        }

        public override string ToString()
        {
            return $"{DataWizyty}, {Lekarz.Imie} {Lekarz.Nazwisko}";
        }
    }
}
