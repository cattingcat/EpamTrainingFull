using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class PersonController : Controller
    {        
        // GET: /Person/
        public ActionResult Index()
        {
            ViewResult vr = View();
            vr.ViewData["persons"] = MvcApplication.PersonAccessor.GetAll();
            return vr;
        }
        
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: /Person/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Person p = new Person
                {
                    Id = int.Parse(collection["id"]),
                    Name = collection["name"].Trim(),
                    LastName = collection["lastName"].Trim(),
                    DayOfBirth = DateTime.Parse(collection["birthdate"])
                };
                MvcApplication.PersonAccessor.Insert(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: /Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        // POST: /Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        // POST: /Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MvcApplication.PersonAccessor.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
