
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCVerwaltung.Classes
{
    class Rechnung
    {
        // Eigenschaften
        public int Rechnungsnummer { get; set; }
        public DateTime Rechnungsdatum { get; set; }
        public string Kundenname { get; set; }
        public string Kundenadresse { get; set; }
        public List<Rechnungsposition> Positionen { get; set; }

        // Konstruktor
        public Rechnung()
        {
            Rechnungsdatum = DateTime.Now;
            Positionen = new List<Rechnungsposition>();
        }

        // Konstruktor mit Parametern
        public Rechnung(int rechnungsnummer, string kundenname,
                        string kundenadresse)
        {
            Rechnungsnummer = rechnungsnummer;
            Rechnungsdatum = DateTime.Now;
            Kundenname = kundenname;
            Kundenadresse = kundenadresse;
            Positionen = new List<Rechnungsposition>();
        }

        // Rechnungsposition hinzufügen
        public void PositionHinzufuegen(Rechnungsposition position)
        {
            Positionen.Add(position);
        }

        // Gesamtbetrag berechnen
        public decimal GesamtbetragBerechnen()
        {
            return Positionen.Sum(p => p.Gesamtpreis);
        }

        // Rechnung anzeigen
        public void RechnungAnzeigen()
        {
            Console.WriteLine("----- RECHNUNG -----");
            Console.WriteLine("Rechnungsnummer: " + Rechnungsnummer);
            Console.WriteLine("Datum: " + Rechnungsdatum.ToShortDateString());
            Console.WriteLine("Kunde: " + Kundenname);
            Console.WriteLine("Adresse: " + Kundenadresse);

            Console.WriteLine("--------------------");

            foreach (var position in Positionen)
            {
                Console.WriteLine(position.Bezeichnung + " | " +
                                  position.Gesamtpreis + " €");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Gesamtbetrag: " +
                              GesamtbetragBerechnen() + " €");
        }
    }
}
