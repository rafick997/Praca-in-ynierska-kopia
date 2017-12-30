using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Przychodnia_medyczna.Models
{
    public class userManager:UserManager<ApplicationUser>
    {
          public userManager(IUserStore<ApplicationUser> store):base(store)
        {

        }
        public static userManager Create(IdentityFactoryOptions<userManager> option, IOwinContext context)
        {
            ApplicationDbContext db = context.Get<ApplicationDbContext>();
            userManager manager = new userManager(new UserStore<ApplicationUser>(db));
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail=true
          
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = false
            };
            return manager;
        }
    }
}