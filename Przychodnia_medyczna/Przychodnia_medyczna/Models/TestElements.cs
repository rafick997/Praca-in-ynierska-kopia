using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    //Przerob na composite key
    public class TestElement
    {
        [Key]
        public int TestElementId   { get; set; }
        [ForeignKey("TestType")]
        public int TestTypeId { get; set; }

        [ForeignKey("TestGroup")]
        public int TestGroupId { get; set; }

        public virtual TestType TestType { get; set; }

        public virtual TestGroup TestGroup { get; set; }
    }
}