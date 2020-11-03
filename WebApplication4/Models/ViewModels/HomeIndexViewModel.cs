using System;
using System.Collections.Generic;
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

        public  HomeIndexViewModel CreateModel()
        {

            return new HomeIndexViewModel()
            {
                ListProducts = _unitOfWork.GetRepositoryInstance<Product>().GetAllRecords()
            };
        }
    }
}