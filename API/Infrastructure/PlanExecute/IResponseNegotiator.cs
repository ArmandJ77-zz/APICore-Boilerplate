using System.Threading.Tasks;
using Domain.Infrastructure.Responses;

namespace API.Infrastructure.PlanExecute
{
    public interface IResponseNegotiator
    {
        Task<ResponseResult> JsonResponseAsync(dynamic handlerResult);
    }
}
