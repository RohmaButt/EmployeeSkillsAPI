using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsSkillMapping
    {
        public int SkillMappingId { get; set; }
        public int? Id { get; set; }
        public int? SkillId { get; set; }
        public int? SkilltypeId { get; set; }
    }
}
