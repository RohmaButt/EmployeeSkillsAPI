using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsEmployeeDatum
    {
        public int Id { get; set; }
        public int? Empid { get; set; }
        public string EmpEmail { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Password { get; set; }
        public long? EmpEmployeeId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CareerStartDate { get; set; }
        public string UniqueCode { get; set; }
        public string EmpUserName { get; set; }
        public int? ServiceId { get; set; }
    }
}
