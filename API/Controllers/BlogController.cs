using API.Infrastructure.PlanExecute;
using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Infrastructure.GenericHandlers;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace API.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(IMapper mapper, IUnitOfWork uow, IExecutionPlan executionPlan) : base(mapper, uow, executionPlan)
        {
        }

        #region Generic Endpoints
        [HttpGet]
        [Route("/blogs/{id}")]
        public async Task<BlogDto> Get([FromRoute]long id, [FromServices] IGenericFindByIdHandler handler)
            => await ExecutionPlan.Execute<BlogDto>(
                handler.ExecuteAsync<BlogDto, Blog>, id);

        [HttpGet]
        [Route("/blogs/pagedlist")]
        public async Task<IPagedList<BlogDto>> PagedList([FromQuery] int pageSize, [FromQuery] int pageIndex, [FromServices] IGenericGetPageListHandler handler)
            => await ExecutionPlan.Execute<IPagedList<BlogDto>>(
                handler.ExecuteAsync<BlogDto, Blog>, pageSize, pageIndex);

        [HttpGet]
        [Route("/blogs/list")]
        public async Task<List<BlogDto>> List([FromServices] IGenericGetListHandler handler)
            => await ExecutionPlan.Execute<List<BlogDto>>(
                handler.ExecuteAsync<BlogDto, Blog>);

        [HttpPost]
        [Route("/blogs")]
        public async Task<long> Create([FromBody] CreateBlogDto createDto, [FromServices] IGenericCreateHandler handler)
            => await ExecutionPlan.Execute(
                handler.ExecuteAsync<CreateBlogDto, Blog>, createDto);

        [HttpDelete]
        [Route("/blogs/{id}")]
        public async Task<long> Delete([FromRoute]long id, [FromServices] IGenericDeleteHandler handler)
            => await handler.ExecuteAsync<BlogDto, Blog>(id);

        [HttpPut]
        [Route("/blogs")]
        public async Task<long> Update([FromBody] BlogDto updateDto, [FromServices] IGenericUpdateHandler handler)
            => await handler.ExecuteAsync<BlogDto, Blog>(updateDto);

        #endregion

        #region Non-Generic Endpoints

        #endregion

    }
}
