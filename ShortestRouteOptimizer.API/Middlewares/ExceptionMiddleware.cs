using ShortestRouteOptimizer.API.Models;

namespace ShortestRouteOptimizer.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorDetails = new ErrorDetails()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = exception.Message
            };

            //If Custom Exception need be handled to can be done here 

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorDetails.StatusCode;
            return context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
