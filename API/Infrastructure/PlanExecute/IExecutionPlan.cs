using Domain.Infrastructure;
using System;
using System.Threading.Tasks;

namespace API.Infrastructure.PlanExecute
{
    public interface IExecutionPlan
    {
        Task<THandlerResult> Execute<THandlerResult>(Func<Task<THandlerResult>> handlerFunc);
        Task<long> Execute<TDto>(Func<TDto, Task<long>> handlerFunc, TDto dto) where TDto : BaseDto;
        Task<THandlerResult> Execute<THandlerResult>(Func<long, Task<THandlerResult>> handlerFunc, long id);
        Task<THandlerResult> Execute<THandlerResult>(Func<int, int, Task<THandlerResult>> handlerFunc, int pageSize, int pageIndex);
        Task<THandlerResult> Execute<THandlerResult>(Func<string, Task<THandlerResult>> handlerFunc, string queryTerm);
        Task<THandlerResult> Execute<TCriteria, THandlerResult>(Func<TCriteria, Task<THandlerResult>> handlerFunc,
            TCriteria criteria);
    }
}