using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class MedOrder_Products
    {
        [Key]
        public int OrderID { get; set; }
        public int PID { get; set; }
        public int Qty { get; set; }
        public decimal TotalSale { get; set; }

        public virtual MedicamentOrder Order { get; set; }
        public virtual Medicament Product
        {
            get; set;
        }
    }
}