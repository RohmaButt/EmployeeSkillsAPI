using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Function
    {
        public Function()
        {
            Empfunctions = new HashSet<Empfunction>();
            Stfunctions = new HashSet<Stfunction>();
        }

        public int FuncId { get; set; }
        public string FuncName { get; set; }
        public string FuncDescription { get; set; }
        public DateTime? DateCreation { get; set; }
        public string IsActive { get; set; }

        public virtual ICollection<Empfunction> Empfunctions { get; set; }
        public virtual ICollection<Stfunction> Stfunctions { get; set; }
    }
}
