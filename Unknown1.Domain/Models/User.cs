using System.ComponentModel.DataAnnotations;

namespace Unknown1.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public Phone? Phone { get; set; }
    }
}
