using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Przychodnia_medyczna.Models
{
    public class Laboratory
    {
    

        [Key]
        public string LaboratoryId { get; set; }

        public string LabolatoryName { get; set; }
        //Address
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public static int  Count()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Laboratories.Count();
        } 


    }
}