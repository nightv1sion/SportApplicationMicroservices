using System.Net;
using MediatR;
using src.FoodTracker.API.Exceptions;

namespace src.FoodTracker.API.Middlewares
{
    public class MediatorErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public MediatorErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}