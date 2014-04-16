using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MyOrm;

namespace DataAccessors.Accessors
{
    public class OrmPhoneAccessor: IAccessor<Phone>
    {
        private MyORM orm;

        public OrmPhoneAccessor(string appConfigConnectionString)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            orm = new MyORM(factory, connectionString, typeof(Phone), typeof(Person));
            orm.RelationsEnabled = true;
        }

        public ICollection<Phone> GetAll()
        {
            return orm.SelectAll<Phone>();
        }

        public Phone GetById(object id)
        {
            return orm.SelectById<Phone>(id);
        }

        public void DeleteById(object id)
        {
            orm.Delete<Phone>(id);
        }

        public void Insert(Phone p)
        {
            orm.Insert(p);
        }
    }
}
