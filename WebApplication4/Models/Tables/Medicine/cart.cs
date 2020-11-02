using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.Medicine
{
    public class cart
    {
        [Key]
        public int CartID { get; set; }
        public int productid { get; set; }
        public string productname { get; set; }

        public float price { get; set; }
        public int qty { get; set; }
        public float bill { get; set; }
        public List<tbl_product> Products { get; set; }
        public int ConsultationID { get; set; }
        public virtual Consultation Consultation { get; set; }




    }
}