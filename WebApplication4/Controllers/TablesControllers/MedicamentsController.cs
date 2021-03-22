using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using PagedList.Mvc;
using WebApplication4.Models.Tables.ShopCart;
using System.Net;

namespace WebApplication4.Controllers.TablesControllers
{
    [Authorize(Roles = "Administrateur")]
    public class MedicamentsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Medicaments
       

        public PartialViewResult ProductPartial(string order, string currentFilter, int? page, string movieGenre, string searchString)
        {
            //var pageNumber = page ?? 1;
            //var pageSize = 10;
            ////var products = db.Products.OrderBy(x => x.ProductName).ToList();
            //var products = db.Products.OrderBy(x => x.ProductName).ToPagedList(pageNumber, pageSize);
            //return PartialView(products);

            
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;


            //var Patient = from c in db.Patients select c;
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Products
                           orderby d.DenominationCI
                           select d.DenominationCI;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);
            var patients = from c in db.Products select c;

            if (!String.IsNullOrEmpty(searchString))
                {
                    patients = patients.Where(s => s.NameProduct.Contains(searchString));

                }
            if (!string.IsNullOrEmpty(movieGenre))
            {
                patients = patients.Where(x => x.DenominationCI == movieGenre);
            }

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(order) ? "NomPatient_desc" : "";
                ViewBag.FirstNameSortParm = String.IsNullOrEmpty(order) ? "PrenomPatient_desc" : "";
                ViewBag.UsineNameSortParm = String.IsNullOrEmpty(order) ? "UsinePatient_desc" : "";


                switch (order)
                {
                    case "NomPatient_desc":
                        patients = patients.OrderByDescending(s => s.NameProduct);
                        break;
                  
                    
                    default:
                        patients = patients.OrderBy(s => s.ProductID);
                        break;
                }

                // return View(usines.ToList());

                int pageSize = 15;
                int pageNumber = (page ?? 1);
                return PartialView(patients.ToPagedList(pageNumber, pageSize));
            }
        public ActionResult ProductIndex()
        {
            return View();
        }

        // GET: Medicaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

    }

       




    }

