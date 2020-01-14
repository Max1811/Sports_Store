using System.Collections.Generic;
using Store.Data.ApplicationContext;
using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;
using Store.Data.Repository.Interfaces;

namespace Store.Data.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
            this._context = context;
        }

        public void AddRange(ICollection<Product> products)
        {
            _context.AddRange(products);    
        }
    }
}
