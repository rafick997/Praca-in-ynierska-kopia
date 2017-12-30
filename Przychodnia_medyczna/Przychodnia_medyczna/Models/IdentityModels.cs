using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Przychodnia_medyczna.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    { 
         public virtual Patient Patient { get; set; }
        public  virtual Manager Manager { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
          
            return userIdentity;
        }

        public static explicit operator ApplicationUser(Patient v)
        {
            ApplicationUser u = new ApplicationUser();
           
            u.Id = v.PatientId;
           
           
            return u;

        }

        public static explicit operator ApplicationUser(Manager v)
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PatientTest> PatientTests { get; set; }
        public DbSet<TestGroup> TestGroups { get; set; }
        public DbSet<TestValue> TestValues { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<TestElement> TestElements { get; set; }
        public DbSet <TestUnit> TestUnits { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


       

   
        
    }
}