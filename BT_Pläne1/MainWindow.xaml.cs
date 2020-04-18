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

            // Listview Mitarbeiter auf
            updateListview_MA();
            // Listview Bewohner auf

            updateListView_Bew();

        }

        // setzt Listmitarbeiter Listview zurück und liest neu ein

        public void updateListview_MA()
        {
            IList<Person> itemMA = Person.getPerson("Mitarbeiter");
            listMitarbeiter.ItemsSource = itemMA;
        }

        public void updateListView_Bew()

        {
            IList<Person> itemBew = Person.getPerson("Bewohner");
            listMitarbeiter.ItemsSource = itemBew;


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



        private void Eingabe_Vorname_MA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Eingabe_Vorname_MA.Text = "";
        }

        private void Eingabe_Vorname_MA_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Eingabe_Vorname_MA_GotFocus;
        }

        private void Eingabe_Nachname_MA_GotFocus(object sender, RoutedEventArgs e)
        {
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

        private void ma_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("grtgrth");
            var itm = listMitarbeiter.Items.CurrentItem;
            var selection = listMitarbeiter.SelectedItem;
            var temp_selection = (Person) listMitarbeiter.SelectedItems[0];
            
            Eingabe_Vorname_MA.Text = temp_selection.Vorname;
            Eingabe_Nachname_MA.Text = temp_selection.Nachname;

        }

        private void listMitarbeiter_Loaded(object sender, RoutedEventArgs e)
        {
            updateListview_MA();
        }

        private void listBewohner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateListView_Bew();
        }

    }

}
