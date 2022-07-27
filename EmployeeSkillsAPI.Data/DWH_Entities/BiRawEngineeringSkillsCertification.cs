using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class BiRawEngineeringSkillsCertification
    {
        public int Id { get; set; }
        public int? CertificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; }
        public int? SkillId { get; set; }
    }
}
