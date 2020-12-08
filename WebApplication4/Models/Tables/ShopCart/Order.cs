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
    
        public DateTime OrderDate { get; set; }
       
        public int ConsultationID { get; set; }
        public virtual Consultation Consultations { get; set; }

       
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}