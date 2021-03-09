using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables.ShopCart;

namespace WebApplication4.Models.Tables
{
    public class RadioBioCart
    {
        public RadioBio Radiobio { get; set; }
        public Consultation Consultations { get; set; }
       
        public RadioBioCart(RadioBio radioBio, Consultation consultation)
        {
            Radiobio = radioBio;
            Consultations = consultation;
            
        }
    }
}