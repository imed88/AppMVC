using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class EventsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors");

            return View();
        }
      
        public JsonResult GetEvents()
        {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
         }

        public JsonResult SaveEvent()
        {
            var status = false;
            ViewBag.idDoctors = new SelectList(db.MedecinConventionnes, "idDoctors", "nameDoctors");
            return new JsonResult { Data = new { status = status } };
        }



        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
      
            var status = false;
           
                if (e.EventID > 0)
                {
                //Update the event
                var v = db.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {

                        v.Subject = e.Subject;
                        v.DateStart = e.DateStart;
                        v.Description = e.Description;
                        v.ThemeColor = e.ThemeColor;
                        v.idDoctors = e.idDoctors;
                    }
                }
                else
                {

                    db.Events.Add(e);
                }
                db.SaveChanges();
                status = true;
        

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
          
                var v = db.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        }
    }
}