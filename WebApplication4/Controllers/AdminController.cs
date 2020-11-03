using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models.Tables;
using WebApplication4.Repository;
using System.Data.Entity;
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

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var allcategories = _unitOfWork.GetRepositoryInstance<Specialite>().GetAllRecords();
            foreach (var item in allcategories)
            {
                list.Add(new SelectListItem { Value = item.IdSpecialite.ToString(), Text = item.SpecialiteName });
            }
            return list;
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
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), pic);
                file.SaveAs(path);
            }
            tbl.ProductImage = file!=null?pic: tbl.ProductImage;
            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Update(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file !=null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), pic);
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Add(tbl);
            return RedirectToAction("Product");
        }
    }

}
