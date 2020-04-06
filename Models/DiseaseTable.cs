using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YogamedAppRole.Models
{
    public partial class DiseaseTable
    {
        public DiseaseTable()
        {
            UserDisease = new HashSet<UserDisease>();
            YogaTable = new HashSet<YogaTable>();
        }
        [Key]
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }

        public virtual ICollection<UserDisease> UserDisease { get; set; }
        public virtual ICollection<YogaTable> YogaTable { get; set; }
    }
}
