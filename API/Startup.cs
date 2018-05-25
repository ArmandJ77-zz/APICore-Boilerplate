﻿using API.Infrastructure.ActionFilters;
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

            services.AddMvc(opt => opt.Filters.Add(typeof(ValidationActionFilter)))
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMiddleware<SerilogMiddleware>();
            app.UseMvc();

            app.UsePathBase("/api");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Base}/{action=Index}/{id?}");
            });
        }
    }
}
