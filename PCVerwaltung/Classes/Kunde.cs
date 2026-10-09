using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCVerwaltung.Classes
{
    public class Kunde
    {
        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public string Strasse { get; set; } = string.Empty;
        public string Hausnummer { get; set; } = string.Empty;
        public string PLZ { get; set; } = string.Empty;
        public string Ort { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;

      
        public override string ToString()
        {
            return $"{Vorname} {Nachname}, {Strasse} {Hausnummer}, {PLZ} {Ort}, Email: {Email}, Tel: {Telefon}";
        }   
    }
}
