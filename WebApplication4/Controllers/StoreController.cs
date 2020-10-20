﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Specialites.ToList());
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = db.Specialites.Include("Medicament")
  .Single(g => g.SpecialiteName == genre);
            return View(genreModel);


        }
        public ActionResult Details(int id)
        {
            var album = db.Medicaments.Find(id);
            return View(album);
        }

    }
}