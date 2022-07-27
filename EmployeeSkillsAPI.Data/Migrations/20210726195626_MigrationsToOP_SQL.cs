using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeSkillsAPI.Data.Migrations
{
    public partial class MigrationsToOP_SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.Functions",
                columns: table => new
                {
                    FuncId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FuncDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_FuncId", x => x.FuncId);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.Service", x => x.ServiceId);
                },
                comment: "Afiniti defined Services");

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    skillname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    otherSkill = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, defaultValueSql: "'y'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.SkillType",
                columns: table => new
                {
                    SkillTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.SkillType", x => x.SkillTypeID);
                },
                comment: " ");

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.EmployeeData",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    dateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    empEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    CareerStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    empUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    serviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_Empid", x => x.empid);
                    table.ForeignKey(
                        name: "serviceid_fk",
                        column: x => x.serviceId,
                        principalTable: "bi_raw_engineering_skills.Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "contains employee data	");

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.Certification",
                columns: table => new
                {
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, defaultValueSql: "'y'"),
                    skillId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.Certification", x => x.CertificationId);
                    table.ForeignKey(
                        name: "fk_skillid",
                        column: x => x.skillId,
                        principalTable: "bi_raw_engineering_skills.Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.SkillMapping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillId = table.Column<int>(type: "int", nullable: true),
                    skilltypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.SkillMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_skillid_mapping",
                        column: x => x.skillId,
                        principalTable: "bi_raw_engineering_skills.Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_skilltypeID_mapping",
                        column: x => x.skilltypeId,
                        principalTable: "bi_raw_engineering_skills.SkillType",
                        principalColumn: "SkillTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.SkillTypeFunction",
                columns: table => new
                {
                    stFuncId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skilltypeId = table.Column<int>(type: "int", nullable: true),
                    funcId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_StFuncId", x => x.stFuncId);
                    table.ForeignKey(
                        name: "function_st_FK",
                        column: x => x.funcId,
                        principalTable: "bi_raw_engineering_skills.Functions",
                        principalColumn: "FuncId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "skilltype-st_FK",
                        column: x => x.skilltypeId,
                        principalTable: "bi_raw_engineering_skills.SkillType",
                        principalColumn: "SkillTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.EmployeeFunction",
                columns: table => new
                {
                    empFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empid = table.Column<int>(type: "int", nullable: true),
                    funcid = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, defaultValueSql: "'y'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.EmployeeFunction", x => x.empFunctionId);
                    table.ForeignKey(
                        name: "emp_function_FK",
                        column: x => x.empid,
                        principalTable: "bi_raw_engineering_skills.EmployeeData",
                        principalColumn: "empid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "funtions_FK",
                        column: x => x.funcid,
                        principalTable: "bi_raw_engineering_skills.Functions",
                        principalColumn: "FuncId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.EmployeeSkill",
                columns: table => new
                {
                    empSkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empid = table.Column<int>(type: "int", nullable: true),
                    skillid = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "'1'"),
                    skilltypeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.EmployeeSkill", x => x.empSkillID);
                    table.ForeignKey(
                        name: "empidFK",
                        column: x => x.empid,
                        principalTable: "bi_raw_engineering_skills.EmployeeData",
                        principalColumn: "empid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "skillidfk",
                        column: x => x.skillid,
                        principalTable: "bi_raw_engineering_skills.Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "sktypeidfk",
                        column: x => x.skilltypeid,
                        principalTable: "bi_raw_engineering_skills.SkillType",
                        principalColumn: "SkillTypeID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "				");

            migrationBuilder.CreateTable(
                name: "bi_raw_engineering_skills.EmployeeCertification",
                columns: table => new
                {
                    empCertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empid = table.Column<int>(type: "int", nullable: true),
                    certificationid = table.Column<int>(type: "int", nullable: true),
                    dateCreation = table.Column<DateTime>(type: "datetime", nullable: true, comment: "record entry date"),
                    cert_Validity = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'2021-01-01'", comment: "Valid Till"),
                    Other = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi_raw_engineering_skills.EmployeeCertification", x => x.empCertificationId);
                    table.ForeignKey(
                        name: "fk_certid",
                        column: x => x.certificationid,
                        principalTable: "bi_raw_engineering_skills.Certification",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_empid",
                        column: x => x.empid,
                        principalTable: "bi_raw_engineering_skills.EmployeeData",
                        principalColumn: "empid",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "		");

            migrationBuilder.CreateIndex(
                name: "fk_skillid_idx",
                table: "bi_raw_engineering_skills.Certification",
                column: "skillId");

            migrationBuilder.CreateIndex(
                name: "fk_certid_idx",
                table: "bi_raw_engineering_skills.EmployeeCertification",
                column: "certificationid");

            migrationBuilder.CreateIndex(
                name: "fk_empid_idx",
                table: "bi_raw_engineering_skills.EmployeeCertification",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "empUserName_UNIQUE",
                table: "bi_raw_engineering_skills.EmployeeData",
                column: "empUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "serviceid_fk_idx",
                table: "bi_raw_engineering_skills.EmployeeData",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "emp_function_FK_idx",
                table: "bi_raw_engineering_skills.EmployeeFunction",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "funtions_FK_idx",
                table: "bi_raw_engineering_skills.EmployeeFunction",
                column: "funcid");

            migrationBuilder.CreateIndex(
                name: "empidFK_idx",
                table: "bi_raw_engineering_skills.EmployeeSkill",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "ix_skillid",
                table: "bi_raw_engineering_skills.EmployeeSkill",
                column: "skillid");

            migrationBuilder.CreateIndex(
                name: "sktypeidfk_idx",
                table: "bi_raw_engineering_skills.EmployeeSkill",
                column: "skilltypeid");

            migrationBuilder.CreateIndex(
                name: "skillname_UNIQUE",
                table: "bi_raw_engineering_skills.Skill",
                column: "skillname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_skillid_idx",
                table: "bi_raw_engineering_skills.SkillMapping",
                column: "skillId");

            migrationBuilder.CreateIndex(
                name: "fk_skilltypeID_idx",
                table: "bi_raw_engineering_skills.SkillMapping",
                column: "skilltypeId");

            migrationBuilder.CreateIndex(
                name: "function_st_FK_idx",
                table: "bi_raw_engineering_skills.SkillTypeFunction",
                column: "funcId");

            migrationBuilder.CreateIndex(
                name: "skilltype-st_FK_idx",
                table: "bi_raw_engineering_skills.SkillTypeFunction",
                column: "skilltypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.EmployeeCertification");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.EmployeeFunction");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.EmployeeSkill");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.SkillMapping");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.SkillTypeFunction");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.Certification");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.EmployeeData");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.Functions");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.SkillType");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.Skill");

            migrationBuilder.DropTable(
                name: "bi_raw_engineering_skills.Service");
        }
    }
}
