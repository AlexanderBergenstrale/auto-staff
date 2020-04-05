using HMW.Core.Config;
using HMW.Core.Interfaces;
using HMW.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HMW.Api
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
            // getting config from Configuration file.
            // using UserSecrets to store db connection string
            // ie, in secrets.json add a row like this "DbConfig:ConnectionString" : "<value>"
            var dbConfig = Configuration.GetSection("DbConfig").Get<DbConfig>();
            services.AddControllers();

            services.AddScoped<IDbConfig>((services) =>
            {
                return dbConfig;
            });

            services.AddScoped<IOrganizationRepo, OrganizationRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IHealthReportRepo, HealthReportRepo>();


            //swagger
            services.AddSwaggerGen((opt) =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AutoStaff.Api", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // swagger
            app.UseSwagger();
            app.UseSwaggerUI((opt) =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoStaff Api v1");
                opt.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
