namespace driver
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using domain;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    internal class Program
    {
        private static void Main(string[] args)
        {
            CreateDb();

            Sleep();

            CreatePeople();

            Sleep();

            GetPeople();

            //Sleep();

            //GetOnePerson();

            //Sleep();

            //UpdateOnePerson();

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static void Sleep()
        {
            Console.WriteLine();
            Thread.Sleep(2000);
        }

        public static void CreateDb()
        {
            Console.WriteLine("--- CREATING DATABASE ---");

            Configuration config = new Configuration().Configure();
            var export = new SchemaExport(config);
            
            export.Drop(false, false);
            export.Create(true, true);
        }

        public static void CreatePeople()
        {
            Console.WriteLine("--- CREATING A LIST OF PEOPLE ---");

            var address = new Address
                              {
                                  Line1 = "123 Some St.",
                                  City = "Grimes",
                                  State = "Iowa",
                                  Zip = "50111"
                              };

            ISession session = GetSession();
            session.Save(address);

            for (int i = 0; i < 10; i++)
            {
                var person = new Person
                                 {
                                     FullName =
                                         {
                                             FirstName = "Person",
                                             MiddleName = i.ToString(),
                                             LastName = "Test" + i
                                         },
                                     Address = address
                                 };

                session.Save(person);
            }

            session.Flush();
            session.Dispose();
        }

        public static void GetPeople()
        {
            Console.WriteLine("--- GETTING A LIST OF PEOPLE ---");

            ISession session = GetSession();

            ICriteria targetObjects = session.CreateCriteria(typeof (Person));
            IList<Person> personList = targetObjects.List<Person>();

            IQuery query = session.CreateQuery("from Person");
            IList<Person> anotherPersonList = query.List<Person>();

            session.Dispose();

            PrintPeople("Using ICritiria...", personList);
            PrintPeople("Using IQuery...", anotherPersonList);
        }

        private static void GetOnePerson()
        {
            Console.WriteLine("--- GETTING ONE PERSON ---");

            using (ISession session = GetSession())
            {
                var address = new Address
                                  {
                                      Line1 = "123 Some St.",
                                      City = "Grimes",
                                      State = "Iowa",
                                      Zip = "50111"
                                  };

                session.Save(address);

                var person = new Person
                                 {
                                     FullName =
                                         {
                                             FirstName = "Javier",
                                             MiddleName = "G",
                                             LastName = "Lozano"
                                         },
                                     Address = address
                                 };

                session.Save(person);
                session.Flush();
            }

            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Person p where p.FullName.LastName = :lastName");
                query.SetString("lastName", "Lozano");

                var person = query.UniqueResult<Person>();

                Console.WriteLine("Name: {0}", person.FullName);
                Console.WriteLine("Address: {0}", person.Address);
            }
        }

        private static void UpdateOnePerson()
        {
            Console.WriteLine("--- UPDATING ONE PERSON ---");

            Person person;

            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Person p where p.FullName.LastName = :lastName");
                query.SetString("lastName", "Lozano");

                person = query.UniqueResult<Person>();

                Console.WriteLine("Name: {0}", person.FullName);
                Console.WriteLine("Address: {0}", person.Address);
            }

            using (ISession session = GetSession())
            {
                person.FullName.FirstName = "Dominic";
                session.Update(person);
                session.Flush();
            }

            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery("from Person p where p.FullName.LastName = :lastName");
                query.SetString("lastName", "Lozano");

                person = query.UniqueResult<Person>();

                Console.WriteLine("Name: {0}", person.FullName);
                Console.WriteLine("Address: {0}", person.Address);
            }
        }

        private static void PrintPeople(string method, IEnumerable<Person> personList)
        {
            Console.WriteLine(method);

            foreach (Person person in personList)
            {
                Console.WriteLine("Name: {0}", person.FullName);
                Console.WriteLine("Address: {0}", person.Address);

                Console.WriteLine("----------------");
            }

            Console.WriteLine("\n");
        }

        private static ISession GetSession()
        {
            // Initialize
            var config = new Configuration();
            config.Configure();

            // Create session factory from configuration object
            ISessionFactory factory = config.BuildSessionFactory();
            return factory.OpenSession();
        }
    }
}