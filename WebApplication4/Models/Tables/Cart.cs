using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int IdPaitents { get; set; }
        public virtual Patients Patients { get; set; }

        public int CartStatusId { get; set; }
        public virtual CartStatus CartStatus { get; set; }
    }
}