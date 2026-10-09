using PCVerwaltung.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCVerwaltung
{
    /// <summary>
    /// Interaktionslogik für RamView.xaml
    /// </summary>
    public partial class RamView : UserControl
    {
        public RamView()
        {
            InitializeComponent();
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            // Alte Fehler löschen
            ClearAllErrors();

            bool ok = true;

            // Hersteller überprüfen
            if (string.IsNullOrWhiteSpace(txtHersteller.Text))
            {
                SetError(txtHersteller, "Bitte Hersteller angeben.");
                ok = false;
            }

            // Kapazität überprüfen
            int kapazitaet = 0;

            if (!int.TryParse(txtKapazitaet.Text, out kapazitaet))
            {
                SetError(txtKapazitaet, "Die Kapazität muss eine ganze Zahl sein.");
                ok = false;
            }
            else if (kapazitaet <= 0)
            {
                SetError(txtKapazitaet, "Die Kapazität muss größer als 0 sein.");
                ok = false;
            }

            // Taktfrequenz überprüfen
            int taktfrequenz = 0;

            if (!int.TryParse(txtTaktfrequenz.Text, out taktfrequenz))
            {
                SetError(txtTaktfrequenz, "Die Taktfrequenz muss eine ganze Zahl sein.");
                ok = false;
            }
            else if (taktfrequenz <= 0)
            {
                SetError(txtTaktfrequenz, "Die Taktfrequenz muss größer als 0 sein.");
                ok = false;
            }

            // Preis überprüfen
            decimal preis = 0;

            if (!decimal.TryParse(
                txtPreis.Text,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture,
                out preis))
            {
                SetError(txtPreis, "Bitte einen gültigen Preis eingeben.");
                ok = false;
            }
            else if (preis < 0)
            {
                SetError(txtPreis, "Der Preis darf nicht negativ sein.");
                ok = false;
            }

            // Bei Fehlern abbrechen
            if (!ok)
                return;

            // RAM-Objekt erstellen
            var data = new Ram(
                txtHersteller.Text.Trim(),
                kapazitaet,
                taktfrequenz,
                preis
            );

            // Anzeige
            MessageBox.Show(
                $"Gespeichert:\n\n" +
                $"Hersteller: {data.Hersteller}\n" +
                $"Kapazität: {data.Kapazitaet} GB\n" +
                $"Taktfrequenz: {data.Taktfrequenz} MHz\n" +
                $"Preis: {data.Preis:N2} €",
                "RAM",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            // Felder zurücksetzen
            ResetFields();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtHersteller.Text = "";
            txtKapazitaet.Text = "";
            txtTaktfrequenz.Text = "";
            txtPreis.Text = "";

            ClearAllErrors();
        }

        #region Validation

        private static readonly Brush ErrorBrush =
            new SolidColorBrush(Color.FromRgb(220, 20, 60));

        private void SetError(Control c, string msg)
        {
            c.BorderBrush = ErrorBrush;
            c.BorderThickness = new Thickness(1.5);
            c.ToolTip = msg;
        }

        private void ClearError(Control c)
        {
            c.ClearValue(Border.BorderBrushProperty);
            c.ClearValue(Border.BorderThicknessProperty);
            c.ClearValue(ToolTipProperty);
        }

        private void ClearAllErrors()
        {
            ClearError(txtHersteller);
            ClearError(txtKapazitaet);
            ClearError(txtTaktfrequenz);
            ClearError(txtPreis);
        }

        #endregion
    }
}