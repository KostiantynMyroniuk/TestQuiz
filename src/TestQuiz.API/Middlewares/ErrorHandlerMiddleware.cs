using TestQuiz.Domain.Exceptions;

namespace TestQuiz.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unhandled exception: {ex.Message}");

                await HandleException(context, ex);
            }
        }

        public async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {

                KeyNotFoundException => StatusCodes.Status404NotFound,

                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                AlreadyExistsException => StatusCodes.Status409Conflict,

                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var message = statusCode == StatusCodes.Status500InternalServerError
                ? "Internal server error. Try again later"
                : exception.Message;

            var result = new
            {
                status = statusCode,
                error = message,
            };

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
