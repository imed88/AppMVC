using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class FilesDetailsController : Controller
    {
        // GET: FilesDetails
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> postedFiles)
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
                    //string fileName = Path.GetFileName(postedFile.FileName);
                    //postedFile.SaveAs(path + fileName);
                    //ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    var fileName = Path.GetFileName(postedFile.FileName);
                    db.FileDetails.Add(new FileDetail {
                        FileName = Path.GetFileName(postedFile.FileName),
                        Extension = Path.GetExtension(fileName),
                        Id = Guid.NewGuid(),
                        IdPatients=1
                    });

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}