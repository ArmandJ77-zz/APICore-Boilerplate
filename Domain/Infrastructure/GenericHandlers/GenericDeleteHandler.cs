using AutoMapper;
using Domain.Infrastructure.CustomExceptions;
using System.Threading.Tasks;
using Domain.Infrastructure.BaseHandlers;
using UnitOfWork;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericDeleteHandler : BaseHandler, IGenericDeleteHandler, ITransientService
    {
        public GenericDeleteHandler(IMapper map, IUnitOfWork uow) : base(map, uow)
        {
        }

        public async Task<long> ExecuteAsync<TDto, TRepository>(long id) 
            where TDto : BaseDto 
            where TRepository : class
            => await Task.Run(() =>
            {
                var repo = Uow.GetRepository<TRepository>().Find(id);

                if (repo == null)
                    throw new NotFoundException();

                Uow.GetRepository<TRepository>().Delete(repo);
                Uow.SaveChanges();

                return id;
            });
    }
}
