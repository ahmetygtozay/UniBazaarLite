using System.ComponentModel.DataAnnotations;

namespace UniBazaarLite.Models
{
    public class Listing
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required]
        [Range(0.01, 1000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public string? SellerEmail { get; set; }
    }
}
