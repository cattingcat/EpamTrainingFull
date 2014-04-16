using DataAccessors.Accessors;
using DataAccessors.Entity;
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
        public static IAccessor<Person> PersonAccessor;
        public static IAccessor<Phone> PhoneAccessor;

        [STAThread]
        static void Main()
        {
            string accessorType = ConfigurationManager.AppSettings.Get("AccessorType");
            string appConfigConnectionString = "ServiceDb";
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
                    PersonAccessor = new DirectoryPersonAccessor(@"App_Data\FolderDb\Persons");
                    PhoneAccessor = new DirectoryPhoneAccessor(@"App_Data\FolderDb\Phone");
                    break;
                case "file":
                    PersonAccessor = new FilePersonAccessor(@"App_Data\FileDbs\FilePersonDb.xml");
                    PhoneAccessor = new FilePhoneAccessor(@"App_Data\FileDbs\FilePhoneDb.xml");
                    break;
                case "mem":
                    PersonAccessor = new MemoryPersonAccessor();
                    //phoneAcc = new MemoryPhoneAccessor();
                    break;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PersonListForm());
        }
    }
}
