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
        public IEnumerable<Product> ListProducts { get; set; }
        public static GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        ApplicationDbContext db = new ApplicationDbContext();
        public  HomeIndexViewModel CreateModel(string search)
        {
            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@search", search)
            };
            IEnumerable<Product> data = db.Database.SqlQuery<Product>("GetBySearch", parameter).ToList();
            return new HomeIndexViewModel()
            {
                ListProducts =data 
            };
        }
    }
}