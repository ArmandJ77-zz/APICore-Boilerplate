using System.Threading.Tasks;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericDeleteHandler
    {
        Task<long> ExecuteAsync<TDto, TRepository>(long id)
            where TRepository : class
            where TDto : BaseDto;
    }
}
