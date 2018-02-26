using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseUpdateHandler<TDto> : BaseHandler
    {
        protected BaseUpdateHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<long> ExecuteAsync(TDto updateDto);
    }
}
