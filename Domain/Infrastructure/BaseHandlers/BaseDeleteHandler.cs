using AutoMapper;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseDeleteHandler : BaseHandler
    {
        protected BaseDeleteHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<long> ExecuteAsync(long id);
    }
}
