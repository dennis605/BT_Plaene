using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BT_Pläne1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IList<Person> itemMA = Person.getPerson("Mitarbeiter");
            IList<Person> itemBew = Person.getPerson("Bewohner");

            //ObservableCollection<Person> employees = new ObservableCollection<Person>();
            //listPerson.ItemsSource = employees;

            foreach (var per in itemMA)
            {
                listMitarbeiter.Items.Add(new
                {
                    id = per.PersonId,
                    Vorname = per.Vorname,
                    Nachname = per.Nachname,
                    Rolle = per.Rolle
                });
            }
            foreach (var bew in itemBew)
            {
                listBewohner.Items.Add(new
                {
                    id = bew.PersonId,
                    Vorname = bew.Vorname,
                    Nachname = bew.Nachname,
                    Rolle = bew.Rolle
                });
            }
        }

        private void Btn_MA_Click(object sender, RoutedEventArgs e)
        {
            Person.CreatePerson(Eingabe_Vorname_MA.Text, Eingabe_Nachname_MA.Text, "Mitarbeiter");
            //listMitarbeiter.Items.Refresh();

            // setzt Listmitarbeiter Listview zurück
            listMitarbeiter.Items.Clear();
            IList<Person> itemMA = Person.getPerson("Mitarbeiter");
            foreach (var per in itemMA)
            {
                listMitarbeiter.Items.Add(new
                {
                    id = per.PersonId,
                    Vorname = per.Vorname,
                    Nachname = per.Nachname,
                    Rolle = per.Rolle
                });
            }
            
        }
    }
}
