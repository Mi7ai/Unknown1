using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        [Required]
        public string? StartLocation { get; set; }
        [Required]
        public string? EndLocation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal TotalPrice { get; set; }

        // Navigation Property
        public ICollection<UserRoute> UserRoutes { get; set; } = new List<UserRoute>();
    }
}
