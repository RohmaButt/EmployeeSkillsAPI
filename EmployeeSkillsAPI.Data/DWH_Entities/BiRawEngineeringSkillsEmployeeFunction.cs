using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsEmployeeFunction
    {
        public int Id { get; set; }
        public int? EmpFunctionId { get; set; }
        public int? Empid { get; set; }
        public int? Funcid { get; set; }
        public DateTime? DateCreation { get; set; }
        public string IsActive { get; set; }
    }
}
