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

namespace PersonenDB_Bsp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NeuePersonDialog : Window
    {
        public Person AktuellePerson { get; set; }
        public NeuePersonDialog()
        {
            InitializeComponent();

            this.AktuellePerson = new Person();

            this.DataContext = this.AktuellePerson;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string ausgabe = AktuellePerson.Vorname + " " + AktuellePerson.Nachname + " (" + AktuellePerson.Geschlecht + ")\n" + AktuellePerson.Geburtsdatum.ToShortDateString() + "\n" + AktuellePerson.Lieblingsfarbe.ToString();
            if (AktuellePerson.Verheiratet) ausgabe = ausgabe + "\nIst verheiratet";
            if (MessageBox.Show(ausgabe + "\nAbspeichern?", AktuellePerson.Vorname + " " + AktuellePerson.Nachname, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void BtnAbbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            //Application.Current.Shutdown();
        }
    }
}
