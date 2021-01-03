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

        public string CodePCT { get; set; }
        public string Categorie  { get; set; } 
        public string DenominationCI { get; set; }
        public string AP { get; set; }

        

        public string ImageFile { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}