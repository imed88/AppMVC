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
    public class AppointementModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointementModels
        public ActionResult Index()
        {
            var appointementModels = db.AppointementModels.Include(a => a.ApplicationUser);
            var appointementModel = db.AppointementModels.Include(a => a.Doctor);
            var appoints = db.AppointementModels.Include(a => a.Patient);
            return View(appointementModels.ToList());
        }

        // GET: AppointementModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointementModel appointementModel = db.AppointementModels.Find(id);
            if (appointementModel == null)
            {
                return HttpNotFound();
            }
            return View(appointementModel);
        }

        // GET: AppointementModels/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors");
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient");
            return View();
        }

        // POST: AppointementModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointementModel appointementModel)
        {
            if (ModelState.IsValid)
            {
                db.AppointementModels.Add(appointementModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", appointementModel.UserID);
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors", appointementModel.idDoctors);
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient", appointementModel.idPatients);

            return View(appointementModel);
        }

        // GET: AppointementModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointementModel appointementModel = db.AppointementModels.Find(id);
            if (appointementModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", appointementModel.UserID);
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors", appointementModel.idDoctors);
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient", appointementModel.idPatients);

            return View(appointementModel);
        }

        // POST: AppointementModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointementModel appointementModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointementModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", appointementModel.UserID);
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors", appointementModel.idDoctors);
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient", appointementModel.idPatients);

            return View(appointementModel);
        }

        // GET: AppointementModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointementModel appointementModel = db.AppointementModels.Find(id);
            if (appointementModel == null)
            {
                return HttpNotFound();
            }
            return View(appointementModel);
        }

        // POST: AppointementModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointementModel appointementModel = db.AppointementModels.Find(id);
            db.AppointementModels.Remove(appointementModel);
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
