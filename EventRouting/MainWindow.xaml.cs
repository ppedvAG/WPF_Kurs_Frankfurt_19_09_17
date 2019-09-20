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

namespace EventRouting
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

        //Event, welches von den StackPanels während der Tunneling-Phase geworfen wird
        private void SP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Ausgabe des Namens des werfenden StackPanles (sender)
            TblOutput.Text += (sender as StackPanel).Name + " PreviewMouseDown\n";
            //Das Event wird gehandelt (= Weiterleitung wird unterbunden), wenn der Name des werfenden StackPanels "Grün" ist
            if ((sender as StackPanel).Name == "Yellow") e.Handled = true;
        }

        //Event, welches von den StackPanels während der Bubbleing-Phase geworfen wird
        private void SP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TblOutput.Text += (sender as StackPanel).Name + " MouseDown\n";
        }
    }
}
