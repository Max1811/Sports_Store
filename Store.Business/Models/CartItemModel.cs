using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Business.Models
{
    public class CartItemModel
    {
        public Guid Id { get; protected set; }
        public virtual Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
