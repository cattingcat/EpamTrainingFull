using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

using Ninject;
using Ninject.Modules;
using NLog;

using DataAccessors.Accessors;
using DataAccessors.Entity;


namespace MvcClient
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        IKernel _ninjectKernel;
        

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel(new[]{new RegisterDependencies()});
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _ninjectKernel.Get(controllerType) as IController;
        }

        private class RegisterDependencies : NinjectModule
        {
            public override void Load()
            {
                string accessorType = ConfigurationManager.AppSettings.Get("AccessorType");
                string appConfigConnectionString = "ServiceDb";

                string fileDbHome = ConfigurationManager.AppSettings.Get("FileDbHome");
                string directoryDbHome = ConfigurationManager.AppSettings.Get("DirectoryDbHome");

                string appDataFolder = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
                fileDbHome = fileDbHome.Replace("|DataDirectory|", appDataFolder);
                directoryDbHome = directoryDbHome.Replace("|DataDirectory|", appDataFolder);

                switch (accessorType)
                {
                    case "orm":
                        Kernel.Bind<IAccessor<Person>>().To<OrmPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                        Kernel.Bind<IAccessor<Phone>>().To<OrmPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                        break;
                    case "ado":
                        Kernel.Bind<IAccessor<Person>>().To<ADOPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                        Kernel.Bind<IAccessor<Phone>>().To<ADOPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(appConfigConnectionString);
                        break;
                    case "dir":
                        Kernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(directoryDbHome + @"\Persons");
                        Kernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(directoryDbHome + @"\Phone");
                        break;
                    case "file":
                        Kernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(fileDbHome + @"\FilePersonDb.xml");
                        Kernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(fileDbHome + @"\FilePhoneDb.xml");
                        break;
                    case "mem":
                        break;
                }

                logger.Trace("Ninject module load, current accessor: {0}", accessorType);
            }
        }
    }
}