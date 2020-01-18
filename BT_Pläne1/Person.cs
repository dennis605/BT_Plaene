namespace BT_Pläne1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Person" />
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Gets or sets the PersonId
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the Vorname
        /// </summary>
        public string Vorname { get; set; }

        /// <summary>
        /// Gets or sets the Nachname
        /// </summary>
        public string Nachname { get; set; }

        /// <summary>
        /// Gets or sets the Rolle
        /// </summary>
        public string Rolle { get; set; }

        // Navigation Property für Event 

        //public ICollection<Event> Events { get; set; }
        /// <summary>
        /// Gets or sets the PersonenEvents
        /// </summary>
        public virtual List<PersonenEvent> PersonenEvents { get; set; }

        // Speichere Mitarbeiter oder Bewohner in Datenbank
        /// <summary>
        /// The SavePersontoDBB
        /// </summary>
        /// <param name="vname">The vname<see cref="string"/></param>
        /// <param name="nname">The nname<see cref="string"/></param>
        /// <param name="rolle">The rolle<see cref="string"/></param>
        public static void SavePersontoDBB(string vname, string nname, string rolle)
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

        /// <summary>
        /// Erfragt Daten für einen neue Person und gibt Parameter an SavePersontoDB weiter
        /// </summary>
        /// <param name="vname">Vorname<see cref="string"/></param>
        /// <param name="nname">Nachname<see cref="string"/></param>
        /// <param name="rolle">Rolle (Mitarbeiter/Bewohner)<see cref="string"/></param>
        public static void CreatePerson(string vname, string nname, string rolle)
        {
            string _rolle = rolle;

            //Implementierung ob Mitarbeiter schon existiert

            if (CheckDBforDuplicate(vname, nname, _rolle))
            {
                Person.SavePersontoDBB(vname, nname, _rolle);
            }
        }

        // hier wird zu speichernde Person geprüft, ob schon in DB existiert -> gibt true zurück, wenn speichern möglich ist
        /// <summary>
        /// The CheckDBforDuplicate
        /// </summary>
        /// <param name="vname">Vorname<see cref="string"/></param>
        /// <param name="nnachname">Nachname<see cref="string"/></param>
        /// <param name="rolle">Rolle (Mitarbeiter/Bewohner)<see cref="string"/></param>
        /// <returns>True, wenn Datensatz unique ist <see cref="bool"/></returns>
        public static bool CheckDBforDuplicate(string vname, string nnachname, string rolle)
        {
            using (Context db = new Context())
            {
                if (db.Personen.Any(x => x.Nachname == nnachname))
                {
                    if (db.Personen.Any(x => x.Vorname == vname))
                    {
                        if (db.Personen.Any(x => x.Rolle == rolle))
                        {
                            Console.WriteLine($"Person ({vname} {nnachname} mit Rolle {rolle} existiert schon in DB");
                            return false;

                        }
                    }

                }
                Console.WriteLine("Person kann hinzugefügt werden");
                return true;
            }
        }

        /// <summary>
        /// The getPerson
        /// </summary>
        public static IList<Person> getPerson(string rolle) // Mitarbeiter oder Bewohner
        {
            //TODO:public void getPerson() // Mitarbeiter oder Bewohner -> getPerson(string rolle)
            string _rolle = rolle;

            using (Context db = new Context())
            {
                //var req = from pers in db.Personen where rolle == _rolle select pers;
                var req = db.Personen.Where(r => r.Rolle == _rolle).ToList();
                // return req as ICollection<Person>;


                // foreach (var pers in req)
                // {
                //    Console.WriteLine($"Vorname:{ pers.Vorname } Nachname:{ pers.Nachname} Rolle:{pers.Rolle}");
                // }
                return req;
            }


        }

        public static string getPersontoString(string rolle) // Mitarbeiter oder Bewohner
        {
            //TODO:public void getPerson() // Mitarbeiter oder Bewohner -> getPerson(string rolle)
            string _rolle = rolle;

            using (Context db = new Context())
            {
                //var req = from pers in db.Personen where rolle == _rolle select pers;
                var req = db.Personen.Where(r => r.Rolle == _rolle).ToString();
                // return req as ICollection<Person>;


                // foreach (var pers in req)
                // {
                //    Console.WriteLine($"Vorname:{ pers.Vorname } Nachname:{ pers.Nachname} Rolle:{pers.Rolle}");
                // }
                return req;
            }


        }

        public static IList<Person> getPersonsAsDictionary(string rolle) // Mitarbeiter oder Bewohner
        {
            //TODO:public void getPerson() // Mitarbeiter oder Bewohner -> getPersonsAsDictionary
            string _rolle = rolle;

            using (Context db = new Context())
            {
                var req = db.Personen.Where(r => r.Rolle == _rolle).ToList();
                return req as IList<Person>;               
            }


        }

        /// <summary>
        /// The getPersonsZuEvent
        /// </summary>
        public void getPersonsZuEvent() // alle Mitarbeiter und/ oder Bewohner zu Event
        {
            //TODO: public void getPersonsZuEvent() // alle Mitarbeiter und/ oder Bewohner zu Event

        }

        /// <summary>
        /// The getEventsForPerson
        /// </summary>
        public void getEventsForPerson() // alle Events zu Mitarbeiter oder Bewohner
        {
            //TODO:public void getEventsForPerson() // alle Events zu Mitarbeiter oder Bewohner

        }
        // TODO: Datenbank muss bereinigt werden nach loeschePerson()
        public static int loeschePerson(string vname, string nname, string rolle)
        {
            using (Context db = new Context())
            {
             
                var req = db.Personen.Where(r => r.Vorname == vname && r.Nachname == nname && r.Rolle == rolle).ToList();
                Console.WriteLine($"Es werden {req.Count} Einträge gelöscht. Zum Forfahren Eingabetaste verwenden. Zum Abbruch STRG+C");
                Console.ReadLine();
                db.Personen.RemoveRange(req);
                int result = db.SaveChanges();
                Console.WriteLine($"Es wurden {result} Einträge aus der Datenbank gelöscht");
                return result;
            }
        }
    }
}
