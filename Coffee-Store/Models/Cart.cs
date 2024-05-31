using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Store.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
        public virtual List<CartItem>  CartItems { get; set; }
    }
}
