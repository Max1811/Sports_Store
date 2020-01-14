using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Data.ApplicationContext;
using Store.Data.InicializationData;
using System;
using System.Linq;

namespace Store.DataInitializer
{
    public static class InitializePrimaryData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Users.Any())
                {
                    UsersData usersData = new UsersData();
                    context.AddRange(usersData.users);
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    CategoriesData category = new CategoriesData();
                    context.AddRange(category.categories);
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    ProductsData productsData = new ProductsData();
                    context.AddRange(productsData.products);
                    context.SaveChanges();
                }
            }
        }
    }
}
