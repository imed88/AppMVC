﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Ordonnances
    {
        [Key]
        public int OrdonnancesId { get; set; }
        [Required]
        public int IdPaitents { get; set; }
        public virtual Patients Patients { get; set; }
        [Required]
        public int OrderId { get; set; }
       


    }
}