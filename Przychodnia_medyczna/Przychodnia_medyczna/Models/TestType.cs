using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    public class TestType
    {
        [Key]
        public int TestTypeId { get; set; }

        [ForeignKey("PatientTest")]
        public int TestId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TestElement> Elements { get; set; }
        public virtual PatientTest PatientTest { get; set; }
    }
}