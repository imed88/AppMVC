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
    }
}