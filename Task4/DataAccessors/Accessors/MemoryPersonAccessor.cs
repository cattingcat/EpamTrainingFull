using System.Collections.Generic;
using System.Linq;
using DataAccessors.Entity;
using System;

namespace DataAccessors.Accessors
{
    public class MemoryPersonAccessor: IAccessor<Person>
    {
        private ICollection<Person> data;
       
        public MemoryPersonAccessor(ICollection<Person> data)
        {
            this.data = data;
        }

        public MemoryPersonAccessor()
        {
            LinkedList<Person> tmp = new LinkedList<Person>();
            Random rand = new Random();
            for (int i = 0; i < 10; ++i)
            {
                tmp.AddFirst(new Person
                {
                    Id = i,
                    LastName = String.Format("{0} lastname", i.ToString()),
                    Name = String.Format("{0} name", i.ToString()),
                    DayOfBirth = DateTime.Today
                });
            }
            this.data = tmp;
        }

        public ICollection<Person> GetAll()
        {
            return data;
        }
        public Person GetById(object id)
        {
            var res = from p in data where p.Id == (int)id select p;
            return res.FirstOrDefault<Person>();
        }
        public void DeleteById(object id)
        {
            var res = from p in data where p.Id == (int)id select p;
            Person exPerson = res.FirstOrDefault<Person>();
            if (exPerson != null)
            {
                data.Remove(exPerson);
            }
        }
        public void Insert(Person p)
        {
            var tmp = from ep in data where ep.Id == p.Id select ep;
            Person existPerson = tmp.FirstOrDefault<Person>();
            if (existPerson != null)
            {
                data.Remove(existPerson);
            }
            data.Add(p);            
        }
    }
}
