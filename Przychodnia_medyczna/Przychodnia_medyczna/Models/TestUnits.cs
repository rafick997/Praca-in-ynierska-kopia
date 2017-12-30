using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia_medyczna.Models
{
    public class TestUnit
    {
        [Key]
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public string UnitLabel { get; set; }

        public float MinValue { get; set; }

        public float MaxValue { get; set; }
     
        public virtual TestGroup TestGroup { get; set; }
        //Flaga Low lub High bedzie obliczana za pomoca funkcji np gdy trzeba bedzie wyswietlic wynik
    }
}