using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PersonenDB_Bsp.ViewModels
{
    class StartViewModel : INotifyPropertyChanged
    {
        public CustomCommand LadeCmd { get; set; }
        public CustomCommand OeffneCmd { get; set; }
        public int AnzahlGeladenePersonen { get { return Model.Person.Personenliste?.Count ?? 0; } }

        public StartViewModel()
        {
            LadeCmd = new CustomCommand
                (
                    para => AnzahlGeladenePersonen == 0,
                    para =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnzahlGeladenePersonen"));
                    }
                );
            OeffneCmd = new CustomCommand
                (
                    para => AnzahlGeladenePersonen > 0,
                    para => 
                    {
                        Views.ListView dbAnsicht = new Views.ListView();
                        dbAnsicht.DataContext = new ListViewModel();

                        dbAnsicht.Show();

                        (para as Views.StartView).Close();
                    }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
