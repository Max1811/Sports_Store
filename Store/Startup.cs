using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStore.Data.Entities;
using Store.Data.ApplicationContext;
using Store.Data.Repository.EFGenericRepository;
using AutoMapper;
using Store.Data.Repository.Interfaces;
using Store.Data.Repository.Repositories;
using Store.Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Store.Data.Entities;

namespace Store
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            string connection = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlServer(connection)
            );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/log-in");
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            var mapperCOnfiguration = new MapperConfiguration(cfg => cfg.AddProfile<StoreModelProfile>());
            mapperCOnfiguration.CompileMappings();

            

            services.AddSingleton(mapperCOnfiguration);
            services.AddSingleton(mapperCOnfiguration.CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseMvc(routes =>
            {
            routes.MapRoute (
                name: "pagination",
                template: "products/page{page}",
                defaults: new { Controller = "Product", action = "List" });

            routes.MapRoute(
                name: "default",
                template: " { controller = Product}/{action=List}/{id?}");
            });

            
            app.UseStaticFiles();

            app.UseAuthentication();    
            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
