using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Empdata
    {
        public Empdata()
        {
            Empcertifications = new HashSet<Empcertification>();
            Empfunctions = new HashSet<Empfunction>();
            Empskills = new HashSet<Empskill>();
        }

        public int Empid { get; set; }
        public string EmpEmail { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Password { get; set; }
        public uint EmpEmployeeId { get; set; }
        public int RoleId { get; set; }
        public DateTime? CareerStartDate { get; set; }
        public string UniqueCode { get; set; }
        public string EmpUserName { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<Empcertification> Empcertifications { get; set; }
        public virtual ICollection<Empfunction> Empfunctions { get; set; }
        public virtual ICollection<Empskill> Empskills { get; set; }
    }
}
