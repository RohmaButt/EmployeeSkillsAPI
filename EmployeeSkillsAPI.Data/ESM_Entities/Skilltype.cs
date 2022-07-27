using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Skilltype
    {
        public Skilltype()
        {
            Empskills = new HashSet<Empskill>();
            Skillmappings = new HashSet<Skillmapping>();
            Stfunctions = new HashSet<Stfunction>();
        }

        public int SkillTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual ICollection<Empskill> Empskills { get; set; }
        public virtual ICollection<Skillmapping> Skillmappings { get; set; }
        public virtual ICollection<Stfunction> Stfunctions { get; set; }
    }
}
