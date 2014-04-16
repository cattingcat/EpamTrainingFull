using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using DataAccessors.Entity;
using System.Configuration;
using MyOrm;

namespace DataAccessors.Accessors
{
    public class OrmPersonAccessor: IAccessor<Person>
    {
        private MyORM orm;

        public OrmPersonAccessor(string appConfigConnectionString)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            orm = new MyORM(factory, connectionString, typeof(Person), typeof(Phone));
            orm.RelationsEnabled = true;
        }

        public ICollection<Person> GetAll()
        {
            return orm.SelectAll<Person>();
        }

        public Person GetById(object id)
        {
            return orm.SelectById<Person>(id);
        }

        public void DeleteById(object id)
        {
            int res = orm.Delete<Person>(id);
        }

        public void Insert(Person p)
        {            
            int res = orm.Insert(p);
            if (res <= 0)
            {
                throw new Exception("error: " + res);
            }
        }
    }
}
