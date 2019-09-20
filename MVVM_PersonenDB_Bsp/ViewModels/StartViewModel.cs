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
        //Im ViewModel-Teil eines MVVM-Programms werden Klassen definiert, welche als Verbindungsstück zwischen den Views und den Modelklassen fungieren.
        //Diese Klassen sind die einzigen Programmteile, welche Referenzen auf Model-Klassen beinhalten. Sie selbst sind jeweils einem View zugrordnet,
        //mit welchem sie (nur) über den DataContext des jeweilgen Views verbunden sind.

        //Command-Properties
        public CustomCommand LadeCmd { get; set; }
        public CustomCommand OeffneCmd { get; set; }
        //Property zur Repräsentation der Anzahl der geladenen Personen (Getter verlinkt an die Model-Klasse)
        public int AnzahlGeladenePersonen { get { return Model.Person.Personenliste?.Count ?? 0; } }


        //Konstruktor
        public StartViewModel()
        {
            LadeCmd = new CustomCommand
                (
                    //CanExe: Cmd kann ausgeführt werden, wenn die Anzahl der geladenen Personen = 0 ist
                    para => this.AnzahlGeladenePersonen == 0,
                    //Exe: führe Methode aus Model aus und informiere die GUI über Veränderung in der 'AnzahlPersonen'-Property
                    para =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnzahlGeladenePersonen"));
                    }
                );
            OeffneCmd = new CustomCommand
                (
                    //CanExe: Cmd kann ausgeführt werden, wenn die Anzahl der geladenen Personen > 0 ist
                    para => this.AnzahlGeladenePersonen > 0,
                    //Exe:
                    para => 
                    {
                        //Instanzierung eines neunen ListViews
                        Views.ListView dbAnsicht = new Views.ListView();
                        //Zuweisung eines neuen ListViewModels als DataContext des neuen ListViews
                        dbAnsicht.DataContext = new ListViewModel();

                        //Anzeigen des neuen ListViews
                        dbAnsicht.Show();

                        //Schließen dieses Fensters (welches über den CommandParameter übergeben wurde)
                        (para as Views.StartView).Close();
                    }
                );
        }

        //Event, welches die GUI über Veränderungen informiert
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
