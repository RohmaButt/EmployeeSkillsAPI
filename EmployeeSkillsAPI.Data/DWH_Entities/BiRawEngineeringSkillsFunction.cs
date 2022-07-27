using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsFunction
    {
        public int Id { get; set; }
        public int? FuncId { get; set; }
        public string FuncName { get; set; }
        public string FuncDescription { get; set; }
        public DateTime? DateCreation { get; set; }
        public string IsActive { get; set; }
    }
}
