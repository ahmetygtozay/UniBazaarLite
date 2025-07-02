using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace UniBazaarLite.Filters
{
    // This filter implements IActionFilter to run code before and after MVC actions.
    // Currently, it logs the incoming HTTP request details before the action executes.
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        // Constructor receives an ILogger via dependency injection
        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }

        // This method is called just before the action method executes
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;    // The request URL path
            var method = context.HttpContext.Request.Method; // The HTTP method (GET, POST, etc.)

            // Log the HTTP method and URL path as an informational message
            _logger.LogInformation("Request: {Method} {Path}", method, path);
        }

        // This method is called right after the action method has executed
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // You can add post-action logging or error handling here if needed
        }
    }
}
