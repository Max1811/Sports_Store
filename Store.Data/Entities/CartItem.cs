using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Data.Entities
{
    [Table("SHOPPING_CART_ITEM")]
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }

        [Required]
        [ForeignKey("ProductId")]
        public virtual Guid ProductId { get; set; }
        public  Product Product { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
