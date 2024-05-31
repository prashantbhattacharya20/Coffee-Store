using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Store.Models
{
    [Index(nameof(ItemName), IsUnique = true)]

    public class Menu
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]

        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]

        public string Url { get; set; }
    }
}
