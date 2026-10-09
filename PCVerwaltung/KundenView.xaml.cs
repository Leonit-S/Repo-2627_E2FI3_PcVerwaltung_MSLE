using PCVerwaltung.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCVerwaltung
{
    /// <summary>
    /// Interaktionslogik für KundenView.xaml
    /// </summary>
    public partial class KundenView : UserControl
    {
        public KundenView()
        {
            InitializeComponent();
            // wie PcBuilder: DataContext auf App setzen, damit Binding zu Customers funktioniert
            DataContext = (App)Application.Current;
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVorname.Text) || string.IsNullOrWhiteSpace(txtNachname.Text))
            {
                MessageBox.Show("Vorname und Nachname sind erforderlich.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var k = new Kunde
            {
                Vorname = txtVorname.Text.Trim(),
                Nachname = txtNachname.Text.Trim(),
                Strasse = txtStrasse.Text.Trim(),
                Hausnummer = txtHausnummer.Text.Trim(),
                PLZ = txtPLZ.Text.Trim(),
                Ort = txtOrt.Text.Trim(),
                Telefon = txtTelefon.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            App.Customers.Add(k);
            dgCustomers.Items.Refresh();

            MessageBox.Show("Kunde gespeichert.", "Gespeichert", MessageBoxButton.OK, MessageBoxImage.Information);
            ResetFields();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e) => ResetFields();

        private void ResetFields()
        {
            txtVorname.Text = " ";
            txtNachname.Text = "";
            txtStrasse.Text = "";
            txtHausnummer.Text = "";
            txtPLZ.Text = "";
            txtOrt.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
        }
    }
}
