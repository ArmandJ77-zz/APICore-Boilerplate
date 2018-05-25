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
        /// <summary>
        /// Returns a blog by Id
        /// </summary>
        /// <param name="id">Unique identifier</param>
        [ProducesResponseType(typeof(BlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("/blogs/{id}")]
        public async Task<BlogDto> Get([FromRoute]long id, [FromServices] IGenericFindByIdHandler handler)
            => await ExecutionPlan.Execute<BlogDto>(
                handler.ExecuteAsync<BlogDto, Blog>, id);

        /// <summary>
        /// Returns a paged list of Blogs
        /// </summary>
        /// <param name="pageSize">Number of pages to include in the result</param>
        /// <param name="pageIndex">The page humber to be retrieved</param>
        [ProducesResponseType(typeof(BlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("/blogs/pagedlist")]
        public async Task<IPagedList<BlogDto>> PagedList([FromQuery] int pageSize, [FromQuery] int pageIndex, [FromServices] IGenericGetPageListHandler handler)
            => await ExecutionPlan.Execute<IPagedList<BlogDto>>(
                handler.ExecuteAsync<BlogDto, Blog>, pageSize, pageIndex);

        /// <summary>
        /// Returns all the blogs's as a list
        /// </summary>
        [ProducesResponseType(typeof(BlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("/blogs/list")]
        public async Task<List<BlogDto>> List([FromServices] IGenericGetListHandler handler)
            => await ExecutionPlan.Execute<List<BlogDto>>(
                handler.ExecuteAsync<BlogDto, Blog>);


        /// <summary>
        /// Update a blog
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1
        ///        "url": "http://asdf.co.za",
        ///        "title": "The detailed life of qwerty and asdf"
        ///     }
        ///
        /// </remarks>
        /// <param name="blogDto">The dto containing the updated data</param>
        [ProducesResponseType(typeof(CreateBlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut]
        [Route("/blogs")]
        public async Task<long> Update([FromBody] BlogDto updateDto, [FromServices] IGenericUpdateHandler handler)
            => await handler.ExecuteAsync<BlogDto, Blog>(updateDto);

        /// <summary>
        /// Returns all the client names with their respective Ids
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "url": "http://qwerty.co.za",
        ///        "Title": "The detailed life of qwerty and asdf"
        ///     }
        ///
        /// </remarks>
        [ProducesResponseType(typeof(CreateBlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("/blogs")]
        public async Task<long> Create([FromBody] CreateBlogDto createDto, [FromServices] IGenericCreateHandler handler)
            => await ExecutionPlan.Execute(
                handler.ExecuteAsync<CreateBlogDto, Blog>, createDto);

        /// <summary>
        /// Delete a blog by unique identifier
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CreateBlogDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete]
        [Route("/blogs/{id}")]
        public async Task<long> Delete([FromRoute]long id, [FromServices] IGenericDeleteHandler handler)
            => await handler.ExecuteAsync<BlogDto, Blog>(id);


        #endregion

        #region Non-Generic Endpoints

        #endregion

    }
}
