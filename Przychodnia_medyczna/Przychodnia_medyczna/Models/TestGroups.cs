using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    public class TestGroup
    {
        [Key]
        public int TestGroupId { get; set; }

        public string GroupName { get; set; }

        public virtual ICollection <TestElement> TestElements { get; set; }
    }
}