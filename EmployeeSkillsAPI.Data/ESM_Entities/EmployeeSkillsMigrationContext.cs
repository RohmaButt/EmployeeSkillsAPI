using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace EmployeeSkillsAPI.Data.ESM_Entities
{
    public partial class EmployeeSkillsMigrationContext : DbContext
    {
        public static IConfiguration MigrationURLForDWH { get; set; }
        public EmployeeSkillsMigrationContext()
        {
        }

        public EmployeeSkillsMigrationContext(DbContextOptions<EmployeeSkillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Empcertification> Empcertifications { get; set; }
        public virtual DbSet<Empdata> Empdata { get; set; }
        public virtual DbSet<Empfunction> Empfunctions { get; set; }
        public virtual DbSet<Empskill> Empskills { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Skillmapping> Skillmappings { get; set; }
        public virtual DbSet<Skilltype> Skilltypes { get; set; }
        public virtual DbSet<Stfunction> Stfunctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string BI_DWH_DBConnection = MigrationURLForDWH.GetSection("OP_SQL_SERVER").Value;
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(BI_DWH_DBConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Certification");

                entity.Property(e => e.CertificationId).ValueGeneratedNever();

                entity.HasIndex(e => e.SkillId, "fk_skillid_idx");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SkillId)
                    .HasColumnName("skillId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'y'");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("fk_skillid");
            });

            modelBuilder.Entity<Empcertification>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeCertification");

                entity.HasComment("		");

                entity.HasIndex(e => e.Certificationid, "fk_certid_idx");

                entity.HasIndex(e => e.Empid, "fk_empid_idx");

                entity.Property(e => e.EmpCertificationId).HasColumnName("empCertificationId");

                entity.Property(e => e.CertValidity)
                    .HasColumnType("date")
                    .HasColumnName("cert_Validity")
                    .HasDefaultValueSql("'2021-01-01'")
                    .HasComment("Valid Till");

                entity.Property(e => e.Certificationid).HasColumnName("certificationid");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation")
                    .HasComment("record entry date");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Other).HasMaxLength(200);

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.Empcertifications)
                    .HasForeignKey(d => d.Certificationid)
                    .HasConstraintName("fk_certid");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Empcertifications)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_empid");
            });

            modelBuilder.Entity<Empdata>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PRIMARY_Empid");

                entity.ToTable("bi_raw_engineering_skills.EmployeeData");

                entity.HasComment("contains employee data	");

                entity.HasIndex(e => e.EmpUserName, "empUserName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ServiceId, "serviceid_fk_idx");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.CareerStartDate).HasColumnType("date");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("empEmail");

                entity.Property(e => e.EmpEmployeeId).HasColumnName("empEmployeeId");

                entity.Property(e => e.EmpUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empUserName");

                entity.Property(e => e.Password).HasMaxLength(300);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.UniqueCode).HasMaxLength(100);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Empdata)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("serviceid_fk");
            });

            modelBuilder.Entity<Empfunction>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeFunction");

                entity.HasIndex(e => e.Empid, "emp_function_FK_idx");

                entity.HasIndex(e => e.Funcid, "funtions_FK_idx");

                entity.Property(e => e.EmpFunctionId).HasColumnName("empFunctionId");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Funcid).HasColumnName("funcid");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("'y'");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Empfunctions)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("emp_function_FK");

                entity.HasOne(d => d.Func)
                    .WithMany(p => p.Empfunctions)
                    .HasForeignKey(d => d.Funcid)
                    .HasConstraintName("funtions_FK");
            });

            modelBuilder.Entity<Empskill>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.EmployeeSkill");

                entity.HasComment("				");

                entity.HasIndex(e => e.Empid, "empidFK_idx");

                entity.HasIndex(e => e.Skillid, "ix_skillid");

                entity.HasIndex(e => e.Skilltypeid, "sktypeidfk_idx");

                entity.Property(e => e.EmpSkillId).HasColumnName("empSkillID");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Skillid).HasColumnName("skillid");

                entity.Property(e => e.Skilltypeid).HasColumnName("skilltypeid");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Empskills)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("empidFK");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Empskills)
                    .HasForeignKey(d => d.Skillid)
                    .HasConstraintName("skillidfk");

                entity.HasOne(d => d.Skilltype)
                    .WithMany(p => p.Empskills)
                    .HasForeignKey(d => d.Skilltypeid)
                    .HasConstraintName("sktypeidfk");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.HasKey(e => e.FuncId)
                    .HasName("PRIMARY_FuncId");

                entity.ToTable("bi_raw_engineering_skills.Functions");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.FuncDescription).HasMaxLength(200);

                entity.Property(e => e.FuncName).HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Service");

                entity.HasComment("Afiniti defined Services");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ServiceName).HasMaxLength(150);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.Skill");

                entity.HasIndex(e => e.Skillname, "skillname_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.SkillId).ValueGeneratedNever();

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
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("skillname");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'y'");
            });

            modelBuilder.Entity<Skillmapping>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.SkillMapping");

                entity.HasIndex(e => e.SkillId, "FK_skillid_idx");

                entity.HasIndex(e => e.SkilltypeId, "fk_skilltypeID_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SkillId).HasColumnName("skillId");

                entity.Property(e => e.SkilltypeId).HasColumnName("skilltypeId");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Skillmappings)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_skillid_mapping");

                entity.HasOne(d => d.Skilltype)
                    .WithMany(p => p.Skillmappings)
                    .HasForeignKey(d => d.SkilltypeId)
                    .HasConstraintName("fk_skilltypeID_mapping");
            });

            modelBuilder.Entity<Skilltype>(entity =>
            {
                entity.ToTable("bi_raw_engineering_skills.SkillType");

                entity.HasComment(" ");

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Stfunction>(entity =>
            {
                entity.HasKey(e => e.StFuncId)
                    .HasName("PRIMARY_StFuncId");

                entity.ToTable("bi_raw_engineering_skills.SkillTypeFunction");

                entity.HasIndex(e => e.FuncId, "function_st_FK_idx");

                entity.HasIndex(e => e.SkilltypeId, "skilltype-st_FK_idx");

                entity.Property(e => e.StFuncId).HasColumnName("stFuncId");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.FuncId).HasColumnName("funcId");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .HasColumnName("isActive");

                entity.Property(e => e.SkilltypeId).HasColumnName("skilltypeId");

                entity.HasOne(d => d.Func)
                    .WithMany(p => p.Stfunctions)
                    .HasForeignKey(d => d.FuncId)
                    .HasConstraintName("function_st_FK");

                entity.HasOne(d => d.Skilltype)
                    .WithMany(p => p.Stfunctions)
                    .HasForeignKey(d => d.SkilltypeId)
                    .HasConstraintName("skilltype-st_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
