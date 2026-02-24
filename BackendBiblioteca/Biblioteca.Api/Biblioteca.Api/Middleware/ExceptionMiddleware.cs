using Biblioteca.BL.Excepciones;
using Biblioteca.BL.Exceptions;
using System.Net;
using System.Text.Json;

namespace Biblioteca.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case AutorNoExisteException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case MaximoLibrosException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case CorreoException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = exception.Message
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(json);
        }
    }
}