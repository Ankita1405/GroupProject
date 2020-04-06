using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogamedAppRole.Models
{
    public partial class YogaTable
    {[Key]
        public int YogaId { get; set; }
        public string YogaName { get; set; }
        public string YogaStep { get; set; }
        public int? YdfkId { get; set; }

        public virtual DiseaseTable Ydfk { get; set; }
    }
}
