using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przychodnia_medyczna.Models
{
    public class Manager 
    {
      
        [ForeignKey("ApplicationUser")]
        public string ManagerId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        

    }

    public class ManagerRegisterModel
        {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ManagerId { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Laboratorium")]
        public string LaboratoryId { get; set; }
        [StringLength(11)]
        [Required]
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
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}