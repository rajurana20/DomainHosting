using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomainHosting.Controllers
{
    public class CustomerController : Controller
    {
        DBDHMEntitiesContext db = new DBDHMEntitiesContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id=0)
        {
            Customer eId = db.Customers.Find(id);
            if(eId==null)
            {
                return HttpNotFound();
            }
            return View(eId);
        }
        [HttpPost]

        public ActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
           
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            Customer eId = db.Customers.Find(id);
            if (eId == null)
            {
                return HttpNotFound();
            }
            return View(eId);
        }


        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id=0)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();


            return RedirectToAction("index");
        }

        public ActionResult Detail(int id=0)
        {
            Customer customer= db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }

    }
}