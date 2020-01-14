using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Entities;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.ApplicationContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
