using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericCreateHandler : BaseHandler, IGenericCreateHandler, ITransientService
    {
        public GenericCreateHandler(IMapper map, IUnitOfWork uow) : base(map,uow)
        {
        }

        public async Task<long> ExecuteAsync<TDto, TRepository>(TDto dto) 
            where TDto : BaseDto 
            where TRepository : class
            => await Task.Run(() =>
            {
                var repo = Mapper.Map<TDto, TRepository>(dto);

                Uow.GetRepository<TRepository>().Insert(repo);
                Uow.SaveChanges();

                var result = Mapper.Map<TRepository, TDto>(repo);
                return result.Id;
            });
    }
}
