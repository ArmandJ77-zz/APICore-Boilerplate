using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseCriteriaHandler<TDto, TCriteria> : BaseHandler
    {
        public readonly IUnitOfWork Uow;
        public readonly IMapper Mapper;

        protected BaseCriteriaHandler(IMapper mapper, IUnitOfWork uow) : base(mapper,uow)
        {
        }

        protected internal abstract Task<TDto> ExecuteAsync(TCriteria criteria);
    }
}
