using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class ShoppingCartData
    {
        [Key]
        public int TempOrderID { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}