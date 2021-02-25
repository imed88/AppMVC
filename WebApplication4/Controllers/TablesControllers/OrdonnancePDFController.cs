using CrystalDecisions.CrystalReports.Engine;
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
    public class OrdonnancePDFController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OrdonnancePDF
        public ActionResult Index()
        {
            //List<AppointementModel> OneBlog = new List<AppointementModel>();
            //OneBlog = db.AppointementModels.Where(a => a.AppointmentID == 5).ToList();


            var OneBlog=(from am in db.AppointementModels
             join mc in db.MedecinConventionnes
             on am.idDoctors equals mc.idDoctors
             join pat in db.Patients
             on am.idPatients equals pat.IdPatients
             join spec in db.Specialites
             on mc.idSpecialite equals spec.IdSpecialite
             where am.AppointmentID == 5
             select new
             {
                 am.dateTime,
                 mc.nameDoctors,
                 pat.MatriculePatients,
                 pat.NomPatient,
                 pat.PrenomPatient,
                 spec.SpecialiteName

             });





            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "FicheRDV.rpt"));
            rd.SetDataSource(OneBlog);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "BlogList.pdf");
            

           // return View();

        }
    }
}