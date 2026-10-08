using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVerwaltung.Classes
{
    class Ram
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public int Kapazitaet { get; set; }

        public Ram(string hersteller, string modell, int kapazitaet)
        {
            Hersteller = hersteller;
            Modell = modell;
            Kapazitaet = kapazitaet;
        }
    }
}
