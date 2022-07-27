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
    public class EmployeeFunctionController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Empfunction> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllEmpFunctions = context.Empfunctions.ToList();
            return AllEmpFunctions;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllEmpFunctions = context.Empfunctions;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.EmployeeFunction') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.EmployeeFunction]");

                List<BiRawEngineeringSkillsEmployeeFunction> ListBiRawEngineeringSkillsEmployeeFunction = new();
                foreach (var item in AllEmpFunctions)
                {
                    ListBiRawEngineeringSkillsEmployeeFunction.Add(new BiRawEngineeringSkillsEmployeeFunction()
                    {
                        Empid = item.Empid,
                        EmpFunctionId = item?.EmpFunctionId,
                        DateCreation = item?.DateCreation,
                        Funcid = item?.Funcid,
                        IsActive = item?.IsActive
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsEmployeeFunctions.AddRange(ListBiRawEngineeringSkillsEmployeeFunction);
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
