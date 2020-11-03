using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models.Tables;
using WebApplication4.Repository;

namespace WebApplication4.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        [Authorize(Roles ="Administrateur")]
        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult Categories(string order, string currentFilter, string searching, int? page)
        {
            List<Specialite> allcategories = _unitOfWork.GetRepositoryInstance<Specialite>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allcategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            Specialite cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<Specialite>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Specialite>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new Specialite();
            }
            return View("UpdateCategory", cd);

        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetProduct());
        }

        public ActionResult ProductEdit(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Product tbl)
        {
            _unitOfWork.GetRepositoryInstance<Product>().Update(tbl);
            return RedirectToAction("Product");
        }


    }
}