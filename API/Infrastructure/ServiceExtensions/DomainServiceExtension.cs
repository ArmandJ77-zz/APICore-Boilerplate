using Domain.Infrastructure;
using Domain.Infrastructure.CustomExceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace API.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {

            var domainAssembly = AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "Domain");

            if (domainAssembly == null) 
                throw new NotFoundException("Unable to get loaded Domain Assembly for ser service registration");

            var transientImplementationClasses = domainAssembly.DefinedTypes.Where(
                type => type.ImplementedInterfaces.Any(
                    inter => inter == typeof(ITransientService)))
                .ToList();


            transientImplementationClasses?.ForEach(c =>
            {
                var i = c.ImplementedInterfaces.FirstOrDefault(z => z.Name == $"I{c.Name}");
                var foo = c.GetType();
                var bar = i.GetType();
                
                services.AddTransient(foo, bar);
            });
            
            //services.AddTransient<IExecutionPlan, ExecutionPlan>();
            //services.AddTransient<IGenericFindByIdHandler, GenericFindByIdHandler>();
            //services.AddTransient<IGenericGetListHandler, GenericGetListHandler>();
            //services.AddTransient<IGenericGetPageListHandler, GenericGetPageListHandler>();
            //services.AddTransient<IGenericCreateHandler, GenericCreateHandler>();
            //services.AddTransient<IGenericDeleteHandler, GenericDeleteHandler>();
            //services.AddTransient<IGenericUpdateHandler, GenericUpdateHandler>();


            //services.AddTransient<IValidator<CreateBlogDto>, CreateBlogDtoValidator>();

            return services;
        }
    }
}
