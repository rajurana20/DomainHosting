using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
            string fileName = "";
            fileName = Path.GetFileNameWithoutExtension(customer.ImageFile.FileName);
            string extension = Path.GetExtension(customer.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            customer.Photo = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            customer.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
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
            
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(customer.ImageFile1.FileName);
                string extension = Path.GetExtension(customer.ImageFile1.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                customer.Photo = "~/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                customer.ImageFile1.SaveAs(fileName);
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