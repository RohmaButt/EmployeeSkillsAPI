using System;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Empcertification
    {
        public int EmpCertificationId { get; set; }
        public int? Empid { get; set; }
        public int? Certificationid { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? CertValidity { get; set; }
        public string Other { get; set; }

        public virtual Certification Certification { get; set; }
        public virtual Empdata Emp { get; set; }
    }
}
