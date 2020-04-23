using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BT_Pläne1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool firstInput;

        public MainWindow()
        {
            InitializeComponent();

            

            //updateListView_Bew();
            


        }

        // setzt Listmitarbeiter Listview zurück und liest neu ein

        public void updateListview_MA()
        {
           listMitarbeiter.ItemsSource = null;
            IList<Person> itemMA = Person.getPerson("Mitarbeiter");
            listMitarbeiter.ItemsSource = itemMA;
        }

        public void updateListView_Bew()

        {
            listBewohner.ItemsSource = null;
            IList<Person> itemBew = Person.getPerson("Bewohner");
            listBewohner.ItemsSource = itemBew;


        }

        private void Btn_MA_Click(object sender, RoutedEventArgs e)
        {
            if (!Person.ValidateInput(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text))
            {
                throw new NotImplementedException();
                //TODO: Exception abfangen (vname oder nname leer)
            }     

            if (Person.CheckDBforDuplicate(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text, "Mitarbeiter"))
            {
                Person.CreatePerson(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text, "Mitarbeiter");
                // Nach Klick auf "Übernehmen" wird Textfeld gelöscht 
                Eingabe_Vorname_MA.Text = "";
                Eingabe_Nachname_MA.Text = "";
                updateListview_MA();
            }
            else
            {
                var mes = new Exception("Nicht möglich, da doppelt");
                throw new NotImplementedException();
                //TODO: Exception abfangen (doppelt)

                Console.WriteLine("Geht nicht");

                return;
            }



        }
        private void Btn_Bew_Click(object sender, RoutedEventArgs e)
        {
            if (!Person.ValidateInput(Eingabe_Vorname_Bew.Text, Eingabe_Nachname_Bew.Text))
            {
                throw new NotImplementedException();
                //TODO: Exception abfangen (vname oder nname leer)
            }

            if (Person.CheckDBforDuplicate(Eingabe_Vorname_Bew.Text, Eingabe_Nachname_Bew.Text, "Bewohner"))
            {
                Person.CreatePerson(Eingabe_Vorname_Bew.Text, Eingabe_Nachname_Bew.Text, "Bewohner");
                // Nach Klick auf "Übernehmen" wird Textfeld gelöscht 
                Eingabe_Vorname_Bew.Text = "";
                Eingabe_Nachname_Bew.Text = "";
                updateListView_Bew ();
            }
            else
            {
                var mes = new Exception("Nicht möglich, da doppelt");
                throw new NotImplementedException();
                //TODO: Exception abfangen (doppelt)

                Console.WriteLine("Geht nicht");

                return;
            }



        }



        private void Eingabe_Vorname_MA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Eingabe_Vorname_MA.Text = "";

        }
        private void Eingabe_Vorname_Bew_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Eingabe_Vorname_Bew.Text = "";

        }

        private void Eingabe_Vorname_MA_GotFocus(object sender, RoutedEventArgs e)
        {
            Btn_MA_delete.IsEnabled = false;
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Eingabe_Vorname_MA_GotFocus;
        }

        private void Eingabe_Vorname_Bew_GotFocus(object sender, RoutedEventArgs e)
        {
            Btn_Bew_delete.IsEnabled = false;
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Eingabe_Vorname_Bew_GotFocus;
        }


        private void Eingabe_Nachname_MA_GotFocus(object sender, RoutedEventArgs e)
        {
            Btn_MA_delete.IsEnabled = false;
            if (!firstInput)
            {
                Eingabe_Nachname_MA.Text = "";
                firstInput = true;
            }


            // Eingabe_Nachname_MA.Text = "";
            //TextBox tb = (TextBox)sender;
            //tb.Text = string.Empty;
            //tb.GotFocus -= Eingabe_Nachname_MA_GotFocus;
        }

        private void Eingabe_Nachname_Bew_GotFocus(object sender, RoutedEventArgs e)
        {
            Btn_Bew_delete.IsEnabled = false;
            if (!firstInput)
            {
                Eingabe_Nachname_Bew.Text = "";
                firstInput = true;
            }


            // Eingabe_Nachname_MA.Text = "";
            //TextBox tb = (TextBox)sender;
            //tb.Text = string.Empty;
            //tb.GotFocus -= Eingabe_Nachname_MA_GotFocus;
        }

        private void ma_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            
            Person temp_selection = new Person(); 
           if (listMitarbeiter.SelectedIndex >= 0 )
            {
                temp_selection = (Person)listMitarbeiter.SelectedItems[0];
                Eingabe_Vorname_MA.Text = temp_selection.Vorname;
                Eingabe_Nachname_MA.Text = temp_selection.Nachname;
                Btn_MA_delete.IsEnabled = true;


                ;
            }
           else
            {
                return;
            }



            
            //listMitarbeiter.SelectedItems[0] = null;
        }

        private void Bew_selection_changed(object sender, SelectionChangedEventArgs e)
        {

            Person temp_selection2 = new Person();
            if (listBewohner.SelectedIndex >= 0)
            {
                temp_selection2 = (Person)listBewohner.SelectedItems[0];
                Eingabe_Vorname_Bew.Text = temp_selection2.Vorname;
                Eingabe_Nachname_Bew.Text = temp_selection2.Nachname;
                Btn_Bew_delete.IsEnabled = true;


                ;
            }
            else
            {
                return;
            }




            //listMitarbeiter.SelectedItems[0] = null;
        }

        private void listMitarbeiter_Loaded(object sender, RoutedEventArgs e)
        {
            updateListview_MA();
        }

        private void listBewohner_Loaded(object sender, RoutedEventArgs e)
        {
            updateListView_Bew ();
        }

        private void listBewohner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //updateListView_Bew();
            Person temp_selection = new Person();
            if (listBewohner.SelectedIndex >= 0)
            {
                temp_selection = (Person)listBewohner.SelectedItems[0];
                Eingabe_Vorname_Bew.Text = temp_selection.Vorname;
                Eingabe_Nachname_Bew.Text = temp_selection.Nachname;
                Btn_Bew_delete.IsEnabled = true;


                ;
            }
            else
            {
                return;
            }




            //listMitarbeiter.SelectedItems[0] = null;
        }



        private void Btn_MA_Delete(object sender, RoutedEventArgs e)
        {
            if (Person.ValidateInput(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text))
            {
                Person.loeschePerson(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text, "Mitarbeiter");
               ////// IList<Person> itemMA = Person.getPerson("Mitarbeiter");
                /////listMitarbeiter.ItemsSource = itemMA;
                updateListview_MA();
                Eingabe_Vorname_MA.Text = "";
                Eingabe_Nachname_MA.Text = "";



            }
        }

        private void Btn_Bew_Delete(object sender, RoutedEventArgs e)
        {
            if (Person.ValidateInput(Eingabe_Vorname_Bew.Text, Eingabe_Nachname_Bew.Text))
            {
                Person.loeschePerson(Eingabe_Vorname_Bew.Text, Eingabe_Nachname_Bew.Text, "Bewohner");
                ////// IList<Person> itemMA = Person.getPerson("Mitarbeiter");
                /////listMitarbeiter.ItemsSource = itemMA;
                updateListView_Bew();
                Eingabe_Vorname_Bew.Text = "";
                Eingabe_Nachname_Bew.Text = "";



            }
        }

        private void listMitarbeiter_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            updateListview_MA(); 

        }
        private void listBewohner_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            updateListView_Bew ();

        }

        
    }

}
