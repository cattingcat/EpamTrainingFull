using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;

using DataAccessors.Entity;

using MyOrm;

namespace DataAccessors.Accessors
{
    public class OrmPhoneAccessor: IAccessor<Phone>
    {
        private MyORM _orm;

        public OrmPhoneAccessor(string appConfigConnectionString)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings[appConfigConnectionString].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            _orm = new MyORM(factory, connectionString, typeof(Phone), typeof(Person));
            _orm.RelationsEnabled = true;
        }


        public ICollection<Phone> GetAll()
        {
            return _orm.SelectAll<Phone>();
        }

        public Phone GetById(object id)
        {
            return _orm.SelectById<Phone>(id);
        }

        public void DeleteById(object id)
        {
            _orm.Delete<Phone>(id);
        }

        public void Insert(Phone p)
        {
            _orm.Insert(p);
        }
    }
}
