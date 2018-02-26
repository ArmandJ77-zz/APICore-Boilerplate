using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public abstract class BaseListHandler<TDto> : BaseHandler
    {
        protected BaseListHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public abstract Task<List<TDto>> ExecuteAsync();
    }
}
