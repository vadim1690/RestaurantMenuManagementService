using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantMenuManagementService.Exceptions;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var response = new ApiResponse();

            switch(ex)
            {
                case ResourceNotFoundException NotFoundEx:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = NotFoundEx.Message;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Message = "An internal server error occured. Please try again later.";
                    break;
            }

            response.Success = false;
            if(!ex.Message.IsNullOrEmptyString())
            {
                response.Errors.Add(ex.Message);
            }
            await context.Response.WriteAsync(response.ToJson());
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
