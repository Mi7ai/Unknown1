using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PhoneDto
    {
        public int PhoneId { get; set; }
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Phone cannot be empty or whitespace.")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public string Number { get; set; } = string.Empty;
    }
}