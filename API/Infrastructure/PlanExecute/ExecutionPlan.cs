using Domain.Infrastructure;
using System;
using System.Threading.Tasks;

namespace API.Infrastructure.PlanExecute
{
    public class ExecutionPlan : IExecutionPlan
    {
        //protected internal IResponseNegotiator Negotiate { get; }
        public ExecutionPlan()
        {
        }

        public async Task<THandlerResult> Execute<THandlerResult>(Func<Task<THandlerResult>> handlerFunc)
            => await handlerFunc.Invoke();

        public async Task<long> Execute<TDto>(Func<TDto, Task<long>> handlerFunc, TDto dto) where TDto : BaseDto
            => await handlerFunc.Invoke(dto);

        public async Task<THandlerResult> Execute<THandlerResult>(Func<int, int, Task<THandlerResult>> handlerFunc, int pageSize, int pageIndex)
            => await handlerFunc.Invoke(pageSize, pageIndex);

        public async Task<THandlerResult> Execute<THandlerResult>(Func<long, Task<THandlerResult>> handlerFunc, long id)
            => await handlerFunc.Invoke(id);

        public async Task<THandlerResult> Execute<THandlerResult>(Func<string, Task<THandlerResult>> handlerFunc, string queryTerm)
            => await handlerFunc.Invoke(queryTerm);

        public async Task<THandlerResult> Execute<TCriteria, THandlerResult>(Func<TCriteria, Task<THandlerResult>> handlerFunc, TCriteria criteria)
            => await handlerFunc.Invoke(criteria);
    }
}
