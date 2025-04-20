using System.Net;
using System.Text.Json;


namespace Proyecto.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Sigue el pipeline normal
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error inesperado.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode;
            string message;

           
            switch (exception)
            {
                case ArgumentNullException:
                case ArgumentException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Error en la solicitud.";
                    break;
                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "Recurso no encontrado.";
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Se produjo un error inesperado.";
                    break;
            }

            var response = new
            {
                error = message,
                exception = exception.Message 
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
