using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BasePagedListHandle<TDto> : BaseHandler
    {
        protected BasePagedListHandle(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<IPagedList<TDto>> ExecuteAsync(int pageSize, int pageIndex);
    }
}
