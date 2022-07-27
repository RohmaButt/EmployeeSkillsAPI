using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsEmployeeCertification
    {
        public int Id { get; set; }
        public int? EmpCertificationId { get; set; }
        public int? Empid { get; set; }
        public int? Certificationid { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? CertValidity { get; set; }
        public string Other { get; set; }
    }
}
