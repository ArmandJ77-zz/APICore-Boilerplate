using System.Threading.Tasks;
using UnitOfWork.PagedList;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericGetPageList
    {
        Task<IPagedList<TDto>> ExecuteAsync<TDto, TRepository>(int pageSize, int pageIndex)
            where TRepository : class
            where TDto : BaseDto;
    }
}
