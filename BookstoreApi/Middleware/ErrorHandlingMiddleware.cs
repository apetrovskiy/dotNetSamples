using System.Net;
using BookstoreApi.Middleware.Exceptions;
using Newtonsoft.Json;

namespace BookstoreApi.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
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
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An error occured while processing your request.";
        if (ex is BookstoreException)
        {
            statusCode = HttpStatusCode.NotFound;
            message = ex.Message;
        }
        var result = JsonConvert.SerializeObject(new { error = message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}
