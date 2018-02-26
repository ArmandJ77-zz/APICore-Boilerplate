using System.Net;

namespace Domain.Infrastructure.Responses
{
    public class ResponseResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }
}
