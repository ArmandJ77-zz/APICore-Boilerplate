using API.Infrastructure.PlanExecute;
using AutoMapper;
using Domain.Infrastructure.GenericHandlers;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork Uow { get; }
        public IExecutionPlan ExecutionPlan { get; }
        public IMapper Map { get; }

        public IGenericFindByIdHandler GenericFindByIdHandler { get; }
        public IGenericGetListHandler GenericGetListHandler{ get; }
        public IGenericGetPageListHandler GenericGetPageListHandler { get; }
        public IGenericCreateHandler GenericCreateHandler { get; }
        public IGenericDeleteHandler GenericDeleteHandler { get; }
        public IGenericUpdateHandler GenericUpdateHandler { get; set; }

        public BaseController(IMapper mapper,
            IUnitOfWork uow,
            IExecutionPlan executionPlan,
            IGenericFindByIdHandler genericFindByIdHandler,
            IGenericGetListHandler genericGetListHandler,
            IGenericGetPageListHandler genericGetPageListHandler,
            IGenericCreateHandler genericCreateHandler,
            IGenericDeleteHandler genericDeleteHandler,
            IGenericUpdateHandler genericUpdateHandler)
        {
            Map = mapper;
            Uow = uow;
            ExecutionPlan = executionPlan;
            GenericFindByIdHandler = genericFindByIdHandler;
            GenericGetListHandler = genericGetListHandler;
            GenericGetPageListHandler = genericGetPageListHandler;
            GenericCreateHandler = genericCreateHandler;
            GenericDeleteHandler = genericDeleteHandler;
            GenericUpdateHandler = genericUpdateHandler;
        }
    }
}
