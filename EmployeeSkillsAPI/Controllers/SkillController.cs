using EmployeeSkillsAPI.Data.DWH_Entities;
using EmployeeSkillsAPI.Data.ESM_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSkillsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Skill> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllSkills = context.Skills.ToList();
            return AllSkills;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllSkills = context.Skills;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.Skill') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.Skill]");
                List<BiRawEngineeringSkillsSkill> ListBiRawEngineeringSkillsSkill = new();
                foreach (var item in AllSkills)
                {
                    if (item?.SkillId != null)
                    {
                        ListBiRawEngineeringSkillsSkill.Add(new BiRawEngineeringSkillsSkill()
                        {
                            SkillId = item.SkillId,
                            Skillname = item?.Skillname,
                            Description = item?.Description,
                            Status = item?.Status,
                            CreationDate = item?.CreationDate,
                            OtherSkill = item?.OtherSkill
                        });
                    }
                }
                BI_Context.BiRawEngineeringSkillsSkills.AddRange(ListBiRawEngineeringSkillsSkill);
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
