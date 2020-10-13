using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class MedicamentOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicamentOrders
        public ActionResult Index()
        {
            var medicamentOrders = db.MedicamentOrders.Include(m => m.Patients);
            return View(medicamentOrders.ToList());
        }

        // GET: MedicamentOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentOrder medicamentOrder = db.MedicamentOrders.Find(id);
            if (medicamentOrder == null)
            {
                return HttpNotFound();
            }
            return View(medicamentOrder);
        }

        // GET: MedicamentOrders/Create
        public ActionResult Create()
        {
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients");
            return View();
        }

        // POST: MedicamentOrders/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDate,DeliveryDate,idPatients")] MedicamentOrder medicamentOrder)
        {
            if (ModelState.IsValid)
            {
                db.MedicamentOrders.Add(medicamentOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", medicamentOrder.idPatients);
            return View(medicamentOrder);
        }

        // GET: MedicamentOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentOrder medicamentOrder = db.MedicamentOrders.Find(id);
            if (medicamentOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", medicamentOrder.idPatients);
            return View(medicamentOrder);
        }

        // POST: MedicamentOrders/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,DeliveryDate,idPatients")] MedicamentOrder medicamentOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", medicamentOrder.idPatients);
            return View(medicamentOrder);
        }

        // GET: MedicamentOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentOrder medicamentOrder = db.MedicamentOrders.Find(id);
            if (medicamentOrder == null)
            {
                return HttpNotFound();
            }
            return View(medicamentOrder);
        }

        // POST: MedicamentOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicamentOrder medicamentOrder = db.MedicamentOrders.Find(id);
            db.MedicamentOrders.Remove(medicamentOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
