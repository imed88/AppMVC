using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class EvenstController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Evenst
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetEvents()
        {
            var events = db.Events.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}