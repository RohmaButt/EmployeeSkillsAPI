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
    public class EmployeeCertificationController : ControllerBase
    {
        [Route("Pull")]
        [HttpGet]
        public List<Empcertification> Get()
        {
            using var context = new EmployeeSkillsContext();
            var AllEmpCertifications = context.Empcertifications.ToList();
            return AllEmpCertifications;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllEmpCertifications = context.Empcertifications;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.EmployeeCertification') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.EmployeeCertification]");

                List<BiRawEngineeringSkillsEmployeeCertification> ListBiRawEngineeringSkillsEmployeeCertification = new();
                foreach (var item in AllEmpCertifications)
                {
                    ListBiRawEngineeringSkillsEmployeeCertification.Add(new BiRawEngineeringSkillsEmployeeCertification()
                    {
                        Certificationid = item?.Certificationid,
                        CertValidity = item?.CertValidity,
                        DateCreation = item?.DateCreation,
                        Empid = item?.Empid,
                        EmpCertificationId = item?.EmpCertificationId,
                        Other = item?.Other
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsEmployeeCertifications.AddRange(ListBiRawEngineeringSkillsEmployeeCertification);
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
