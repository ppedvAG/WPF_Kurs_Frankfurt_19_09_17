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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnKlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Änderung der Hintergrundfarbe des Fensters
            WndMain.Background = new SolidColorBrush(Colors.Green);
            //Ausgabe einer MessageBox mit dem Wert des Sliders
            MessageBox.Show(SdrBeispiel.Value.ToString());
        }
        private void Beenden_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des aktuellen Fensters (wenn dies das letzte geöffnete Fenster der Applikation ist, wird die gesamte App geschlossen)
            this.Close();
            //Direktes Beenden der App (inkl. aller Fenster)
            Application.Current.Shutdown();
        }
    }
}
