using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class NiedozwoloneZatrudnienieException : Exception
    {
        public NiedozwoloneZatrudnienieException() : base("Lekarz powinien mieć co najmniej 26 lat!") { }
    }
}
