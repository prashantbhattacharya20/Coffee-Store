using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Store.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }

        [ForeignKey("Menu")]
        public int ItemID { get; set; }

        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
