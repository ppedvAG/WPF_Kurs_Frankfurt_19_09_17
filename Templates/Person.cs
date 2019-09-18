using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        private int alter;
        public int Alter
        {
            get { return alter; }
            set { alter = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alter")); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
