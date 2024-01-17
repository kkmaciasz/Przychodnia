using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class OdbytaWizyta
    {
        Wizyta wizyta;
        string diagnoza;
        Zalecenia zalecenia; // czy powinno zawierać obiekt zalecenia czy dziedziczyć po klasie zalecenia?

        public Wizyta Wizyta { get => wizyta; set => wizyta = value; }
        public string Diagnoza { get => diagnoza; set => diagnoza = value; }
        public Zalecenia Zalecenia { get => zalecenia; set => zalecenia = value; }

        public OdbytaWizyta(Wizyta wizyta)
        {
            Wizyta = wizyta;
        }
        public OdbytaWizyta(Wizyta wizyta, string diagnoza)
        {
            Wizyta = wizyta;
            Diagnoza = diagnoza;
        }
    }
}
