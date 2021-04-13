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
using FileResult = System.Web.Mvc.FileResult;

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
        public System.Web.Mvc.ActionResult Create( Patients patients)
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

                        var path = Path.Combine(createfolder, fileDetail.FileName);
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

        public FileResult DownloadFile(string Name)

        {

            string path = Server.MapPath("~/Uploads/") + Name;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", Name);

        }

       


        // GET: Patients/Edit/5
        public System.Web.Mvc.ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Include(s => s.FileDetails).SingleOrDefault(x => x.IdPatients == id);

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
        public System.Web.Mvc.ActionResult Edit(Patients patients)
        {

            if (ModelState.IsValid)
            {
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
                            Id = Guid.NewGuid(),
                            IdPatients = patients.IdPatients
                        };
                        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }

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
