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
        public string Code { get; set; }
        public string NameProduct { get; set; }
        public string Categorie  { get; set; } 
        public string DenominationCI { get; set; }
       

        
        //[DataType(DataType.ImageUrl)]
        //public string ImageFile { get; set; }
        
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}