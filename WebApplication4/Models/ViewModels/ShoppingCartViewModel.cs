using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables;

namespace WebApplication4.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        [Key]
        public int ShoppingCartID { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}