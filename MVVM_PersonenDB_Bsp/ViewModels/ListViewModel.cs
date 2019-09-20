using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_PersonenDB_Bsp.ViewModels
{
    class ListViewModel
    {
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand SchliessenCmd { get; set; }
        public ObservableCollection<Model.Person> Personenliste { get { return Model.Person.Personenliste; } }

        public ListViewModel()
        {
            NeuCmd = new CustomCommand
                (
                    para => true,
                    para => 
                    {
                        Views.DetailView neuePersonDialog = new Views.DetailView();
                        neuePersonDialog.DataContext = new DetailViewModel();
                        (neuePersonDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person();

                        if (neuePersonDialog.ShowDialog() == true)
                            Model.Person.Personenliste.Add((neuePersonDialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );
            AendernCmd = new CustomCommand
                (
                    para => para is Model.Person,
                    para => 
                    {
                        Views.DetailView personDialog = new Views.DetailView();
                        personDialog.DataContext = new DetailViewModel();
                        (personDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person(para as Model.Person);
                        (personDialog as Views.DetailView).Title = "Ändere " + (para as Model.Person).Vorname + " " + (para as Model.Person).Nachname;

                        if (personDialog.ShowDialog() == true)
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(para as Model.Person)] = (personDialog.DataContext as DetailViewModel).AktuellePerson;
                    }
                );
            LoeschenCmd = new CustomCommand(CanExeLoeschen, ExeLoeschen);
            SchliessenCmd = new CustomCommand
                (
                    para => true,
                    para => Application.Current.Shutdown()
                );

        }

        private static void ExeLoeschen(object para)
        {
            if (MessageBox.Show($"Soll {(para as Model.Person).Vorname} {(para as Model.Person).Nachname} wirklich gelöscht werden?", "Person löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Model.Person.Personenliste.Remove(para as Model.Person);
        }

        private static bool CanExeLoeschen(object para)
        {
            return para is Model.Person;
        }
    }
}
