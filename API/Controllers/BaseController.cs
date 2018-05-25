using API.Infrastructure.PlanExecute;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork Uow { get; }
        public IExecutionPlan ExecutionPlan { get; }
        public IMapper Map { get; }

        public BaseController(IMapper mapper,
                IUnitOfWork uow,
                IExecutionPlan executionPlan)
        {
            Map = mapper;
            Uow = uow;
            ExecutionPlan = executionPlan;
        }

        [HttpGet]
        public string Index()
            => "Api Started";
    }
}
