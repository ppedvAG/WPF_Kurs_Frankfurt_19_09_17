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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Setzen des DataContext des StackPanels auf dieses Objekt (Einfache Bindungen zu Properties in dieser Datei möglich)
            SplDataTemplate.DataContext = this;

            //Erstellen von Bsp-Daten
            Personenliste.Add(new Person() { Vorname = "Jürgen", Nachname = "Meier", Alter = 23 });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Alter = 45 });
            Personenliste.Add(new Person() { Vorname = "Marcel", Nachname = "Fischer", Alter = 36 });
        }

        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du hast geklickt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Erhöhung des Alters der Person im DataContextes des StackPanels
            (SplMaria.DataContext as Person).Alter++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Susanne", Nachname = "Schmidt", Alter = 12 });
        }
    }
}
