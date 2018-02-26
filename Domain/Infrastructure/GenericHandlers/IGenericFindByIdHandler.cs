using System.Threading.Tasks;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericFindByIdHandler
    {
        Task<TDto> ExecuteAsync<TDto, TRepository>(long id)
            where TRepository : class
            where TDto : BaseDto;
    }
}
