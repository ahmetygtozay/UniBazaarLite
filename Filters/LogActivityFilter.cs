using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace UniBazaarLite.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;
            _logger.LogInformation("Request: {Method} {Path}", method, path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optional: response logu vs. eklenebilir
        }
    }
}
