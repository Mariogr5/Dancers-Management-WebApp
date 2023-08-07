using ptt_api.Exceptions;

namespace ptt_api.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                context.Response.WriteAsync(notFoundException.Message);
            }
        }
    }
}
