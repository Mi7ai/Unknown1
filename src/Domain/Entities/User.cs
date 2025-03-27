using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Name cannot be empty or whitespace.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Surname cannot be empty or whitespace.")]
        public string Surname { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Email cannot be empty or whitespace.")]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Phone cannot be empty or whitespace.")]
        public Phone? Phone { get; set; } = null;

        // Navigation Property
        public ICollection<UserRoute> UserRoutes { get; set; } = new List<UserRoute>();
    }
}
