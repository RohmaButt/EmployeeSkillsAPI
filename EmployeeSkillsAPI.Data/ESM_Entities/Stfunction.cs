using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Stfunction
    {
        public int StFuncId { get; set; }
        public int? SkilltypeId { get; set; }
        public int? FuncId { get; set; }
        public string IsActive { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual Function Func { get; set; }
        public virtual Skilltype Skilltype { get; set; }
    }
}
