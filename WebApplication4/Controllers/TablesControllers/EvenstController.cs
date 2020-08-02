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
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;

            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);
            scheduler.Localization.Set(SchedulerLocalization.Localizations.French);

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }
        [Authorize(Roles ="Administrateur, Infirmier")]
        public ContentResult Data()
        {
            var apps = db.Events.ToList();
            return new SchedulerAjaxData(apps);
        }
        [Authorize(Roles = "Administrateur, Infirmier")]
        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Events>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        db.Events.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.IdEvent;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
        [Authorize(Roles = "Administrateur")]
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