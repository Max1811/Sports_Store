using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Data.Entities
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }

        public Product(string name, string description, Guid id, double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = Id;
        }

        public Product(string name, string description, double price, Guid categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
    }
}
