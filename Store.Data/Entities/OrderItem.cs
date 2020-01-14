using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Data.Entities
{
    [Table("ORDER_ITEMS")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; protected set; }

        [Required]
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }

        [Required]
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
