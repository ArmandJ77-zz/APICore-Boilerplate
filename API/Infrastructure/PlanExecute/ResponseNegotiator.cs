using System.Threading.Tasks;
using Domain.Infrastructure.CustomExceptions;
using Domain.Infrastructure.Responses;

namespace API.Infrastructure.PlanExecute
{
    public class ResponseNegotiator : IResponseNegotiator
    {
        public async Task<ResponseResult> JsonResponseAsync(dynamic handlerResult)
            => (handlerResult == null) ?
                throw new NotFoundException("The requested resource could not be found") :
                await Task.Run(() => new ResponseBuilder()
                    .BuildQueryByIdResponse(handlerResult));
    }
}
