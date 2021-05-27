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
        [Required]
        public string Code { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Required]
        public string Categorie  { get; set; }
        [Required]
        public string DenominationCI { get; set; }
       

        
        //[DataType(DataType.ImageUrl)]
        //public string ImageFile { get; set; }
        
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}