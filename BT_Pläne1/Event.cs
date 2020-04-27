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
        public List<Person> Personen { get; set; }




        public static void CreateEvent(string EventName, DateTime EventDatum, DateTime EventBeginn, DateTime EventEnd, string EventOrt, string EventBeschreibung, string EventInfo = "", int EventVorlauf = 0)
        {
            

            //Implementierung ob Mitarbeiter schon existiert

            if (true)
            {
                //Event.SaveEventToDB(vname, nname, _rolle) ;
            }
        }

        public static bool CheckDBforDuplicate(string EventName, DateTime EventDatum, DateTime EventBeginn, DateTime EventEnd, string EventOrt, string EventBeschreibung, string EventInfo = "", int EventVorlauf = 0)
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

        public static void SaveEventToDB(string EventName, DateTime EventDatum, DateTime EventBeginn, DateTime EventEnd, string EventOrt, string EventBeschreibung, string EventInfo = "", int EventVorlauf=0)
        {
            using (Context db = new Context())
            {
                Event ev = new Event();

                ev.EventName= EventName;
                ev.EventDatum = EventDatum;
                ev.EventBeginn = EventBeginn;
                ev.EventEnd = EventEnd;
                ev.EventVorlauf = EventVorlauf;
                ev.EventOrt = EventOrt;
                ev.EventBeschreibung = EventBeschreibung;
                ev.EventInfo = EventInfo;
                db.Events.Add(ev);
                var result = db.SaveChanges();
                //Console.WriteLine("Check:Nachname: " + result);
            }
        }





    }
    

}
