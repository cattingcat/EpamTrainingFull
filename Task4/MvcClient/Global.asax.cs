using DataAccessors.Accessors;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcClient
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IAccessor<Person> PersonAccessor;
        public static IAccessor<Phone> PhoneAccessor;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            string accessorType = ConfigurationManager.AppSettings.Get("AccessorType");
            string appConfigConnectionString = "ServiceDb";

            string fileDbHome = ConfigurationManager.AppSettings.Get("FileDbHome");
            string directoryDbHome = ConfigurationManager.AppSettings.Get("DirectoryDbHome");

            switch (accessorType)
            {
                case "orm":
                    PersonAccessor = new OrmPersonAccessor(appConfigConnectionString);
                    PhoneAccessor = new OrmPhoneAccessor(appConfigConnectionString);
                    break;
                case "ado":
                    PersonAccessor = new ADOPersonAccessor(appConfigConnectionString);
                    PhoneAccessor = new ADOPhoneAccessor(appConfigConnectionString);
                    break;
                case "dir":
                    PersonAccessor = new DirectoryPersonAccessor(directoryDbHome + @"\Persons");
                    PhoneAccessor = new DirectoryPhoneAccessor(directoryDbHome + @"\Phone");
                    break;
                case "file":
                    PersonAccessor = new FilePersonAccessor(fileDbHome + @"\FilePersonDb.xml");
                    PhoneAccessor = new FilePhoneAccessor(fileDbHome + @"/App_Data\FileDbs\FilePhoneDb.xml");
                    break;
                case "mem":
                    PersonAccessor = new MemoryPersonAccessor();
                    //phoneAcc = new MemoryPhoneAccessor();
                    break;
            }

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}