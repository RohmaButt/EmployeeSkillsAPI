using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsSkillTypeFunction
    {
        public int Id { get; set; }
        public int? StFuncId { get; set; }
        public int? SkilltypeId { get; set; }
        public int? FuncId { get; set; }
        public string IsActive { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
