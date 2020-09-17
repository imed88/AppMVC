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

namespace WebApplication2.Controllers.TablesControllers
{
    
    public class MedecinConventionnesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedecinConventionnes
        //public ActionResult Index()
        //{
        //    var medecinConventionnes = db.MedecinConventionnes.Include(m => m.specialite);
        //    return View(medecinConventionnes.ToList());
        //}

        public ActionResult Index(string order, string currentFilter, string searching, int? page)
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


            //var specialites = from c in db.Specialites select c;
            var medconv = db.MedecinConventionnes.Include(m => m.specialite);

            if (!String.IsNullOrEmpty(searching))
            {
                medconv = medconv.Where(s => s.nameDoctors.Contains(searching));

            }


            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "nameDoctors_desc" : "";
            ViewBag.specialiteNameSortParm = String.IsNullOrEmpty(order) ? "specialiteName_desc" : "";


            switch (order)
            {
                case "nameDoctors_desc":
                    medconv = medconv.OrderByDescending(s => s.nameDoctors);
                    break;
                case "specialiteName_desc":
                    medconv = medconv.OrderByDescending(s => s.specialite.SpecialiteName);
                    break;
                default:
                    medconv = medconv.OrderBy(s => s.nameDoctors);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(medconv.ToPagedList(pageNumber, pageSize));
        }

        // GET: MedecinConventionnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinConventionne medecinConventionne = db.MedecinConventionnes.Find(id);
            if (medecinConventionne == null)
            {
                return HttpNotFound();
            }
            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Create
        public ActionResult Create()
        {
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName");
            return View();
        }

        // POST: MedecinConventionnes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedecinConventionne medecinConventionne, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //string path = Path.Combine(Server.MapPath("~/Uploads/"), upload.FileName);
                //upload.SaveAs(path);
                //medecinConventionne.picDoctor = upload.FileName;
                db.MedecinConventionnes.Add(medecinConventionne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medecinConventionne.idSpecialite,  "--Choisir un élément --");
            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinConventionne medecinConventionne = db.MedecinConventionnes.Find(id);
            if (medecinConventionne == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medecinConventionne.idSpecialite);
            return View(medecinConventionne);
        }

        // POST: MedecinConventionnes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedecinConventionne medecinConventionne, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), medecinConventionne.picDoctor);
                //if (upload != null)
                //{
                //    System.IO.File.Delete(oldPath);
                //    string path = Path.Combine(Server.MapPath("~/Uploads/"), upload.FileName);
                //    upload.SaveAs(path);
                //    medecinConventionne.picDoctor = upload.FileName;
                //}

                
                db.Entry(medecinConventionne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medecinConventionne.idSpecialite);
            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinConventionne medecinConventionne = db.MedecinConventionnes.Find(id);
            if (medecinConventionne == null)
            {
                return HttpNotFound();
            }
            return View(medecinConventionne);
        }

        // POST: MedecinConventionnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedecinConventionne medecinConventionne = db.MedecinConventionnes.Find(id);
            db.MedecinConventionnes.Remove(medecinConventionne);
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
