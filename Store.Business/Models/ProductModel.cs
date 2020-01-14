using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Business.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public ProductModel()
        {
                
        }
        public ProductModel(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
