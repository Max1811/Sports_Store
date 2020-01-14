using SportsStore.Data.Entities;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Business.Models
{
    public class CartModel
    {
        public string Id { get; set; }

        public User User { get; set; }

        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();
    }
}
