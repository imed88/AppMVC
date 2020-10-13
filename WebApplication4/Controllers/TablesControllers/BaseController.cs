using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public BaseController()
        {
            ViewBag.CartTotalPrice = CartTotalPrice;
            ViewBag.Cart = Cart;
            ViewBag.CartUnits = Cart.Count;
        }

        private List<MedShoppingCartData> Cart
        {
            get
            {
                return db.MedShoppingCartDatas.ToList();
            }
        }

        private decimal CartTotalPrice
        {
            get
            {
                return Cart.Sum(c => c.Quantity * c.UnitPrice);
            }
        }

    }
}
