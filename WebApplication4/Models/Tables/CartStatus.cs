using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class CartStatus
    {
        [Key]
        public int CartStatusId { get; set; }
        public string CartStatusName { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}