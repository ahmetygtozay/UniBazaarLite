using Microsoft.AspNetCore.Mvc.RazorPages;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public List<Event> Events { get; set; } = new();

        public void OnGet()
        {
            Events = _repository.GetEvents();
        }
    }
}
