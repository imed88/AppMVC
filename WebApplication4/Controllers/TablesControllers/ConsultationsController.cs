using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using Microsoft.Reporting.WebForms;
using PagedList;
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
    [Authorize(Roles = "Administrateur")]
    public class ConsultationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Consultations
        //public ActionResult Index()
        //{
        //    var consultations = db.Consultations.Include(c => c.ApplicationUser).Include(c=>c.Patient);
        //    return View(consultations.ToList());
        //}
        [AllowAnonymous]
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


            var consultations = db.Consultations.Include(c => c.ApplicationUser).Include(c => c.Patient);

            if (!String.IsNullOrEmpty(searching))
            {

                consultations = consultations.Where(s => s.Patient.PrenomPatient.ToLower().Contains(searching.ToLower()));

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "PrenomPatient_desc" : "";


            switch (order)
            {
                case "PrenomPatient_desc":
                    consultations = consultations.OrderByDescending(s => s.Patient.PrenomPatient);
                    break;
                default:
                    consultations = consultations.OrderBy(s => s.Patient.PrenomPatient);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(consultations.ToPagedList(pageNumber, pageSize));
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
            //ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            ViewBag.idPatients = new SelectList(db.Patients, "idPatients", "PrenomPatient");
            ViewBag.natureVisite = new SelectList(db.Consultations, "ConsultationID", "natureVisite");
            return View();
        }

        // POST: Consultations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultation consultation, string PrescMed, string ExplorRadio, string ExplorBio, string Transfert, string Hospitalisation, int? id)
        {
            if (ModelState.IsValid)
            {
              
                if (PrescMed == "true")
                {
                    consultation.PrescMed = true;
                    
                    consultation.ConduiteTenir = "Préscription Médicale";
                   
                }
                else if (ExplorRadio == "true")
                {
                    consultation.ExplorRadio = true;
                    
                    consultation.ConduiteTenir = "Exploration Radiologique";
                }
                else if (ExplorBio == "true")
                {
                    consultation.ExplorBio = true;
                    consultation.ConduiteTenir = "Exploration Biologique";

                }
                else if (Transfert == "true")
                {
                    consultation.Transfert = true;
                    consultation.ConduiteTenir = "Transfert";
                }
                else if (Hospitalisation == "true")
                {
                    consultation.Hospitalisation = true;
                    consultation.ConduiteTenir = "Hospitalisation"; 
                }
                else
                {
                    consultation.PrescMed = false;
                    consultation.ExplorRadio = false;
                    consultation.ExplorBio = false;
                    consultation.Transfert = false;
                    consultation.Hospitalisation = false;
                }



                string userid = HttpContext.User.Identity.Name;
                consultation.Username = userid;


                db.Consultations.Add(consultation);
                //db.SaveChanges();
             
                //db.ConsultationDetail.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", consultation.UserID);
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "PrenomPatient");
            return View(consultation);
        }


        public ActionResult PassFicheConsultaion(int? id)
        {
          
                var OneBlog = (from c in db.Consultations
                               join p in db.Patients
                               on c.idPatients equals p.IdPatients

                               select new
                               {
                                   c.diagnostic,
                                   p.NomPatient,
                                   p.PrenomPatient,
                                   p.MaladieChronique,
                                   c.ConduiteTenir,
                                   c.HospitalComment,
                                   c.ExplorRadioComment,
                                   c.ExplorBioComment,
                                   c.TransfertComment,
                                   p.Parente,
                                   c.ConsultationID

                               }).OrderBy(c => c.ConsultationID)
                            .Where(c => c.ConsultationID == id);

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Report"), "FicheExplorBio.rpt"));
                rd.SetDataSource(OneBlog);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "BlogList.pdf");
           
          
           
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
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "NomPatient", consultation.idPatients);
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
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "NomPatient", consultation.idPatients);

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
        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult CreateOrdonnance(string Message, Ordonnance consultOrd)
        //{
        //    var UserId = User.Identity.GetUserId();
        //    var ConsultationID = (int)Session["ConsultationID"];

        //    Patients patients = new Patients();





        //    Ordonnance job = new Ordonnance
        //    {
        //        ConsultationID = ConsultationID,
        //        Message = Message,
        //        ApplyDate = DateTime.Now
        //    };

        //    db.ConsultationOrdonnances.Add(job);
        //    db.SaveChanges();

        //    var OneBlog = (from e in db.ConsultationOrdonnances
        //                   join p in db.Consultations
        //                   on e.ConsultationID equals p.ConsultationID
        //                   join s in db.Patients
        //                   on p.idPatients equals s.IdPatients
        //                   join t in db.Users
        //                   on p.UserID equals t.Id
        //                   where e.ConsultationID == p.ConsultationID


        //                   select new
        //                   {
        //                       e.Message,
        //                       e.ApplyDate,
        //                       s.MatriculePatients,
        //                       s.NomPatient,
        //                       s.PrenomPatient,
        //                       t.UserName,
        //                       p.ConsultationID

        //                   }).ToList();

        //    var last = OneBlog.Last();

        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport2.rpt"));
        //    rd.SetDataSource(last);
        //    rd.SetDataSource(new[] { last });

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();

        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);

        //    return File(stream, "application/pdf", "OrdonnancePatient.pdf");

        //    return View();

        //}

        public ActionResult CreateRDV(RDV consultOrd)
        {

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateRDV(string Message, RDV consultRDV)
        {
            //var UserId = User.Identity.GetUserId();
            var ConsultationID = (int)Session["ConsultationID"];

            //Patients patients = new Patients();





            RDV job = new RDV
            {
                ConsultationID = ConsultationID,
                Message = Message,
                ApplyDate = DateTime.Now
            };

            db.RDV.Add(job);
            db.SaveChanges();

            var OneBlog = (from e in db.RDV
                           join p in db.Consultations
                           on e.ConsultationID equals p.ConsultationID
                           join s in db.Patients
                           on p.idPatients equals s.IdPatients
                           join t in db.Users
                           on p.UserID equals t.Id
                           where e.ConsultationID == p.ConsultationID


                           select new
                           {
                               Message = e.Message,
                               ApplyDate = e.ApplyDate,
                               MatriculePatients = s.MatriculePatients,
                               NomPatient = s.NomPatient,
                               PrenomPatient = s.PrenomPatient,
                               UserName = t.UserName,
                               ConsultationID = p.ConsultationID

                           }).ToList();

            var last = OneBlog.Last();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));
            //rd.SetDataSource(last);
            rd.SetDataSource(new[] { last });

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "LettreConfrere.pdf");

           // return View();

        }



      

       




    }
}
