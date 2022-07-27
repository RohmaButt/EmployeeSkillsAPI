using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Skillmapping
    {
        public int Id { get; set; }
        public int? SkillId { get; set; }
        public int? SkilltypeId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Skilltype Skilltype { get; set; }
    }
}
