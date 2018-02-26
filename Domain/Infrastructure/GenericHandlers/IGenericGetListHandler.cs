using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Infrastructure.GenericHandlers
{
    public interface IGenericGetListHandler
    {
        Task<List<TDto>> ExecuteAsync<TDto, TRepository>()
            where TRepository : class
            where TDto : BaseDto;
    }
}
