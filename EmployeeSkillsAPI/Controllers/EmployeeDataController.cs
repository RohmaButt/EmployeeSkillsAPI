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
    public class EmployeeDataController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Empdata> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllEmpData = context.Empdata.ToList();
            return AllEmpData;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllEmpData = context.Empdata;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.EmployeeData') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.EmployeeData]");

                List<BiRawEngineeringSkillsEmployeeDatum> ListBiRawEngineeringSkillsEmployeeDatum = new();
                foreach (var item in AllEmpData)
                {
                    ListBiRawEngineeringSkillsEmployeeDatum.Add(new BiRawEngineeringSkillsEmployeeDatum()
                    {
                        Empid = item.Empid,
                        CareerStartDate = item?.CareerStartDate,
                        DateCreation = item?.DateCreation,
                        EmpEmail = item?.EmpEmail,
                        EmpEmployeeId = item?.EmpEmployeeId,
                        EmpUserName = item?.EmpUserName,
                        Password = item?.Password,
                        RoleId = item?.RoleId,
                        ServiceId = item?.ServiceId,
                        UniqueCode = item.UniqueCode
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsEmployeeData.AddRange(ListBiRawEngineeringSkillsEmployeeDatum);
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
