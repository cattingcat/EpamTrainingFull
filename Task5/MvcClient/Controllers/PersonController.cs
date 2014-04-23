using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

using NLog;

using DataAccessors.Accessors;
using DataAccessors.Entity;

using MvcClient.Models;


namespace MvcClient.Controllers
{
    public class PersonController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IAccessor<Person> _personAccessor;
        private IAccessor<Phone> _phoneAccessor;

        public PersonController(IAccessor<Person> personAccessor, IAccessor<Phone> phoneAccessor)
        {
            logger.Trace("Person controller created");

            _personAccessor = personAccessor;
            _phoneAccessor = phoneAccessor;
        }

        // GET: /Person/
        public ActionResult Index()
        {
            logger.Trace("Person controller /Index");

            return View(_personAccessor.GetAll());
        }
        
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            logger.Trace("Person controller /Details/{0}", id);

            Person person = _personAccessor.GetAll().SingleOrDefault(p => p.Id == id);
            var phones = from p in _phoneAccessor.GetAll() where p.PersonId == id select p;           
            return View(new PersonWithPhonesViewModel {Owner = person, Phones = phones });
        }
        
        // GET: /Person/Create
        public ActionResult Create()
        {
            logger.Trace("Person controller /Create");

            return View();
        }
        
        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            logger.Trace("Person controller /Create/{0} POST", person.Id);

            _personAccessor.Insert(person);
            return RedirectToAction("Index");
        }
        
        // POST: /Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            logger.Trace("Person controller /Delete/{0}", id);

            try
            {
                _personAccessor.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch (SqlException e)
            {
                Session.Add("Exception", e);
                return RedirectToAction("Index", "Exception");                
            }            
        }     
    }
}
