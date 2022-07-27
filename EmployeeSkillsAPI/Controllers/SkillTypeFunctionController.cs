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
    public class SkillTypeFunctionController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Stfunction> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllSkillTypeFunctions = context.Stfunctions.ToList();
            return AllSkillTypeFunctions;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllSkillTypeFunctions = context.Stfunctions;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.SkillTypeFunction') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.SkillTypeFunction]");

                List<BiRawEngineeringSkillsSkillTypeFunction> ListBiRawEngineeringSkillsSkillTypeFunction = new();
                foreach (var item in AllSkillTypeFunctions)
                {
                    ListBiRawEngineeringSkillsSkillTypeFunction.Add(new BiRawEngineeringSkillsSkillTypeFunction()
                    {
                        FuncId = item?.FuncId,
                        DateCreation = item?.DateCreation,
                        IsActive = item?.IsActive,
                        SkilltypeId = item.SkilltypeId,
                        StFuncId = item.StFuncId
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsSkillTypeFunctions.AddRange(ListBiRawEngineeringSkillsSkillTypeFunction);
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
