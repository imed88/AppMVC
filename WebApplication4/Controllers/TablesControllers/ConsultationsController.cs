using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
          
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrdonnance(string Message, Ordonnance consultOrd)
        {
            //var UserId = User.Identity.GetUserId();
            var ConsultationID = (int)Session["ConsultationID"];
           
            //Patients patients = new Patients();

        

          

            var job = new Ordonnance();
            job.ConsultationID = ConsultationID;
            job.Message = Message;
            job.ApplyDate = DateTime.Now;

            db.ConsultationOrdonnances.Add(job);
            db.SaveChanges();
        
            var OneBlog = (from e in db.ConsultationOrdonnances
                           join p in db.Consultations
                           on e.ConsultationID equals p.ConsultationID
                           join s in db.Patients
                           on p.idPatients equals s.IdPatients
                           join t in db.Users
                           on p.UserID equals t.Id
                           where/* e.ConsultationID == p.ConsultationID */
                           e.ConsultationID == ConsultationID

                           select new
                           {
                               Message = e.Message,
                               ApplyDate = e.ApplyDate,
                               MatriculePatients = s.MatriculePatients,
                               NomPatient = s.NomPatient,
                               PrenomPatient = s.PrenomPatient,
                               UserName = t.UserName,
                               ConsultationID=p.ConsultationID

                           }).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport2.rpt"));
            rd.SetDataSource(OneBlog);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "BlogList.pdf");

            //return View();
           
        }

      

       
    }
}
