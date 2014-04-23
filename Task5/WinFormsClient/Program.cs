using DataAccessors.Accessors;
using DataAccessors.Entity;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    static class Program
    {
        private static IKernel _ninjectKernel;

        public static T ResolveForm<T>() where T: Form
        {
            return _ninjectKernel.Get<T>();
        }              

        [STAThread]
        static void Main()
        {      
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _ninjectKernel = new StandardKernel(new[]{new RegisterDependencies()});      
            Form form = _ninjectKernel.Get<PersonListForm>();
            Application.Run(form);
        }
    }

    class RegisterDependencies : NinjectModule
    {
        public override void Load()
        {
            string appConfigConnectionString = "ServiceDb";
            string accessorType = ConfigurationManager.AppSettings.Get("AccessorType");
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
                    Kernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(@"App_Data\FolderDb\Persons");
                    Kernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(@"App_Data\FolderDb\Phones");
                    break;
                case "file":
                    Kernel.Bind<IAccessor<Person>>().To<DirectoryPersonAccessor>().InSingletonScope().WithConstructorArgument<string>(@"App_Data\FileDbs\FilePersonDb.xml");
                    Kernel.Bind<IAccessor<Phone>>().To<DirectoryPhoneAccessor>().InSingletonScope().WithConstructorArgument<string>(@"App_Data\FileDbs\FilePhoneDb.xml");
                    break;
                case "mem":
                    break;
            }
        }
    }
}
