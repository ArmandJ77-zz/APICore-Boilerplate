using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseFindByIdHandler<TDto> : BaseHandler
    {
        protected BaseFindByIdHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<TDto> ExecuteAsync(int id);
    }
}
