using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repository.Interfaces
{
    public interface ICartRepository: IGenericRepository<Cart>
    {
        Cart GetCartByUser(Guid userId);
        void ChangeQuantity(Guid userId, Guid cartItemId, int count);
        double CountTotalPrice(Guid userId);
        int CountTotalItems(Guid userId);
    }
}
