using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables;
using WebApplication4.Repository;

namespace WebApplication4.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        ApplicationDbContext context = new ApplicationDbContext();
        public List<Product> ListProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            List<Product> data = context.Database.SqlQuery<Product>("GetBySearch @search", param).ToList();
            return new HomeIndexViewModel
            {
                ListProducts = data
            };
        }
    }
}