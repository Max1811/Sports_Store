using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Business.Models;
using Store.Data.Entities;
using Store.Data.Repository.Interfaces;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        //TODO authorization and autentification
        //Need userId to work with
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CartController(IProductRepository productRepository, IUserRepository userRepository, 
            ICartRepository cartRepository, IMapper mapper, ILogger<CartController> logger)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("products/add-to-cart")]
        public IActionResult AddToCart(Guid productId)
        {
            _logger.LogInformation("Starting working with controller");
            Guid userId = GetUserId();

            Cart cart = _cartRepository.GetCartByUser(userId);

            if(cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                _cartRepository.Add(cart);
            }

            Product product = _productRepository.Get(productId);
            if(product == null)
            {
                return NotFound("Product was not found");
            }

            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                item = new CartItem() { ProductId = productId, Quantity = 1 };
                cart.Items.Add(item);
            }

            return Redirect("~/cart");
        }

        [Authorize]
        [HttpGet("/cart")]
        public IActionResult Cart()
        {
            Guid userId = GetUserId();
            Cart cart = _cartRepository.GetCartByUser(userId);
            if (cart == null)
            {
                return View();
            }

            IEnumerable<CartItem> entities = cart.Items;

            IEnumerable<CartItemModel> models = _mapper.Map<IEnumerable<CartItemModel>>(entities);

            return View(models);
        }

        [Authorize]
        [HttpPost("/cart/{cartItemId}/count")]
        public IActionResult ChangeQuantity(Guid cartItemId, int count)
        {
            Guid userId = GetUserId();
            _cartRepository.ChangeQuantity(userId, cartItemId, count);

            return Ok();
        }

        private Guid GetUserId()
        {
            return new Guid("099E324F-695B-402E-BAB8-08D79752B010"); //hardcoding user Id instead of authorization
        }
    }
}
