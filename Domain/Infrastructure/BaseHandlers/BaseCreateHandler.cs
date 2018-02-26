using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseCreateHandler<TDto> : BaseHandler
    {
        protected BaseCreateHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<long> ExecuteAsync(TDto creationDto);
    }
}
