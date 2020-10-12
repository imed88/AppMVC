using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.Medicine
{
    public class ProductPurchase
    {
        [Key]
        public int PurchaseID { get; set; }
        public string PurchaseQuantity { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        public int pro_id { get; set; }
        public virtual tbl_product product { get; set; }
    }
}