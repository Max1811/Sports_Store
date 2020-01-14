using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repository.Interfaces
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Order GetOrderByUserId(Guid userId);
    }
}
