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
    public class FunctionController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Function> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllFunctions = context.Functions.ToList();
            return AllFunctions;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllFunctions = context.Functions;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.Functions') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.Functions]");

                List<BiRawEngineeringSkillsFunction> ListBiRawEngineeringSkillsFunction = new();
                foreach (var item in AllFunctions)
                {
                    ListBiRawEngineeringSkillsFunction.Add(new BiRawEngineeringSkillsFunction()
                    {
                        FuncId = item?.FuncId,
                        DateCreation = item?.DateCreation,
                        FuncDescription = item?.FuncDescription,
                        FuncName = item?.FuncName,
                        IsActive = item?.IsActive,
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsFunctions.AddRange(ListBiRawEngineeringSkillsFunction);
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
