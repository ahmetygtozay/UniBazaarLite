using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UniBazaarLite.Data;

namespace UniBazaarLite.Filters
{
    // This filter validates if the requested entity (Item or Event) exists before the action runs.
    // If the entity with the given ID does not exist it returns a 404 Not Found response immediately.
    public class ValidateEntityExistsFilter : IActionFilter
    {
        private readonly IRepository _repository;

        // Constructor receives the repository via dependency injection to access data
        public ValidateEntityExistsFilter(IRepository repository)
        {
            _repository = repository;
        }

        // This method runs before the action executes
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Try to get the "id" argument from the action parameters
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is int id)
            {
                var path = context.HttpContext.Request.Path;

                // Check if the request URL contains "items"
                if (path.Value.Contains("items", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the item with the given id exists in the repository
                    var item = _repository.GetListingById(id);
                    if (item == null)
                    {
                        // If not found short-circuit the pipeline with a 404 NotFound result
                        context.Result = new NotFoundResult();
                    }
                }
                // Check if the request URL contains "events"
                else if (path.Value.Contains("events", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the event with the given id exists in the repository
                    var evt = _repository.GetEventById(id);
                    if (evt == null)
                    {
                        // If not found, return 404 NotFound
                        context.Result = new NotFoundResult();
                    }
                }
            }
            // If "id" parameter is not found or not an int, do nothing here and let action run
        }

        // This method runs after the action executes - no implementation needed here
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
