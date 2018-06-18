using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Przychodnia_medyczna.Models
{
    public class TestUnit
    {
        [Key]
        public int UnitId { get; set; }

        public string UnitName { get; set; }

    }
}