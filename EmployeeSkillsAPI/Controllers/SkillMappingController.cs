using EmployeeSkillsAPI.Data.DWH_Entities;
using EmployeeSkillsAPI.Data.ESM_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSkillsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillMappingController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Skillmapping> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllSkillMapping = context.Skillmappings.ToList();
            return AllSkillMapping;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllSkillMapping = context.Skillmappings;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.SkillMapping') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.SkillMapping]");

                List<BiRawEngineeringSkillsSkillMapping> ListBiRawEngineeringSkillsSkillMapping = new();
                foreach (var item in AllSkillMapping)
                {
                    ListBiRawEngineeringSkillsSkillMapping.Add(new BiRawEngineeringSkillsSkillMapping()
                    {
                        Id = item?.Id,
                        SkilltypeId = item?.SkilltypeId,
                        SkillId = item?.SkillId
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsSkillMappings.AddRange(ListBiRawEngineeringSkillsSkillMapping);
                BI_Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
