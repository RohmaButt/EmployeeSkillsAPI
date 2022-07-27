using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Empskill
    {
        public int EmpSkillId { get; set; }
        public int? Empid { get; set; }
        public int? Skillid { get; set; }
        public sbyte? Rating { get; set; }
        public int? Skilltypeid { get; set; }

        public virtual Empdata Emp { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Skilltype Skilltype { get; set; }
    }
}
