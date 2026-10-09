using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVerwaltung.Classes
{
    public class Ram
    {
        public string Hersteller { get; set; }
        public int Kapazitaet { get; set; }
        public int Taktfrequenz { get; set; }
        public decimal Preis { get; set; }

        public Ram(
            string hersteller,
            int kapazitaet,
            int taktfrequenz,
            decimal preis)
        {
            Hersteller = hersteller;
            Kapazitaet = kapazitaet;
            Taktfrequenz = taktfrequenz;
            Preis = preis;
        }
    }
}
