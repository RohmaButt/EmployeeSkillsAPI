using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsSkill
    {
        public int Id { get; set; }
        public int? SkillId { get; set; }
        public string Skillname { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string OtherSkill { get; set; }
        public string Status { get; set; }
    }
}
