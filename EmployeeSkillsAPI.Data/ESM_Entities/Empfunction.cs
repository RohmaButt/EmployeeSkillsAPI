using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Empfunction
    {
        public int EmpFunctionId { get; set; }
        public int? Empid { get; set; }
        public int? Funcid { get; set; }
        public DateTime? DateCreation { get; set; }
        public string IsActive { get; set; }

        public virtual Empdata Emp { get; set; }
        public virtual Function Func { get; set; }
    }
}
