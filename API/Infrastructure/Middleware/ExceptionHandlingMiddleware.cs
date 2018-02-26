using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Infrastructure.CustomExceptions;

namespace API.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext ctx, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = ex.Message;

            if (ex is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                message = "Unable to find requested resource";
            }

            if (ex is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
                message = "Unauthorised";
            }

            if (ex is DomainCustomException)
            {
                code = HttpStatusCode.InternalServerError;
                if (ex.InnerException != null) message = ex.InnerException.ToString();
            }

            //log exception to logger

            var result = JsonConvert.SerializeObject(new { error = message });
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = (int)code;
            return ctx.Response.WriteAsync(result);
        }
    }
}
