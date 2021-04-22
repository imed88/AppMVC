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
    public class TestFileDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestFileDetails
        public ActionResult Index()
        {
            var fileDetails = db.FileDetails.Include(f => f.Patients);
            return View(fileDetails.ToList());
        }

        // GET: TestFileDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDetail fileDetail = db.FileDetails.Find(id);
            if (fileDetail == null)
            {
                return HttpNotFound();
            }
            return View(fileDetail);
        }

        // GET: TestFileDetails/Create
        public ActionResult Create()
        {
            ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients");
            return View();
        }

        // POST: TestFileDetails/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,Extension,IdPatients")] FileDetail fileDetail)
        {
            if (ModelState.IsValid)
            {
                fileDetail.Id = Guid.NewGuid();
                db.FileDetails.Add(fileDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", fileDetail.IdPatients);
            return View(fileDetail);
        }

        // GET: TestFileDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDetail fileDetail = db.FileDetails.Find(id);
            if (fileDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", fileDetail.IdPatients);
            return View(fileDetail);
        }

        // POST: TestFileDetails/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,Extension,IdPatients")] FileDetail fileDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", fileDetail.IdPatients);
            return View(fileDetail);
        }

        // GET: TestFileDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDetail fileDetail = db.FileDetails.Find(id);
            if (fileDetail == null)
            {
                return HttpNotFound();
            }
            return View(fileDetail);
        }

        // POST: TestFileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FileDetail fileDetail = db.FileDetails.Find(id);
            db.FileDetails.Remove(fileDetail);
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
