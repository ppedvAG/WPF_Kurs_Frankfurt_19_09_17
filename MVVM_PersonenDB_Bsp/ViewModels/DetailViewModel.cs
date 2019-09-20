using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_PersonenDB_Bsp.ViewModels
{
    class DetailViewModel
    {
        public CustomCommand OkCmd { get; set; }
        public CustomCommand AbbruchCmd { get; set; }
        public Model.Person AktuellePerson { get; set; }

        public DetailViewModel()
        {
            OkCmd = new CustomCommand
                (
                    para => true,
                    para =>
                    {
                        if (MessageBox.Show($"Soll {AktuellePerson.Vorname} {AktuellePerson.Nachname} gespeichert werden?", "Person abspeichern", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            (para as Views.DetailView).DialogResult = true;
                            (para as Views.DetailView).Close();
                        }
                    }
                );
            AbbruchCmd = new CustomCommand
                (
                    para => true,
                    para => (para as Views.DetailView).Close()
                );
        }


    }
}
