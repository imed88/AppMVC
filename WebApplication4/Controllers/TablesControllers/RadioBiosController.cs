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
    public class RadioBiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RadioBios
        public ActionResult Index()
        {
            var radioBios = db.RadioBios.Include(r => r.Consultation);
            return View(radioBios.ToList());
        }

        // GET: RadioBios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadioBio radioBio = db.RadioBios.Find(id);
            if (radioBio == null)
            {
                return HttpNotFound();
            }
            return View(radioBio);
        }

        // GET: RadioBios/Create
        public ActionResult Create()
        {
            ViewBag.ConsultationID = new SelectList(db.Consultations, "ConsultationID", "idPatients");
            return View();
        }

        // POST: RadioBios/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadioBioID,ConsultationID,Comment")] RadioBio radioBio)
        {
            if (ModelState.IsValid)
            {
                db.RadioBios.Add(radioBio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultationID = new SelectList(db.Consultations, "ConsultationID", "diagnostic", radioBio.ConsultationID);
            return View(radioBio);
        }

        // GET: RadioBios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadioBio radioBio = db.RadioBios.Find(id);
            if (radioBio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsultationID = new SelectList(db.Consultations, "ConsultationID", "diagnostic", radioBio.ConsultationID);
            return View(radioBio);
        }

        // POST: RadioBios/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadioBioID,ConsultationID,Comment")] RadioBio radioBio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radioBio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultationID = new SelectList(db.Consultations, "ConsultationID", "diagnostic", radioBio.ConsultationID);
            return View(radioBio);
        }

        // GET: RadioBios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadioBio radioBio = db.RadioBios.Find(id);
            if (radioBio == null)
            {
                return HttpNotFound();
            }
            return View(radioBio);
        }

        // POST: RadioBios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RadioBio radioBio = db.RadioBios.Find(id);
            db.RadioBios.Remove(radioBio);
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
