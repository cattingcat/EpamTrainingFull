using DataAccessors.Accessors;
using DataAccessors.Entity;
using Ninject;
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
        //public static IAccessor<Person> PersonAccessor;
        //public static IAccessor<Phone> PhoneAccessor;
        public static Logger GlobalLogger;
        public static IKernel NinjectKernel;

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalLogger = LogManager.GetCurrentClassLogger();
            GlobalLogger.Trace("App start!");          

            NinjectKernel = new StandardKernel(new RegisterDependencies());

            //RouteCollection
            RouteTable.Routes.MapPageRoute("1", "PersonList", "~/Persons/PersonList.aspx");
            //RouteTable.Routes.MapPageRoute("2", "Persons/{test}", "~/Persons/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("3", "", "~/Persons/PersonList.aspx");
            RouteTable.Routes.MapPageRoute("4", "PhoneList", "~/Phones/PhoneList.aspx");
            RouteTable.Routes.MapPageRoute("5", "ErrorPage/{img}", "~/ErrorPage.aspx");     
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