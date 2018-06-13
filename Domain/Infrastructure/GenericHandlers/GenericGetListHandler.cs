using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericGetListHandler : BaseHandler, IGenericGetListHandler, ITransientService
    {
        public GenericGetListHandler(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public async Task<List<TDto>> ExecuteAsync<TDto, TRepository>() where TDto : BaseDto where TRepository : class
                => await Task.Run(() => 
                Mapper.Map<IList<TRepository>, List<TDto>>
                (Uow.GetRepository<TRepository>().GetList()));
    }
}
