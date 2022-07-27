using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace EmployeeSkillsAPI.Data.DWH_Entities
{
    public partial class DWH_OP_SQL_Context : DbContext
    {
        public static IConfiguration OP_SQLDB_URL { get; set; }
        public DWH_OP_SQL_Context()
        {
        }

        public DWH_OP_SQL_Context(DbContextOptions<DWH_OP_SQL_Context> options)
            : base(options)
        {
        }
        public virtual DbSet<BiRawEngineeringSkillsCertification> BiRawEngineeringSkillsCertifications { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsEmployeeCertification> BiRawEngineeringSkillsEmployeeCertifications { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsEmployeeDatum> BiRawEngineeringSkillsEmployeeData { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsEmployeeFunction> BiRawEngineeringSkillsEmployeeFunctions { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsEmployeeSkill> BiRawEngineeringSkillsEmployeeSkills { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsFunction> BiRawEngineeringSkillsFunctions { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsService> BiRawEngineeringSkillsServices { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsSkill> BiRawEngineeringSkillsSkills { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsSkillMapping> BiRawEngineeringSkillsSkillMappings { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsSkillType> BiRawEngineeringSkillsSkillTypes { get; set; }
        public virtual DbSet<BiRawEngineeringSkillsSkillTypeFunction> BiRawEngineeringSkillsSkillTypeFunctions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string BI_DWH_DBConnection = OP_SQLDB_URL.GetSection("OP_SQL_SERVER").Value;
            if (!optionsBuilder.IsConfigured)
            {
                //SQL-Server is used to push data and for migrations of DB entities in BI DWH-DB via CODE-FIRST APPROACH
                optionsBuilder.UseSqlServer(BI_DWH_DBConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BiRawEngineeringSkillsCertification>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Certification");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SkillId).HasColumnName("skillId");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsEmployeeCertification>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeCertification");

                entity.Property(e => e.CertValidity)
                    .HasColumnType("date")
                    .HasColumnName("cert_Validity");

                entity.Property(e => e.Certificationid).HasColumnName("certificationid");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.EmpCertificationId).HasColumnName("empCertificationId");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Other).HasMaxLength(200);
            });

            modelBuilder.Entity<BiRawEngineeringSkillsEmployeeDatum>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeData");

                entity.Property(e => e.CareerStartDate).HasColumnType("date");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(300)
                    .HasColumnName("empEmail");

                entity.Property(e => e.EmpEmployeeId).HasColumnName("empEmployeeId");

                entity.Property(e => e.EmpUserName)
                    .HasMaxLength(50)
                    .HasColumnName("empUserName");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Password).HasMaxLength(300);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.UniqueCode).HasMaxLength(100);
            });

            modelBuilder.Entity<BiRawEngineeringSkillsEmployeeFunction>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeFunction");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.EmpFunctionId).HasColumnName("empFunctionId");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Funcid).HasColumnName("funcid");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsEmployeeSkill>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeSkill");

                entity.Property(e => e.EmpSkillId).HasColumnName("empSkillID");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Skillid).HasColumnName("skillid");

                entity.Property(e => e.Skilltypeid).HasColumnName("skilltypeid");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsFunction>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Functions");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.FuncDescription).HasMaxLength(200);

                entity.Property(e => e.FuncName).HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsService>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Service");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ServiceName).HasMaxLength(150);
            });

            modelBuilder.Entity<BiRawEngineeringSkillsSkill>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Skill");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.OtherSkill)
                    .HasMaxLength(200)
                    .HasColumnName("otherSkill");

                entity.Property(e => e.Skillname)
                    .HasMaxLength(100)
                    .HasColumnName("skillname");

                entity.Property(e => e.Status).HasMaxLength(1);
            });

            modelBuilder.Entity<BiRawEngineeringSkillsSkillMapping>(entity =>
            {
                entity.HasKey(e => e.SkillMappingId);

                entity.ToTable("bi_raw_engineering_skills.SkillMapping");

                entity.Property(e => e.SkillId).HasColumnName("skillId");

                entity.Property(e => e.SkilltypeId).HasColumnName("skilltypeId");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsSkillType>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.SkillType");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");
            });

            modelBuilder.Entity<BiRawEngineeringSkillsSkillTypeFunction>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.SkillTypeFunction");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.FuncId).HasColumnName("funcId");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive");

                entity.Property(e => e.SkilltypeId).HasColumnName("skilltypeId");

                entity.Property(e => e.StFuncId).HasColumnName("stFuncId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
