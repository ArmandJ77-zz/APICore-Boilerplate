using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Infrastructure.BaseHandlers;
using Repositories;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace Domain.Blogs.Handlers
{
    public class BlogGetPagedListHandler : BasePagedListHandle<BlogDto>
    {
        public BlogGetPagedListHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public override async Task<IPagedList<BlogDto>> ExecuteAsync(int pageSize, int pageIndex)
            => await Task.Run(() =>
            {
                if (pageSize == 0 && pageIndex == 0)
                    return Mapper.Map<IPagedList<Blog>, PagedList<BlogDto>>(
                        Uow.GetRepository<Blog>().GetPagedList());

                var result = Uow.GetRepository<Blog>().GetPagedList(
                    pageSize: pageSize,
                    pageIndex: pageIndex);

                var response = Mapper.Map<IPagedList<Blog>, PagedList<BlogDto>>(result);

                return response;
            });
    }
}
