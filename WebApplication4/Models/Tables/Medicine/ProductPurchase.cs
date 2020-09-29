using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.Medicine
{
    public class ProductPurchase
    {
        public int PurchaseID { get; set; }
        public string PurchaseProd { get; set; }
        public string PurchaseQuantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}