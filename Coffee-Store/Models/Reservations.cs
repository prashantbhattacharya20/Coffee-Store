using System.ComponentModel.DataAnnotations;

namespace Coffee_Store.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateOnly ReservationDate { get; set; }

        [Required]
        public TimeOnly ReservationTime { get; set; }

        [Required]
        public int NumberOfPersons { get; set; }

        public string Message { get; set; }


    }
}
