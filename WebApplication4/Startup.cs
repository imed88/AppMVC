using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication4.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication4.Startup))]
namespace WebApplication4
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultUsersAndRoles();
        }

        public void CreateDefaultUsersAndRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            IdentityRole role = new IdentityRole();

            if(!roleManager.RoleExists("Administrateur"))
            {
                role.Name = "Administrateur";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "darragi";
                user.Email = "imededdine.benzarti@gmail.com";
                
                var check = userManager.Create(user, "darragi@123");
                if(check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrateur");
                }
            }

        }
    }
}
