using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication4.Models.Tables;

namespace WebApplication4.Models
{
    
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        //public virtual ICollection<AppointementModel> Appointments { get; set; }
        //public virtual ICollection<Medicament> Medicaments { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
       // public virtual ICollection<ConsultationOrdonnance> Ordonnances { get; set; }
       

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici

            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Specialite> Specialites { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.MedecinConventionne> MedecinConventionnes { get; set; }
       
        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Usine> Usines { get; set; }
        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Patients> Patients { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.AppointementModel> AppointementModels { get; set; }
        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicament> Medicaments { get; set; }
        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Consultation> Consultations { get; set; }

        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.ConsultationOrdonnance> ConsultationOrdonnances { get; set; }
        ////public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Ordonnance> ConsultationOrdonnances { get; set; }

        public DbSet<FileDetail> FileDetails { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.RDV> RDV { get; set; }
        public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicaments> Medicaments { get; set; }
   
      

        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicine.tbl_product> tbl_product { get; set; }
        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicine.tbl_invoice> tbl_invoice { get; set; }
        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicine.tbl_order> tbl_order { get; set; }
        //public System.Data.Entity.DbSet<WebApplication4.Models.Tables.Medicine.ProductPurchase> productPurchase { get; set; }


    }
}