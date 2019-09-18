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

            SplDataTemplate.DataContext = this;

            Personenliste.Add(new Person() { Vorname = "Jürgen", Nachname = "Meier", Alter = 23 });
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Müller", Alter = 45 });
            Personenliste.Add(new Person() { Vorname = "Marcel", Nachname = "Fischer", Alter = 36 });
        }

        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du hast geklickt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (SplMaria.DataContext as Person).Alter++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Vorname = "Susanne", Nachname = "Schmidt", Alter = 12 });
        }
    }
}
