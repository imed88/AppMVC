using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Order
    {
        public int OrderId { get; set; }
        public int IdPatients { get; set; }
        public virtual Patients patients {get; set;}
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}