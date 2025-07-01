using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Pages.Events
{
    public class RegisterModel : PageModel
    {
        private readonly IRepository _repository;

        public RegisterModel(IRepository repository)
        {
            _repository = repository;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Event? Event { get; set; }

        public IActionResult OnGet()
        {
            Event = _repository.GetEventById(Id);
            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var evt = _repository.GetEventById(Id);
            if (evt == null)
            {
                return NotFound();
            }

            evt.RegisteredUsers.Add("testuser@example.com"); // Simüle kullanýcý
            TempData["Message"] = $"You have registered for {evt.Title}";
            return RedirectToPage("Index");
        }
    }
}
