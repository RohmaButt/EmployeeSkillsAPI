using EmployeeSkillsAPI.Data.DWH_Entities;
using EmployeeSkillsAPI.Data.ESM_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSkillsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ILogger<CertificationController> _logger;

        public CertificationController(ILogger<CertificationController> logger)
        {
            _logger = logger;
        }
        public object BiRawEngineeringSkillsCertification { get; private set; }

        [Route("Pull")]
        [HttpGet]
        public List<Certification> Get()
        {
            _logger.LogInformation("CertificationController: Get started");
            using var context = new EmployeeSkillsContext();
            var AllCertifications = context.Certifications.ToList();
            _logger.LogInformation("CertificationController: Get completed");
            return AllCertifications;
        }

        [Route("Push")]
        [HttpPost]
        public bool Post()
        {
            try
            {
                using var context = new EmployeeSkillsContext();
                var AllCertifications = context.Certifications;
                using var BI_Context = new DWH_OP_SQL_Context();
                BI_Context.Database.ExecuteSqlRaw("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'bi_raw_engineering_skills.Certification') TRUNCATE TABLE [dbo].[bi_raw_engineering_skills.Certification]");
                
                List<BiRawEngineeringSkillsCertification> ListBiRawEngineeringSkillsCertification = new();
                foreach (var item in AllCertifications)
                {
                    ListBiRawEngineeringSkillsCertification.Add(new BiRawEngineeringSkillsCertification()
                    {
                        CertificationId = item.CertificationId,
                        Name = item?.Name,
                        Description = item?.Description,
                        Status = item?.Status,
                        CreationDate = item?.CreationDate,
                        SkillId = item?.SkillId
                    }
                   );
                }
                BI_Context.BiRawEngineeringSkillsCertifications.AddRange(ListBiRawEngineeringSkillsCertification);
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
