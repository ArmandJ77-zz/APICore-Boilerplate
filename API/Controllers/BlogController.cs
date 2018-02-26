using System.Collections.Generic;
using API.Infrastructure.PlanExecute;
using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Blogs.Handlers;
using Domain.Infrastructure.GenericHandlers;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BlogController : BaseController
    {
        public BlogController(IMapper mapper,
            IUnitOfWork uow,
            IExecutionPlan executionPlan,
            IGenericFindByIdHandler genericFindByIdHandler,
            IGenericGetListHandler genericGetListHandler,
            IGenericGetPageList genericGetPageListHandler,
            IGenericCreateHandler genericCreateHandler,
            IGenericDeleteHandler genericDeleteHandler,
            IGenericUpdateHandler genericUpdateHandler)
            : base(mapper,
                uow,
                executionPlan,
                genericFindByIdHandler,
                genericGetListHandler,
                genericGetPageListHandler,
                genericCreateHandler,
                genericDeleteHandler,
                genericUpdateHandler)
        {
        }

        #region Generic Endpoints
        [HttpGet]
        public async Task<BlogDto> Get(long id)
            => await ExecutionPlan.Execute<BlogDto>(
                GenericFindByIdHandler.ExecuteAsync<BlogDto, Blog>, id);

        [HttpGet]
        public async Task<IPagedList<BlogDto>> PagedList(int pageSize, int pageIndex)
            => await ExecutionPlan.Execute<IPagedList<BlogDto>>(
                GenericGetPageListHandler.ExecuteAsync<BlogDto, Blog>, pageSize, pageIndex);

        [HttpGet]
        public async Task<List<BlogDto>> List()
            => await ExecutionPlan.Execute<List<BlogDto>>(
                GenericGetListHandler.ExecuteAsync<BlogDto, Blog>);

        [HttpPost]
        public async Task<long> Create([FromBody] BlogDto createDto)
            => await ExecutionPlan.Execute(
                GenericCreateHandler.ExecuteAsync<BlogDto, Blog>, createDto);

        [HttpDelete]
        public async Task<long> Delete(long id)
            => await GenericDeleteHandler.ExecuteAsync<BlogDto, Blog>(id);

        [HttpPut]
        public async Task<long> Update([FromBody] BlogDto updateDto)
            => await GenericUpdateHandler.ExecuteAsync<BlogDto, Blog>(updateDto); //.Execute(new BlogUpdateHandler(Map, Uow).ExecuteAsync, UpdateDto);

        #endregion

        #region Non-Generic Endpoints

        //[HttpPut]
        //public async Task<long> Update([FromBody] BlogDto UpdateDto)
        //    => await ExecutionPlan.Execute(new BlogUpdateHandler(Map, Uow).ExecuteAsync, UpdateDto);

        #endregion

    }
}
