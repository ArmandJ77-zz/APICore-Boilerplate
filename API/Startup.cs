using System;
using System.Collections.Generic;
using System.IO;
using API.Infrastructure.ActionFilters;
using API.Infrastructure.Middleware;
using API.Infrastructure.ServiceExtensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Repositories.Context;
using Serilog;
using System.Linq;
using System.Reflection;
using Domain.Blogs.Validation;
using FluentValidation.Validators;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using UnitOfWork;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.IsEnvironment("Testing"))
                services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("TestDB"))
                    .AddUnitOfWork<DatabaseContext>();
            else
                //UseRowNumberForPaging to support older SQL versions which does not support SQL FETCH 
                services.AddDbContext<DatabaseContext>(
                        option => option.UseSqlServer(Configuration.GetConnectionString("Database"),
                            opt => opt.UseRowNumberForPaging()))
                    .AddUnitOfWork<DatabaseContext>();

            services.AddDomain();
            services.AddAutoMapperConfiguration(GetType().GetTypeInfo().Assembly.GetReferencedAssemblies().Select(c => Assembly.Load(c)).ToArray());
            services.AddCors();
            services.AddMvc()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Boilerplate API", Version = "v1" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Api.xml");
                c.IncludeXmlComments(filePath);
                //c.SchemaFilter<FluentValidationRules>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseDatabaseErrorPage();
            }

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseStaticFiles();

            app.UseCors(options => options.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UsePathBase("/api");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Base}/{action=Index}/{id?}");
            });

            app.UseSwagger(c => { c.RouteTemplate = "api-docs/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Boilerplate API");
                c.RoutePrefix = "docs";
            });
        }
    }

    internal class FluentValidationRules : ISchemaFilter
    {
        //TODO impliment a generic fuentvalidate search funciton
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var validator = new CreateBlogDtoValidator(); //Your fluent validator class

            model.Required = new List<string>();
            
            var validatorDescriptor = validator.CreateDescriptor();

            foreach (var key in model.Properties.Keys)
            {
                foreach (var validatorType in validatorDescriptor.GetValidatorsForMember(key))
                {
                    if (validatorType is NotEmptyValidator)
                    {
                        model.Required.Add(key);
                    }
                }
            }
        }
    }
}
