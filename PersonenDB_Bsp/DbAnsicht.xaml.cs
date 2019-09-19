using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PersonenDB_Bsp
{
    /// <summary>
    /// Interaction logic for DbAnsicht.xaml
    /// </summary>
    public partial class DbAnsicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        public DbAnsicht()
        {
            InitializeComponent();

            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Müller", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Lieblingsfarbe = Colors.Blue, Geschlecht = Gender.Männlich });
            Personenliste.Add(new Person() { Vorname = "Maria", Nachname = "Schmidt", Geburtsdatum = new DateTime(1988, 7, 23), Verheiratet = true, Lieblingsfarbe = Colors.Green, Geschlecht = Gender.Weiblich });
            Personenliste.Add(new Person() { Vorname = "Johannes", Nachname = "Fischer", Geburtsdatum = new DateTime(1973, 12, 7), Verheiratet = false, Lieblingsfarbe = Colors.Yellow, Geschlecht = Gender.Divers });

            this.DataContext = this;
        }

        private void Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Soll {(DgdPersonen.SelectedValue as Person).Vorname} {(DgdPersonen.SelectedValue as Person).Nachname} wirklich gelöscht werden?", "Person löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes)
                Personenliste.Remove(DgdPersonen.SelectedValue as Person);
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            NeuePersonDialog personDialog = new NeuePersonDialog();

            if (personDialog.ShowDialog() == true)
                Personenliste.Add(personDialog.AktuellePerson);
        }

        private void Aendern_Click(object sender, RoutedEventArgs e)
        {
            NeuePersonDialog personDialog = new NeuePersonDialog();
            personDialog.AktuellePerson = new Person(DgdPersonen.SelectedValue as Person);
            personDialog.DataContext = personDialog.AktuellePerson;
            personDialog.Title = personDialog.AktuellePerson.Vorname + " " + personDialog.AktuellePerson.Nachname;

            if (personDialog.ShowDialog() == true)
            {
                Personenliste[Personenliste.IndexOf(DgdPersonen.SelectedValue as Person)] = personDialog.AktuellePerson;
                DgdPersonen.SelectedIndex = Personenliste.IndexOf(personDialog.AktuellePerson);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
