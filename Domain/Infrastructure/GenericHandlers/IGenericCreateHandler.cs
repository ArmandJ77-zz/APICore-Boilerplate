using System.Threading.Tasks;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericCreateHandler
    {
        Task<long> ExecuteAsync<TDto, TRepository>(TDto dto)
            where TRepository : class
            where TDto : BaseDto;
    }
}
