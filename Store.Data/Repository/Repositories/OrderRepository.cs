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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Order GetOrderByUserId(Guid userId)
        {
            return _context.Orders.Where(order => order.UserId == userId).FirstOrDefault();
        }
    }
}
