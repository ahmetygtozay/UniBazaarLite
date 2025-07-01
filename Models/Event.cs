using System.ComponentModel.DataAnnotations;

namespace UniBazaarLite.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<string> RegisteredUsers { get; set; } = new();
    }
}
