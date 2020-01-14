using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Business.Models;
using Store.Data.Entities;
using Store.Data.Repository.Interfaces;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            IEnumerable<Product> entitiesList = GetAll();
            IEnumerable<ProductModel> productsList = mapper.Map<IEnumerable <ProductModel>>(entitiesList);

            return View("ProductsList", productsList);
        }

        [HttpPost("products")]
        public IActionResult AddProductToList(ProductModel model)
        {
            Product product = mapper.Map<Product>(model);

            Product added = AddProduct(product);

            return Redirect("/products");
        }

        [HttpGet("products/delete/{id}")]
        public IActionResult DeleteProductFromList(Guid id)
        {
            Product product = _productRepository.Get(id);

            Product deleted = DeleteProduct(product);

            return Redirect("/products");
        }

        private IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product DeleteProduct(Product product)
        {
            //try
            //{
                _productRepository.Remove(product);
                return product;
            //}
            //catch
            //{
            //    throw new Exception("");
            //}

        }public Product AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                return product;
            }
            catch
            {
                return null;
            }
        }

        public void AddRange(ICollection<Product> products)
        {
            _productRepository.AddRange(products);
        }
    }
}