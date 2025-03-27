using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Phone
    {
        public int PhoneId { get; set; }
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "Phone number cannot be null, empty, or whitespace.")]
        public string Number { get; set; } = string.Empty;
    }
}
