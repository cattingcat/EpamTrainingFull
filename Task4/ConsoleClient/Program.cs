using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleClient
{
    class Program
    {
        class SimpleTimer: IDisposable
        {
            private Stopwatch sw;

            public SimpleTimer()
            {
                sw = new Stopwatch();
                sw.Start();
            }

            public void Dispose()
            {
                sw.Stop();
                Console.WriteLine("Complete! elapsed: {0}ms", sw.ElapsedMilliseconds);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(
@"Select data accessor: 
orm accessor       - 1
ADO accessor       - 2
directory accessor - 3
file accessor      - 4
memory accessor    - 5");

            IAccessor<Person> personAcc = null;
            IAccessor<Phone> phoneAcc = null;
            int resp = int.Parse(Console.ReadLine());

            string appConfigConnectionString = "ServiceDb";
            switch (resp)
            {
                case 1:
                    personAcc = new OrmPersonAccessor(appConfigConnectionString);
                    phoneAcc = new OrmPhoneAccessor(appConfigConnectionString);
                    break;
                case 2:
                    personAcc = new ADOPersonAccessor(appConfigConnectionString);
                    phoneAcc = new ADOPhoneAccessor(appConfigConnectionString);
                    break;
                case 3:
                    personAcc = new DirectoryPersonAccessor(@"App_Data\FolderDb\Persons");
                    phoneAcc = new DirectoryPhoneAccessor(@"App_Data\FolderDb\Phone");
                    break;
                case 4:
                    personAcc = new FilePersonAccessor(@"App_Data\FileDbs\FilePersonDb.xml");
                    phoneAcc = new FilePhoneAccessor(@"App_Data\FileDbs\FilePhoneDb.xml");
                    break;
                case 5:
                    personAcc = new MemoryPersonAccessor();
                    //phoneAcc = new MemoryPhoneAccessor();
                    break;
            }
            while (true)
            {
                Console.WriteLine(
@"Select entity type:
Person - 1
Phone  - 2
exit   - 0");
                int t;
                bool b = int.TryParse(Console.ReadLine(), out t);
                if (b)
                {
                    if (t == 1)
                        RunCUI<Person>(personAcc);
                    else if (t == 2)
                        RunCUI<Phone>(phoneAcc);
                    else
                        return;
                }
                else
                    return;
            }
        }

        private static ICollection<string> GetFields<T>()
        {
            if (typeof(T) == typeof(Person))
            {
                return new[] { "id", "name", "lastname" };
            }
            else
            {
                return new[] { "id", "number", "personid" };
            }
        }
        private static object FromStringArray<T>(string[] arr)
        {

            if (typeof(T) == typeof(Person))
            {
                int id = Int32.Parse(arr[1]);
                Person p = new Person() { Id = id };
                if (arr.Length >= 4)
                {
                    p.Name = arr[2];
                    p.LastName = arr[3];
                }
            }
            else
            {
                int id = Int32.Parse(arr[1]);
                Phone p = new Phone() { Id = id };
                if (arr.Length >= 4)
                {
                    p.Number = arr[2];
                    p.PersonId = int.Parse(arr[3]);
                }
                return p;
            }
            return null;            
        }
        private static void RunCUI<T>(IAccessor<T> accessor)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in GetFields<T>())
            {
                sb.AppendFormat("[{0}] ", s);
            }
            
            Console.WriteLine(
@"Commands:
p                         - print all
p [id]                    - print one
i [id]                    - insert
i " + sb.ToString() +  @" - insert
d [id]                    - delete");

            Console.WriteLine("Now using: {0} ", accessor.GetType().Name);
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', ',');
                if (command[0] == "p")
                {
                    var s = new SimpleTimer();
                    if (command.Length == 1)
                    {
                        foreach (object p in accessor.GetAll())
                        {
                            Console.WriteLine(p);
                        }
                    }
                    else if (command.Length == 2)
                    {
                        int id = Int32.Parse(command[1]);
                        object p = accessor.GetById(id);
                        Console.WriteLine(p.ToString());
                    }
                    s.Dispose();
                }
                else if (command[0] == "d")
                {
                    var s = new SimpleTimer();
                    int id = Int32.Parse(command[1]);
                    accessor.DeleteById(id);
                    s.Dispose();
                }
                else if (command[0] == "i")
                {
                    var s = new SimpleTimer();
                    object o = FromStringArray<T>(command);
                    accessor.Insert((T)o);
                    s.Dispose();
                }
                else if (String.IsNullOrEmpty(command[0]))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }  
        }
    }    
}
