using AutoMapper;
using UnitOfWork;

namespace Domain.Infrastructure.BaseHandlers
{
    public class BaseHandler
    {
        public readonly IUnitOfWork Uow;
        public readonly IMapper Mapper;

        public BaseHandler(IMapper mapper, IUnitOfWork uow)
        {
            Uow = uow;
            Mapper = mapper;
        }
    }
}
