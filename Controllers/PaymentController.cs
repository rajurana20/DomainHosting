using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomainHosting.Controllers
{
    public class PaymentController : Controller
    {
        DBDHMEntitiesContext db = new DBDHMEntitiesContext();
        // GET: Payment
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            Payment payment = db.Payments.Find(id);
            if(payment==null)
            {
                return HttpNotFound(); 
            }
            return View(payment);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            try
            {
                // TODO: Add insert logic here

                if(ModelState.IsValid)
                {
                    db.Payments.Add(payment);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                return View(payment);
             
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            Payment payment = db.Payments.Find(id);
            if(payment==null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payment/Edit/5
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

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            Payment payment = db.Payments.Find(id);
            if(payment==null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
