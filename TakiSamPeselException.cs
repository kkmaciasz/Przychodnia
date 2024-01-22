using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class TakiSamPeselException : Exception
    {
        public TakiSamPeselException() : base("Istnieje już w bazie osoba z takim PESELem!") { }
    }
}
