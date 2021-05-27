using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class RoleViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}