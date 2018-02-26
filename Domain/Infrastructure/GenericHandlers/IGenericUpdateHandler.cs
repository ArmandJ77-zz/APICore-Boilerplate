using System.Threading.Tasks;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericUpdateHandler
    {
        Task<long> ExecuteAsync<TDto, TRepository>(TDto dto)
            where TDto : BaseDto
            where TRepository : class;
    }
}