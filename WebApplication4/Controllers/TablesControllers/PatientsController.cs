using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = "Administrateur")]
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        //public ActionResult Index()
        //{
        //    var patients = db.Patients.Include(p => p.Usines);
        //    return View(patients.ToList());
        //}

        // GET: Patients/Details/5
        public System.Web.Mvc.ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // GET: Patients/Create
        public System.Web.Mvc.ActionResult Create()
        {
            ViewBag.IdUsine = new SelectList(db.Usines, "IdUsine", "UsineName");
            return View();
        }

        // POST: Patients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult Create([System.Web.Mvc.Bind(Include = "IdPatients,MatriculePatients,NomPatient,PrenomPatient,Gender,PhonePatients,DOB,Parente,MaladieChronique,APCI,IdUsine")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);
                        string foldername = "Uploads";
                        string createfolder = Server.MapPath(string.Format("~/{0}/" , foldername));
                        if (!Directory.Exists(createfolder))
                        {
                            Directory.CreateDirectory(createfolder);
                            
                        }

                        string subfoldername = foldername+"/"+ patients.NomPatient + patients.PrenomPatient;
                        string subcreatefolder = Server.MapPath(string.Format("~/{0}/", subfoldername));
                        if (!Directory.Exists(subcreatefolder))
                        {
                            Directory.CreateDirectory(subcreatefolder);
                        }

                        var path = Path.Combine(subcreatefolder, fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                patients.FileDetails = fileDetails;
                db.Patients.Add(patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsine = new SelectList(db.Usines, "IdUsine", "UsineName", patients.IdUsine);
            return View(patients);
        }

        // GET: Patients/Edit/5
        public System.Web.Mvc.ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsine = new SelectList(db.Usines, "IdUsine", "UsineName", patients.IdUsine);
            return View(patients);
        }

        // POST: Patients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult Edit([System.Web.Mvc.Bind(Include = "IdPatients,MatriculePatients,NomPatient,PrenomPatient,Gender,PhonePatients,DOB,Parente,MaladieChronique,APCI,IdUsine")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsine = new SelectList(db.Usines, "IdUsine", "UsineName", patients.IdUsine);
            return View(patients);
        }

        // GET: Patients/Delete/5
        public System.Web.Mvc.ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult DeleteConfirmed(int id)
        {
            Patients patients = db.Patients.Find(id);
            db.Patients.Remove(patients);
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

        //public ActionResult Appointements(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Patients patients = db.Patients.Find(id);

        //    if (patients == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return RedirectToAction("Index/"+id, "AppointementModels");
        //}

        public System.Web.Mvc.ActionResult Index(string order, string currentFilter, string searching, int? page)
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


            //var Patient = from c in db.Patients select c;
            var patients = db.Patients.Include(p => p.Usines);

            if (!String.IsNullOrEmpty(searching))
            {
                patients = patients.Where(s => s.NomPatient.Contains(searching));

            }

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(order) ? "NomPatient_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(order) ? "PrenomPatient_desc" : "";
            ViewBag.UsineNameSortParm = String.IsNullOrEmpty(order) ? "UsinePatient_desc" : "";


            switch (order)
            {
                case "NomPatient_desc":
                    patients = patients.OrderByDescending(s => s.NomPatient);
                    break;
                case "PrenomPatient_desc":
                    patients = patients.OrderByDescending(s => s.PrenomPatient);
                    break;
                case "UsinePatient_desc":
                    patients = patients.OrderByDescending(s => s.Usines.UsineName);
                    break;
                default:
                    patients = patients.OrderBy(s => s.NomPatient);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(patients.ToPagedList(pageNumber, pageSize));
        }

    }
}
