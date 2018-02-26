using System.Net;
using Domain.Infrastructure.Responses;

namespace API.Infrastructure.PlanExecute
{
    public class ResponseBuilder
    {
        public ResponseResult BuildQueryByIdResponse(dynamic handlerResult)
        {
            if (handlerResult == null)
                return new ResponseResult
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Fail - Entity not found",
                    Result = null
                };

            return new ResponseResult
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Successfull",
                Result = handlerResult
            };
        }
    }
}
