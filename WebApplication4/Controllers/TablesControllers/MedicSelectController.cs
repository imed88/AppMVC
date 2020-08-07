using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers.TablesControllers
{
    public class MedicSelectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MedicSelect
        [HttpPost]
        public ActionResult Index(IEnumerable<string> MedicsSelect)
        {
            if (MedicsSelect == null)
            {
                TempData["MSG"] = "Pas de Medicaments Selectionnés";
            }
            else
            {
                string res = "Medicaments Selectionnés :" + string.Join(",", MedicsSelect);
                TempData["MSG"] = res;
            }
            return RedirectToAction("Index");
        }


        public ActionResult Index()
        {
            MedicamentListBox model = new MedicamentListBox();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Medicament medics in db.Medicaments)
            {
                SelectListItem s = new SelectListItem()
                {
                    Text = medics.MedicamentName,
                    Value = medics.MedicamentName,
                    Selected = false
                };

                listItems.Add(s);
            }

            model.Medicaments = listItems;
            return View(model);
        }

        // GET: MedicSelect/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicSelect/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicSelect/Create
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

        // GET: MedicSelect/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicSelect/Edit/5
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

        // GET: MedicSelect/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicSelect/Delete/5
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
