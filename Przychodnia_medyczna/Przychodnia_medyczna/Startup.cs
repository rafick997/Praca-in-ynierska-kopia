using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Przychodnia_medyczna.Models;

[assembly: OwinStartupAttribute(typeof(Przychodnia_medyczna.Startup))]
namespace Przychodnia_medyczna
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRole();
            CreatePatientAndManagerRoles();
            if (Laboratory.Count() <= 0)
            {
                CreateLaboratory();
            }
        }
        public void CreateLaboratory()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Laboratory lab = new Laboratory();
                lab.LabolatoryName = "KLabs";
                lab.LaboratoryId = "01";
                lab.City = "Rzeszow";
                lab.Country = "Poland";
                lab.ZipCode = "35084";
                lab.Street = "Poznanska 2";

                context.Laboratories.Add(lab);
                context.SaveChanges();
            }
        }

        public async void CreatePatientAndManagerRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // creating Creating Manager role     
            var x = await roleManager.RoleExistsAsync("Manager");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                await roleManager.CreateAsync(role);

            }

            // creating Creating Employee role     
            var y = await roleManager.RoleExistsAsync("Patient");
            if (!y)
            {
                var role = new IdentityRole();
                role.Name = "Patient";
                await roleManager.CreateAsync(role);
            }
        }

        public void CreateUserAndRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!(roleManager.RoleExists("SuperAdmin")))
            {
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "rafal.kuc007@gmail.com";
                user.Email = "rafal.kuc007@gmail.com";
                string pwd = "Sub@ru007";

                var newUser = UserManager.Create(user, pwd);
                if (newUser.Succeeded)
                {
                    var result = UserManager.AddToRoles(user.Id, "SuperAdmin");
                }
            }
        }
    }

}
