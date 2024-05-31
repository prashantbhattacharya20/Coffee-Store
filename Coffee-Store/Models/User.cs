using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Store.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]

    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string Username { get; set;}

        public DateOnly DateOfBirth { get; set; }

        public string? Address { get; set; }
    }
}