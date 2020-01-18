using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Pläne1
{
    public class Event
    {
        public int EventId { get; set; }
        private string EventName { get; set; }

        private DateTime EventDatum { get; set; }
        private DateTime EventBeginn { get; set; }
        public DateTime EventEnd { get; set; }
        public int EventVorlauf { get; set; }
        public string EventOrt { get; set; }
        public string EventBeschreibung { get; set; }
        public string EventInfo { get; set; }

        // Navigation Property für Person
        //public ICollection<Person> Persons { get; set; }
        public virtual List<PersonenEvent> PersonenEvents { get; set; }




        public static void CreateEvent(string vname, string nname, string rolle)
        {
            string _rolle = rolle;

            //Implementierung ob Mitarbeiter schon existiert

            if (CheckDBforDuplicate(vname, nname, _rolle))
            {
                Event.SaveEventToDB(vname, nname, _rolle);
            }
        }

        public static bool CheckDBforDuplicate(string vname, string nnachname, string rolle)
        {
            return true;
            //using (Context db = new Context())
            //{
            //    if (db.Personen.Any(x => x.Nachname == nnachname))
            //    {
            //        if (db.Personen.Any(x => x.Vorname == vname))
            //        {
            //            if (db.Personen.Any(x => x.Rolle == rolle))
            //            {
            //                Console.WriteLine($"Person ({vname} {nnachname} mit Rolle {rolle} existiert schon in DB");
            //                return false;

            //            }
            //        }

            //    }
            //    Console.WriteLine("Person kann hinzugefügt werden");
            //    return true;
            //}
        }

        public static void SaveEventToDB(string vname, string nname, string rolle)
        {
            using (Context db = new Context())
            {
                Person pers = new Person();
                pers.Vorname = vname;
                pers.Nachname = nname;
                pers.Rolle = rolle;
                db.Personen.Add(pers);
                var result = db.SaveChanges();
                Console.WriteLine("Check:Nachname: " + result);
            }
        }





    }
    

}
