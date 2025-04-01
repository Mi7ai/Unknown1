using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserPostPutDto
    {
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
        public string? Phone { get; set; } = string.Empty;
    }
}