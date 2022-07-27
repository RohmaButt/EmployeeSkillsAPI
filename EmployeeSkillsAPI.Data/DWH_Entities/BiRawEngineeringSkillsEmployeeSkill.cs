using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsEmployeeSkill
    {
        public int Id { get; set; }
        public int? EmpSkillId { get; set; }
        public int? Empid { get; set; }
        public int? Skillid { get; set; }
        public short? Rating { get; set; }
        public int? Skilltypeid { get; set; }
    }
}
