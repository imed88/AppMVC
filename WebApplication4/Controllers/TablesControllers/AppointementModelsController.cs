using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    [Authorize(Roles ="Administrateur")]
    public class AppointementModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointementModels
        /*public ActionResult Index()
        {
            var appointementModels = db.AppointementModels.Include(a => a.ApplicationUser);
            var appointementModel = db.AppointementModels.Include(a => a.Doctor);
            var appoints = db.AppointementModels.Include(a => a.Patient);
            return View(appointementModels.ToList());
        }*/

      

       [Authorize(Roles ="Administrateur, Infirmier")]
        public ActionResult Index(string searching, 
                                string order, 
                                string currentFilter, 
                                int? page, DateTime? start, DateTime? end)
        {


            if (searching != null)
            {
                page = 1;
            }
            else
            {
                searching = currentFilter;
            }

            ViewBag.CurrentFilter = searching;


            var appointementModels = db.AppointementModels.Include(c => c.Patient);

            if (!String.IsNullOrEmpty(searching))
            {

                appointementModels = appointementModels.Where(s => s.Patient.MatriculePatients.ToLower().Contains(searching.ToLower())
                && s.DtEdit == start);

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "PrenomPatient_desc" : "";


            switch (order)
            {
                case "PrenomPatient_desc":
                    appointementModels = appointementModels.OrderByDescending(s => s.Patient.PrenomPatient);
                    break;
                default:
                    appointementModels = appointementModels.OrderBy(s => s.Patient.PrenomPatient);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(appointementModels.ToPagedList(pageNumber, pageSize));
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
            //ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
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
                //var UserId = User.Identity.GetUserId();
                db.AppointementModels.Add(appointementModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", appointementModel.UserID);
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

       
        public ActionResult PassRDV()
        {

            var OneBlog = (from am in db.AppointementModels
                           join mc in db.MedecinConventionnes
                           on am.idDoctors equals mc.idDoctors
                           join pat in db.Patients
                           on am.idPatients equals pat.IdPatients
                           join spec in db.Specialites
                           on mc.idSpecialite equals spec.IdSpecialite
                           select new
                           {
                               am.dateTime,
                               am.DtEdit,
                               mc.nameDoctors,
                               pat.MatriculePatients,
                               pat.NomPatient,
                               pat.PrenomPatient,
                               spec.SpecialiteName

                           }).Where(am=>am.MatriculePatients== "563698");





            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "FicheRDV.rpt"));
            rd.SetDataSource(OneBlog);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "BlogList.pdf");
        }

    }
}
