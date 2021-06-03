using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModels
{
    [NotMapped]
    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name ="Ancien Mot de Passe")]
        public string CurrentPassword { get; set; }
        [Required]
        [Display(Name = "Nouveau mot de Passe")]
        public string NewPassword { get; set; }
    
    }
}