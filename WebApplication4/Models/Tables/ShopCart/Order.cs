using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.ShopCart
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public int idPatients { get; set; }
        public virtual Patients Patients { get; set; }


    }
}