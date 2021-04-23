using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;
using System.Data.Entity;
using System.Net;

namespace WebApplication4.Controllers.TablesControllers
{
    public class FilesDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: FilesDetails

        public ActionResult Index()
        {
            var fileDetails = db.FileDetails.Include(f => f.Patients);
            return View(fileDetails.ToList());
        }

        [HttpGet]
        public ActionResult CreateFile()
        {
            ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "IdPatients");
            return View();
        }

        [HttpPost]
        public ActionResult CreateFile(Patients patients, List<HttpPostedFileBase> postedFiles)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (HttpPostedFileBase postedFile in postedFiles)
            {
                if (postedFile != null)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(path + fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    FileDetail fileDetail = new FileDetail()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        Id = Guid.NewGuid(),
                        IdPatients=patients.IdPatients
                    };
                    db.FileDetails.Add(fileDetail);
                    db.SaveChanges();
                    ViewBag.IdPatients = new SelectList(db.Patients, "IdPatients", "IdPatients", fileDetail.IdPatients);

                }
            }

            return View();
        }

        public FileResult DownloadFile(string Name)

        {

            string path = Server.MapPath("~/Uploads/") + Name;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", Name);

        }



    }
}