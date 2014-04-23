using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class PhoneController : Controller
    {        
        // GET: /Phone/
        public ActionResult Index()
        {
            IEnumerable<Phone> phones = MvcApplication.PhoneAccessor.GetAll();
            ViewResult v = View();
            v.ViewData["phones"] = phones;
            return v;
        }
        
        // GET: /Phone/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: /Phone/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: /Phone/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Phone p = new Phone
                {
                    Id = int.Parse(collection["id"]),
                    Number = collection["num"].Trim(),
                    PersonId = int.Parse(collection["owner"])
                };
                MvcApplication.PhoneAccessor.Insert(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: /Phone/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        // POST: /Phone/Edit/5
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
        
        // GET: /Phone/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        // POST: /Phone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MvcApplication.PhoneAccessor.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
