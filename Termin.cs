using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Termin
    {
        DateTime data;
        bool wolny;

        public DateTime Data { get => data; set => data = value; }
        public bool Wolny { get => wolny; set => wolny = value; }

        public Termin(DateTime data)
        {
            Data = data;
            Wolny = true;
        }

        public override string ToString()
        {
            return $"{Data:yyyy-MM-dd HH:mm}";
        }
    }
}
