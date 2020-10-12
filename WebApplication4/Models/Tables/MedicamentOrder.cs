using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class MedicamentOrder
    {
        public MedicamentOrder()
        {
            this.Order_Products = new HashSet<Order_Products>();
        }
        [Key]
        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public int idPatients { get; set; }

        public virtual Patients Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Products> Order_Products { get; set; }
    }
}