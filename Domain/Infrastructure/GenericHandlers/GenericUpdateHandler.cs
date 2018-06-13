using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using Domain.Infrastructure.CustomExceptions;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericUpdateHandler : BaseHandler, IGenericUpdateHandler, ITransientService
    {
        public GenericUpdateHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public async Task<long> ExecuteAsync<TDto, TRepository>(TDto dto)
            where TDto : BaseDto
            where TRepository : class
            => await Task.Run(() =>
            {
                var repo = Uow.GetRepository<TRepository>().Find(dto.Id);

                if (repo == null)
                    throw new NotFoundException();

                var updateDto = Mapper.Map<TDto,TRepository>(dto);
                Uow.GetRepository<TRepository>().Update(updateDto);
                Uow.SaveChanges();

                return dto.Id;
            });
    }
}
