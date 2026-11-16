using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVerwaltung.Classes
{
    public class CPU
    {
        
        public double Taktfrequenz { get; set; } = 0.0;
        public string Modell { get; set; } = "";
        public int Punkte { get; set; } = 0;

        public CPU(string modell, double taktfrequenz, int punkte)
        {
            Modell = modell;
            Taktfrequenz = taktfrequenz;
            Punkte = punkte;
        }

        
    }
}
