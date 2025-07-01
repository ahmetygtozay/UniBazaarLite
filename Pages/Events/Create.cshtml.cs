using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _repository;

        public CreateModel(IRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public EventInputModel Input { get; set; } = new();

        public void OnGet()
        {
            // Sayfa ilk açýldýðýnda yapýlacak bir þey yok
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var newEvent = new Event
            {
                Id = _repository.GetNextEventId(),
                Title = Input.Title,
                Description = Input.Description,
                Date = Input.Date,
                RegisteredUsers = new List<string>()
            };

            _repository.AddEvent(newEvent);

            TempData["Message"] = "Event created successfully.";
            return RedirectToPage("Index");
        }
    }

    public class EventInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title max 100 characters.")]
        public string Title { get; set; } = "";

        [Required]
        [StringLength(1000, ErrorMessage = "Description max 1000 characters.")]
        public string Description { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
