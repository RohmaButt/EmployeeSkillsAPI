using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Certifications = new HashSet<Certification>();
            Empskills = new HashSet<Empskill>();
            Skillmappings = new HashSet<Skillmapping>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillId { get; set; }
        public string Skillname { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string OtherSkill { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Empskill> Empskills { get; set; }
        public virtual ICollection<Skillmapping> Skillmappings { get; set; }
    }
}
