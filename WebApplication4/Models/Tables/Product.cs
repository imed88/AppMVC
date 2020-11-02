using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int IdSpecialite { get; set; }
        public virtual Specialite Specialite { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Description { get; set; }
        public string ProductImage { get; set; }
        public bool IsFeatured { get; set; }
        public int Quantity { get; set; }


    }
}