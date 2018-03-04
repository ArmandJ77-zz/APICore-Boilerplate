using API.Infrastructure.PlanExecute;
using Domain.Blogs.DTO;
using Domain.Blogs.Validation;
using Domain.Infrastructure.GenericHandlers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {
            services.AddTransient<IExecutionPlan, ExecutionPlan>();

            services.AddTransient<IGenericFindByIdHandler, GenericFindByIdHandler>();
            services.AddTransient<IGenericGetListHandler, GenericGetList>();
            services.AddTransient<IGenericGetPageList, GenericGetPageList>();
            services.AddTransient<IGenericCreateHandler, GenericCreateHandler>();
            services.AddTransient<IGenericDeleteHandler, GenericDeleteHandler>();
            services.AddTransient<IGenericUpdateHandler, GenericUpdateHandler>();


            services.AddTransient<IValidator<CreateBlogDto>, CreateBlogDtoValidator>();

            return services;
        }
    }
}
