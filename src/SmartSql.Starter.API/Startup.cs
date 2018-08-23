using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using SmartSql.Abstractions;
using SmartSql.Starter.API.Filter;
using SmartSql.Starter.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSql.Starter.API
{
    public class Startup
    {
        const string SERVICE_NAME = "SmartSql.Starter.API";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ValidateModelFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
            RegisterRepository(services);
            RegisterService(services);
            RegisterSwagger(services);
        }



        private void RegisterRepository(IServiceCollection services)
        {
            services.AddSmartSqlRepositoryFromAssembly((options) =>
            {
                options.AssemblyString = "SmartSql.Starter.Repository";
            });
        }
        private void RegisterService(IServiceCollection services)
        {
            services.AddSingleton<UserService>();
        }
        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = SERVICE_NAME,
                    Version = "v1",
                    Description = "https://github.com/Ahoo-Wang/SmartSql"
                });
                c.CustomSchemaIds((type) => type.FullName);
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{SERVICE_NAME}.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            ConfigureSwagger(app);
        }
        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {

            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", SERVICE_NAME);
            });
        }
    }
}
