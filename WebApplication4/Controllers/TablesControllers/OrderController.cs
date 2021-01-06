using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers.TablesControllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Order
        public System.Web.Mvc.ActionResult Index(string order, string currentFilter, string searching, int? page)
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


            //var Patient = from c in db.Patients select c;
            var patients = from c in db.Orders select c;

            if (!String.IsNullOrEmpty(searching))
            {
                patients = patients.Where(s => s.MatriculePatients.Contains(searching));

            }

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(order) ? "NomPatient_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(order) ? "PrenomPatient_desc" : "";
            ViewBag.UsineNameSortParm = String.IsNullOrEmpty(order) ? "UsinePatient_desc" : "";


            switch (order)
            {
                case "NomPatient_desc":
                    patients = patients.OrderByDescending(s => s.MatriculePatients);
                    break;
              
                default:
                    patients = patients.OrderBy(s => s.OrderID);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(patients.ToPagedList(pageNumber, pageSize));
        }



        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
