using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int IdEvent{ get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "start_date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "end_date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "ThemeColor")]
        public string ThemeColor { get; set; }

        [Display(Name = "IsFullDay")]
        public bool IsFullDay { get; set; }



        [DHXJson(Alias = "Medecin Conventionné")]
        public int idDoctors { get; set; }

        public virtual MedecinConventionne Medecin  { get; set; }
    }
}