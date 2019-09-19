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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            BoolValue = true;

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
            BoolValue = !BoolValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
