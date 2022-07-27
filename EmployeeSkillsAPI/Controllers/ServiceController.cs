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
    public class ServiceController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Service> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllServices = context.Services.ToList();
            return AllServices;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllServices = context.Services;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.Service') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.Service]");

                List<BiRawEngineeringSkillsService> ListBiRawEngineeringSkillsService = new();
                foreach (var item in AllServices)
                {
                    ListBiRawEngineeringSkillsService.Add(new BiRawEngineeringSkillsService()
                    {
                        ServiceId = item.ServiceId,
                        ServiceName = item?.ServiceName,
                        Description = item?.Description,
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsServices.AddRange(ListBiRawEngineeringSkillsService);
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
