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
using System.Windows.Shapes;

namespace PCVerwaltung
{
    public partial class KundenViewBearbeiten : UserControl
    {
        private Kunde? _selected;

        public KundenViewBearbeiten()
        {
            InitializeComponent();
            DataContext = (App)Application.Current;

            // Formular sichtbar, Save/Cancel erst verstecken
            btnSave.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            _selected = dgCustomers.SelectedItem as Kunde;
            if (_selected == null)
            {
                MessageBox.Show("Bitte zuerst einen Kunden in der Tabelle auswählen.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Felder füllen (Tabelle bleibt sichtbar)
            txtVornameEdit.Text = _selected.Vorname;
            txtNachnameEdit.Text = _selected.Nachname;
            txtStrasseEdit.Text = _selected.Strasse;
            txtHausnummerEdit.Text = _selected.Hausnummer;
            txtPLZEdit.Text = _selected.PLZ;
            txtOrtEdit.Text = _selected.Ort;
            txtTelefonEdit.Text = _selected.Telefon;
            txtEmailEdit.Text = _selected.Email;

            // Buttons umschalten
            btnEdit.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (_selected == null) return;
            _selected.Vorname = txtVornameEdit.Text.Trim();
            _selected.Nachname = txtNachnameEdit.Text.Trim();
            _selected.Strasse = txtStrasseEdit.Text.Trim();
            _selected.Hausnummer = txtHausnummerEdit.Text.Trim();
            _selected.PLZ = txtPLZEdit.Text.Trim();
            _selected.Ort = txtOrtEdit.Text.Trim();
            _selected.Telefon = txtTelefonEdit.Text.Trim();
            _selected.Email = txtEmailEdit.Text.Trim();

            dgCustomers.Items.Refresh();

            btnEdit.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            _selected = null;
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            _selected = null;
        }
    }
}

