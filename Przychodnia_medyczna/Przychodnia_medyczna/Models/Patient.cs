using Przychodnia_medyczna.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{


    public class Patient
    {
        
        [ForeignKey("ApplicationUser")]
        public string PatientId { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Numer PESEL")]
        public string PESEL { get; set; }

        public virtual ICollection<PatientTest> Tests { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Address Address{ get; set; }           
    }

    public class PatientRegisterModel 
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }
       
        [Required]
        [Display(Name = "Numer PESEL")]
        public string PESEL { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Numer kontaktowy")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Rola")]
        public string Role { set; get; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
       
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public virtual Address Address { get; set; }
    }
}