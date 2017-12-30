
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przychodnia_medyczna.Models
{
    public class Address
    {
        [ ForeignKey("Patient")]
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public virtual Patient Patient { get; set; }
        

    }
}