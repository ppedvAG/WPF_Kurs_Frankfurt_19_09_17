﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM_PersonenDB_Bsp.Model
{
    //Im Model-Teil eines MVVM-Programms werden die Buisness-Klassen abgelegt. Diese Klassen dürfen keine Referenzen auf die anderen MVVM-Teile haben.
    //Model-Klasse 'Person' mit dem IDataErrorInfo-Interface zur Validierung der Benutzereingaben bezüglich der Klassenproperties
    public class Person : IDataErrorInfo
    {
        #region Statische Member
        //Statische Listenproperty zum Ablegen der geladenen Personen (ObservableCollection, damit die GUI über Veränderungen innerhalb der Liste
        //informiert wird)
        public static ObservableCollection<Person> Personenliste { get; set; }

        //Methode, welche Bsp-Daten generiert und damit den Zugriff auf eine Datenbank simuliert
        public static void LadePersonenAusDb()
        {
            Personenliste = new ObservableCollection<Person>();
            Personenliste.Add(new Person() { Vorname = "Otto", Nachname = "Müller", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet = true, Lieblingsfarbe = Colors.Blue, Geschlecht = Gender.Männlich });
            Personenliste.Add(new Person() { Vorname = "Maria", Nachname = "Schmidt", Geburtsdatum = new DateTime(1988, 7, 23), Verheiratet = true, Lieblingsfarbe = Colors.Green, Geschlecht = Gender.Weiblich });
            Personenliste.Add(new Person() { Vorname = "Johannes", Nachname = "Fischer", Geburtsdatum = new DateTime(1973, 12, 7), Verheiratet = false, Lieblingsfarbe = Colors.Yellow, Geschlecht = Gender.Divers });
        }
        #endregion

        #region Properties
        //Felder und Properties der 'Person'-Klasse

        private string vorname;
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        private string nachname;
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }

        private bool verheiratet;
        public bool Verheiratet
        {
            get { return verheiratet; }
            set { verheiratet = value; }
        }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe
        {
            get { return lieblingsfarbe; }
            set { lieblingsfarbe = value; }
        }

        private Gender geschlecht;
        public Gender Geschlecht
        {
            get { return geschlecht; }
            set { geschlecht = value; }
        }
        #endregion

        #region DataErrorInfo
        //Durch das Interface geforderte Properties
        public string Error => String.Empty;

        //Property, welche die Validierungsfehler und deren Fehlermeldungen beinhaltet
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length == 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
                        break;
                    case nameof(Nachname):
                        if (Nachname.Length == 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        break;
                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;
                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Bitte wählen Sie Ihre Lieblingsfarbe aus.";
                        break;
                }
                return String.Empty;
            }
        }
        #endregion

        #region Konstruktoren
        //Parameterloser Standartkonstruktor, welcher die leeren 'Person'-Objekte auf einen Startzustand setzt
        public Person()
        {
            //Die 'Gerburtsdatum'-Property wird auf das aktuelle Datum gesetzt, damit der Benutzer innerhalb der Auswahlmaske nicht so viel suchen muss
            Geburtsdatum = DateTime.Now;
            //Die String-Eigenschaften werden auf "" initialisiert, um GUI-Fehler zu vermeiden
            Vorname = Nachname = "";
        }

        //Kopierkonstruktor, welcher eine 1-zu-1-Kopie eines übergebenen 'Person'-Objekts erzeugt
        public Person(Person altePerson)
        {
            Vorname = altePerson.Vorname;
            Nachname = altePerson.Nachname;
            Verheiratet = altePerson.Verheiratet;
            Lieblingsfarbe = altePerson.Lieblingsfarbe;
            Geschlecht = altePerson.Geschlecht;
            Geburtsdatum = new DateTime(altePerson.Geburtsdatum.Year, altePerson.Geburtsdatum.Month, altePerson.Geburtsdatum.Day);
        } 
        #endregion
    }
}
