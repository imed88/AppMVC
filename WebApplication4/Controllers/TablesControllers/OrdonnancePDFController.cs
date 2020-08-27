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
        //public ActionResult Index()
        //{
        //    List<ConsultationOrdonnance> OneBlog = new List<ConsultationOrdonnance>();
        //    OneBlog = db.ConsultationOrdonnances.Where(a => a.IDConsultOrd == 1).ToList();

        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));
        //    rd.SetDataSource(OneBlog);

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();

        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    return File(stream, "application/pdf", "BlogList.pdf");

          
        //}
    }
}