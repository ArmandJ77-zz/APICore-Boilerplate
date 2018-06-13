using AutoMapper;
using Domain.Infrastructure.BaseHandlers;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.PagedList;

namespace Domain.Infrastructure.GenericHandlers
{
    public class GenericGetPageListHandler : BaseHandler, IGenericGetPageListHandler, ITransientService
    {
        public GenericGetPageListHandler(IMapper map, IUnitOfWork uow) : base(map,uow)
        {
        }

        public async Task<IPagedList<TDto>> ExecuteAsync<TDto, TRepository>(int pageSize, int pageIndex) 
            where TDto : BaseDto 
            where TRepository : class
            => await Task.Run(() =>
            {
                if (pageSize == 0 && pageIndex == 0)
                    return Mapper.Map<IPagedList<TRepository>, PagedList<TDto>>(
                        Uow.GetRepository<TRepository>().GetPagedList());

                var result = Uow.GetRepository<TRepository>().GetPagedList(
                    pageSize: pageSize,
                    pageIndex: pageIndex);

                var response = Mapper.Map<IPagedList<TRepository>, PagedList<TDto>>(result);

                return response;
            });
    }
}
