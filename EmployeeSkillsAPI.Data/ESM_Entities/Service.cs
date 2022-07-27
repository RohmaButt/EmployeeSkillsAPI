using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class Service
    {
        public Service()
        {
            Empdata = new HashSet<Empdata>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Empdata> Empdata { get; set; }
    }
}
