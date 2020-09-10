using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModels
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string To { get; set; }
        public string ContentMsg { get; set; }
    }
}