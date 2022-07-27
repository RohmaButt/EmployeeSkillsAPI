using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsService
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
