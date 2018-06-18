using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{

    public class TestElement
    {
        [Key]
        public int TestElementId   { get; set; }

        [ForeignKey("TestGroup")]
        public int TestGroupId { get; set; } //id grupy badania

        [ForeignKey("TestUnit")]
        public int UnitId { get; set; }  //id jednostki

        public float MinValue { get; set; }
        public float MaxValue { get; set; }

       

        public virtual TestGroup TestGroup { get; set; }
        public virtual TestUnit TestUnit { get; set; }

        public virtual PatientTestValue PateintTestValue { get; set; }

    }
}