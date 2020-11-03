using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int idSpecialite { get; set; }
        public virtual Specialite specialite { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool IsFeatured { get; set; }
        public int Quantity { get; set; }


    }
}