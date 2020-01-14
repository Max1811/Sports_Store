using Microsoft.EntityFrameworkCore;
using Store.Data.ApplicationContext;
using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;
using Store.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.Repository.Repositories
{
    public class CartRepository: GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
            :base(context)
        {
            _context = context;
        }

        public void ChangeQuantity(Guid userId, Guid cartItemId, int count)
        {
            Cart cart = GetCartByUser(userId);
            CartItem item = cart.Items.Where(c => c.Id == cartItemId).FirstOrDefault();
            if (item != null)
            {
                item.Quantity = count;
            }
        }

        public int CountTotalItems(Guid userId)
        {
            return _context.ShoppingCarts.Where(u => u.UserId == userId).FirstOrDefault().Items.Count();
        }

        public double CountTotalPrice(Guid userId)
        {
            var cart = _context.ShoppingCarts.Where(u => u.UserId == userId).FirstOrDefault();

            double total = 0;

            foreach (var item in cart.Items)
            {
                total += item.Quantity * item.Product.Price;
            }

            return total;
        }

        public Cart GetCartByUser(Guid userId)
        {
            var cart = _context.ShoppingCarts.Where(u => u.UserId == userId).Include(x => x.Items).FirstOrDefault();

            return cart;
        }
    }
}
