using EmployeeSkillsAPI.Data.DWH_Entities;
using EmployeeSkillsAPI.Data.ESM_Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeeSkillsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //It is being used to migrate DB tables to DWH(SQL Server)
            EmployeeSkillsContext.ESM_ConfigURL = Configuration.GetSection("ConnectionStrings");
            //It is being used to migrate DB tables to DWH(SQL Server)
            DWH_OP_SQL_Context.OP_SQLDB_URL = Configuration.GetSection("ConnectionStrings");
            //It is being used to migrate DB tables to DWH(SQL Server)
            EmployeeSkillsMigrationContext.MigrationURLForDWH = Configuration.GetSection("ConnectionStrings");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeSkillsAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeSkillsAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
