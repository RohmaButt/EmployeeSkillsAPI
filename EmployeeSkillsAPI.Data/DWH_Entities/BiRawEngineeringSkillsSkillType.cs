using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsSkillType
    {
        public int Id { get; set; }
        public int? SkillTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
