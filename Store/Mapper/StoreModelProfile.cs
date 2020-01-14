using AutoMapper;
using SportsStore.Data.Entities;
using Store.Business.Models;
using Store.Data.Entities;

namespace Store.Mapper
{
    public class StoreModelProfile : Profile
    {
        public StoreModelProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<Cart, CartModel>();
            CreateMap<CartItem, CartItemModel>();
        } 
    }
}
