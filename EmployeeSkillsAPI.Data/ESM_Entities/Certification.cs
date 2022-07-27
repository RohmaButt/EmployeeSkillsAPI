using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Certification
    {
        public Certification()
        {
            Empcertifications = new HashSet<Empcertification>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CertificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; }
        public int? SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual ICollection<Empcertification> Empcertifications { get; set; }
    }
}
