using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Entities;
using Store.Data.Entities;
using Store.Data.Repository.EFGenericRepository;
using Store.Data.Repository.Interfaces;
using Store.Data.Repository.Repositories;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderController(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public Order GetOrderByUser(Guid userId)
        {
            return _orderRepository.GetOrderByUserId(userId);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        private Guid GetUserId()
        {
            return new Guid("099E324F-695B-402E-BAB8-08D79752B010"); //hardcoding user Id instead of authorization
        }
    }
}