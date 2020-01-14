using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Data.Entities;
using Store.Data.ApplicationContext;
using Store.Data.Entities;

namespace Store.Data.InicializationData
{
    public class ProductsData
    {
        public List<Product> products = new List<Product>()
        {
            new Product("Bicycle", "Yellow colored mountain bike", 299.99, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Helmet", "Life guard helmet", 20.5, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Horisontal bar", "Swedish wall to workout on", 525, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Bicycle", "Brown colored children's bike", 105, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Sports shirt", "Pretty blue shirt", 35, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Pants", "Elastic pants for the running", 25.49, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Bicycle", "Blue bike for chill riding", 200, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Glasses", "The best glasses agains the sun", 45.49, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Skate", "Budget one of the skates", 33.99, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),
            new Product("Pods", "Pods for the running", 99.99, new Guid("9093FE26-CCF0-4790-35E7-08D799199EF1")),

        };
    }
}
