using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UniBazaarLite.Data;
using UniBazaarLite.Models;
using UniBazaarLite.Services; // CurrentUser i�in using

namespace UniBazaarLite.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly CurrentUser _currentUser;

        public CreateModel(IRepository repository, CurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        [BindProperty]
        public EventInputModel Input { get; set; } = new();

        // Sayfa eri�imi kontrol� (sim�le edilmi� authentication)
        public IActionResult OnGet()
        {
            if (!_currentUser.IsAuthenticated)
            {
                // Giri� yap�lmam��sa ana sayfaya y�nlendir
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!_currentUser.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }

            if (!ModelState.IsValid)
                return Page();

            var newEvent = new Event
            {
                // Id atamas� repository.AddEvent i�inde otomatik artt�r�lmal�
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
