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
    public class SkillTypeController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Skilltype> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllSkillTypes = context.Skilltypes.ToList();
            return AllSkillTypes;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllSkilltypes = context.Skilltypes;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.SkillType') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.SkillType]");

                List<BiRawEngineeringSkillsSkillType> ListBiRawEngineeringSkillsSkillType = new();
                foreach (var item in AllSkilltypes)
                {
                    ListBiRawEngineeringSkillsSkillType.Add(new BiRawEngineeringSkillsSkillType()
                    {
                        DateCreation = item?.DateCreation,
                        SkillTypeId = item.SkillTypeId,
                        Name = item?.Name,
                        Description = item?.Description,
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsSkillTypes.AddRange(ListBiRawEngineeringSkillsSkillType);
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