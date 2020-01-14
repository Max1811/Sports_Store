using SportsStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Data.Entities
{
    [Table("SHOPPING_CART")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual Guid UserId { get; set; }

        [ForeignKey("CartId")]
        public virtual List<CartItem> Items { get; protected set; } = new List<CartItem>();
    }
}
