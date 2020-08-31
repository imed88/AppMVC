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
            //List<ConsultationOrdonnance> OneBlog = new List<ConsultationOrdonnance>();
            // OneBlog = db.ConsultationOrdonnances.Where(a => a.IDConsultOrd == 1).ToList();
            //            SELECT Ordonnances.Message, Ordonnances.ApplyDate, Patients.MatriculePatients, Patients.NomPatient, Patients.PrenomPatient, AspNetUsers.UserName
            //FROM            Consultations INNER JOIN
            //                  Ordonnances ON Consultations.ConsultationID = Ordonnances.ConsultationID INNER JOIN
            //                         Patients ON Consultations.idPatients = Patients.IdPatients INNER JOIN
            //                         AspNetUsers ON Consultations.UserID = AspNetUsers.Id


            var OneBlog = (from e in db.ConsultationOrdonnances
                          join p in db.Consultations
                          on e.ConsultationID equals p.ConsultationID
                          join s in db.Patients
                          on p.idPatients equals s.IdPatients
                          join t in db.Users
                          on p.UserID equals t.Id
                          where e.ConsultationID ==p.ConsultationID 
                          select new
                          {
                              Message = e.Message,
                              ApplyDate=e.ApplyDate,
                              MatriculePatients = s.MatriculePatients,
                              NomPatient = s.NomPatient,
                              PrenomPatient = s.PrenomPatient,
                              UserName = t.UserName
                             
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


        }
    }
}