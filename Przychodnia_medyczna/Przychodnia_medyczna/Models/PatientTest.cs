using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    public class PatientTest
    {
        [Key]
        public int TestId { get; set; }

        public string TestName { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }


        public virtual Patient Patient { get; set; }
        public virtual ICollection<TestValue> TestValues { get; set; }
        public virtual ICollection<TestType> TestTypes { get; set; }//edit
    }
}