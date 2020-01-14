using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Data.Entities
{
    [Table("ORDERS")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; protected set; }

        [ForeignKey("UserId")]
        [Required]
        public Guid UserId { get; set; }

        public virtual IList<OrderItem> OrderItems { get; protected set; } = new List<OrderItem>();

        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string HomeAddress { get; set; }
    }
}
