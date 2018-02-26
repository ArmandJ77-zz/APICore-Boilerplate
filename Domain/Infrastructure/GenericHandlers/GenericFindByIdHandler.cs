using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using Domain.Infrastructure.CustomExceptions;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericFindByIdHandler : BaseHandler, IGenericFindByIdHandler
    {
        public GenericFindByIdHandler(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public async Task<TDto> ExecuteAsync<TDto, TRepository>(long id) where TDto : BaseDto where TRepository : class
                => await Task.Run(() =>
                {
                    var query = Uow.GetRepository<TRepository>().Find(id);

                    if (query == null)
                        throw new NotFoundException();

                    var result = Mapper.Map<TRepository, TDto>(query);

                    return result;
                });
    }
}
