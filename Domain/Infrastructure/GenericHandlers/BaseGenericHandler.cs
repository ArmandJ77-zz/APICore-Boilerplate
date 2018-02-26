using AutoMapper;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class BaseGenericHandler
    {
        public readonly IUnitOfWork Uow;
        public readonly IMapper Mapper;

        public BaseGenericHandler(IMapper map, IUnitOfWork uow)
        {
            Uow = uow;
            Mapper = map;
        }
    }
}
