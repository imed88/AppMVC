using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers.TablesControllers
{
    public class ConsultationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       

        // GET: Consultations
        public ActionResult Index()
        {
            var consultations = db.Consultations.Include(c => c.ApplicationUser).Include(c=>c.Patient);
            return View(consultations.ToList());
        }

        // GET: Consultations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            Session["ConsultationID"] = id; 
            return View(consultation);
        }

      

     

        // GET: Consultations/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient");
            return View();
        }

        // POST: Consultations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Consultations.Add(consultation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultation.UserID);
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "PrenomPatient");
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultation.UserID);
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultation.UserID);
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            db.Consultations.Remove(consultation);
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

        public ActionResult CreateOrdonnance(ConsultationOrdonnance consultOrd)
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultOrd.UserID);
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrdonnance(string Message, ConsultationOrdonnance consultOrd)
        {
            var UserId = User.Identity.GetUserId();
            var ConsultationID = (int)Session["ConsultationID"];
            var job = new ConsultationOrdonnance();
            job.UserID = UserId;
            job.ConsultationID = ConsultationID;
            job.Message = Message;
            job.ApplyDate = DateTime.Now;

            db.ConsultationOrdonnances.Add(job);
            db.SaveChanges();
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultOrd.UserID);
            return View();
        }

        //public ActionResult ShowCustomerList()
        //{
        //    //CrMVCApp.Models.Customer c;
        //    var c = (from b in db.Customers select b).ToList();

        //    CustomerList rpt = new CustomerList();
        //    rpt.Load();
        //    rpt.SetDataSource(c);
        //    Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    return File(s, "application/pdf");
        //}
    }
}
