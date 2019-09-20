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
        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand SchliessenCmd { get; set; }
        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Model.Person> Personenliste { get { return Model.Person.Personenliste; } }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            NeuCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    para => true,
                    //Exe:
                    para => 
                    {
                        //Instanzieren eines neuen DetailViews
                        Views.DetailView neuePersonDialog = new Views.DetailView();
                        //Zuweisung eines neuen DetailViewModels als dessen DataContext
                        neuePersonDialog.DataContext = new DetailViewModel();
                        //Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (neuePersonDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person();

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult (wird true, wenn der Benutzer OK klickt)
                        if (neuePersonDialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add((neuePersonDialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );
            //Ändern einer bestehenden Person
            AendernCmd = new CustomCommand
                (
                    //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                    //Fungiert als Null-Prüfung
                    para => para is Model.Person,
                    //Exe:
                    para => 
                    {
                        //Vgl. NeuCmd (s.o.)
                        Views.DetailView personDialog = new Views.DetailView();
                        personDialog.DataContext = new DetailViewModel();
                        //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (personDialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person(para as Model.Person);
                        //Ändern des Titels des neuen DetailViews
                        (personDialog as Views.DetailView).Title = "Ändere " + (para as Model.Person).Vorname + " " + (para as Model.Person).Nachname;

                        if (personDialog.ShowDialog() == true)
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(para as Model.Person)] = (personDialog.DataContext as DetailViewModel).AktuellePerson;
                    }
                );
            //Löschen einer Person
            LoeschenCmd = new CustomCommand(CanExeLoeschen, ExeLoeschen);
            //Schließen des Programms
            SchliessenCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    para => true,
                    //Exe: Schließen der Applikation
                    para => Application.Current.Shutdown()
                );

        }

        //Löschen-Exe:
        private static void ExeLoeschen(object para)
        {
            //Anzeige einer MessageBox, ob Löschvorgang wirklich gewollt ist
            if (MessageBox.Show($"Soll {(para as Model.Person).Vorname} {(para as Model.Person).Nachname} wirklich gelöscht werden?", "Person löschen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                //Löschen der ausgewählten Person
                Model.Person.Personenliste.Remove(para as Model.Person);
        }

        //Löschen-CanExe: s.o.
        private static bool CanExeLoeschen(object para)
        {
            return para is Model.Person;
        }
    }
}
