using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.ShopCart
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int IdSpecialite { get; set; }
        public virtual Specialite Specialites { get; set; } 

        public int Quantity { get; set; }
      
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }

        public string Image { get; set; }

        public bool IsNew { get; set; }

    }
}