using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Trigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //Mittels des Events aus dem Interface INotifyPropetyChanged wird die GUI darüber informiert, wenn eine Property aus dem Hintergrund verändert wird. Dadurch sind
    //Bindungen und Trigger an .NET-Properties möglich. Der Eventaufruf muss an dem Punkt stattfinden, an dem die GUI über die Veränderung informiert werden soll (siehe Setter)
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialisierung der Property
            BoolValue = true;

            //Setzen des DataContext
            this.DataContext = this;
        }

        private bool boolValue;

        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoolValue")); }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Umändern des Bool-Werts
            BoolValue = !BoolValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
