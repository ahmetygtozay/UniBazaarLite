using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UniBazaarLite.Data;

namespace UniBazaarLite.Filters
{
    public class ValidateEntityExistsFilter : IActionFilter
    {
        private readonly IRepository _repository;

        public ValidateEntityExistsFilter(IRepository repository)
        {
            _repository = repository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is int id)
            {
                var path = context.HttpContext.Request.Path;

                if (path.Value.Contains("items", StringComparison.OrdinalIgnoreCase))
                {
                    var item = _repository.GetListingById(id);
                    if (item == null)
                    {
                        context.Result = new NotFoundResult();
                    }
                }
                else if (path.Value.Contains("events", StringComparison.OrdinalIgnoreCase))
                {
                    var evt = _repository.GetEventById(id);
                    if (evt == null)
                    {
                        context.Result = new NotFoundResult();
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
