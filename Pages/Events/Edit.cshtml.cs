using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly IRepository _repository;

        public EditModel(IRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public EventInputModel Input { get; set; }

        public IActionResult OnGet(int id)
        {
            var evt = _repository.GetEventById(id);
            if (evt == null)
                return NotFound();

            Input = new EventInputModel
            {
                Id = evt.Id,
                Title = evt.Title,
                Description = evt.Description,
                Date = evt.Date
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var updatedEvent = new Event
            {
                Id = Input.Id,
                Title = Input.Title,
                Description = Input.Description,
                Date = Input.Date
            };

            _repository.UpdateEvent(updatedEvent);

            return RedirectToPage("Index");
        }

        public class EventInputModel
        {
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public string Description { get; set; }

            [DataType(DataType.Date)]
            public DateTime Date { get; set; }
        }
    }
}
