using System.Collections.Generic;
using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;

namespace Store.Data.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void AddRange(ICollection<Product> products);
    }
}
