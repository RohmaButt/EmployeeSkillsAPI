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
    public class EmployeeSkillController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Empskill> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllEmpSkills = context.Empskills.ToList();
            return AllEmpSkills;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllEmpSkills = context.Empskills;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.EmployeeSkill') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.EmployeeSkill]");

                List<BiRawEngineeringSkillsEmployeeSkill> ListBiRawEngineeringSkillsEmployeeSkill = new();
                foreach (var item in AllEmpSkills)
                {
                    ListBiRawEngineeringSkillsEmployeeSkill.Add(new BiRawEngineeringSkillsEmployeeSkill()
                    {
                        Empid = item.Empid,
                        EmpSkillId = item?.EmpSkillId,
                        Rating = item?.Rating,
                        Skillid = item?.Skillid,
                        Skilltypeid = item?.Skilltypeid
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsEmployeeSkills.AddRange(ListBiRawEngineeringSkillsEmployeeSkill);
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
