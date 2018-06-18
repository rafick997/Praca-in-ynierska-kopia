using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    public class PatientTestValue
    {
        [Key]
        public int TestValueId { get; set; }

        [ForeignKey("PatientTest")]
        public int TestId { get; set; }

        [ForeignKey("TestElements")]
        public int TeElementId { get; set; }

        public float Value { get; set; }
       
        public virtual PatientTest PatientTest { get; set; }
        public virtual ICollection<TestElement> TestElements { get; set; } 
    }
}