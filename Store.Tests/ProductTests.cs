using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Moq;
using Store.Controllers;
using Store.Data.ApplicationContext;
using Store.Data.Entities;
using Store.Data.Repository.Interfaces;
using Xunit;

namespace Store.Tests
{
    public class ProductTests
    {

        [Fact]
        public void Can_Add_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();

            Product product = new Product("Bike", "Good bike", 199);

            ProductController controller = new ProductController(mock.Object, mapperMock.Object);

            Product result = controller.AddProduct(product);

            Assert.True(result != null);
        }
    }
}
