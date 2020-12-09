using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.ShopCart
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public virtual Order Orders { get; set; }
        public int ProductID { get; set; }
        public virtual Product Products { get; set; }
        public int Quantity { get; set; }
     

    }
}