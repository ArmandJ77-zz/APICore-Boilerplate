using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BasePagedListCriteriaHandler<TDto, TCriteria> : BaseHandler
    {
        public readonly IUnitOfWork Uow;
        public readonly IMapper Mapper;

        protected BasePagedListCriteriaHandler(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public abstract Task<IPagedList<TDto>> ExecuteAsync(TCriteria criteria);
    }
}
