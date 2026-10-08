using PCVerwaltung.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            // Modell überprüfen
            if (string.IsNullOrWhiteSpace(txtModell.Text))
            {
                SetError(txtModell, "Bitte Modell angeben.");
                ok = false;
            }

            // Kapazität überprüfen
            if (string.IsNullOrWhiteSpace(txtKapazitaet.Text))
            {
                SetError(txtKapazitaet, "Bitte Kapazität angeben.");
                ok = false;
            }

            // Prüfen, ob Kapazität eine Zahl ist
            int kapazitaet;

            if (!int.TryParse(txtKapazitaet.Text, out kapazitaet))
            {
                SetError(txtKapazitaet, "Die Kapazität muss eine Zahl sein.");
                ok = false;
            }
            else if (kapazitaet <= 0)
            {
                SetError(txtKapazitaet, "Die Kapazität muss größer als 0 sein.");
                ok = false;
            }

            // Wenn Fehler vorhanden sind, abbrechen
            if (!ok)
                return;

            // RAM-Objekt erstellen
            var data = new Ram(
                txtHersteller.Text.Trim(),
                txtModell.Text.Trim(),
                kapazitaet
            );

            // Anzeige
            MessageBox.Show(
                $"Gespeichert:\n" +
                $"Hersteller: {data.Hersteller}\n" +
                $"Modell: {data.Modell}\n" +
                $"Kapazität: {data.Kapazitaet} GB",
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
            txtModell.Text = "";
            txtKapazitaet.Text = "";

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
            ClearError(txtModell);
            ClearError(txtKapazitaet);
        }

        #endregion
    }
}

