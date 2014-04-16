using DataAccessors.Accessors;
using DataAccessors.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {
        public static IAccessor<Person> PersonAccessor;
        public static IAccessor<Phone> PhoneAccessor;
        public static Logger GlobalLogger;

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalLogger = LogManager.GetCurrentClassLogger();
            GlobalLogger.Trace("App start!");            

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


            //RouteCollection
            RouteTable.Routes.MapPageRoute("1", "PersonList", "~/Persons/PersonList.aspx");
            //RouteTable.Routes.MapPageRoute("2", "Persons/{test}", "~/Persons/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("3", "", "~/Persons/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("4", "PhoneList", "~/Phones/PhoneList.aspx");
            RouteTable.Routes.MapPageRoute("5", "ErrorPage", "~/ErrorPage.aspx");     
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            GlobalLogger.Trace("Session start!");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            GlobalLogger.Trace("App_begin request start!");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            GlobalLogger.Trace("App auth request!");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            GlobalLogger.Trace("App error!");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            GlobalLogger.Trace("App session end!");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            GlobalLogger.Trace("App finish!");
        }
    }
}