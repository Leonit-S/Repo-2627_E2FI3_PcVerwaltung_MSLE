using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVerwaltung.Classes
{
    class Ram
    {
        public double Taktfrequenz { get; set; } = 0.0;
        public string Modell { get; set; } = "";

        public Ram(string modell, double taktfrequenz)
        {
            Modell = modell;
            Taktfrequenz = taktfrequenz;
        }
    }
}
