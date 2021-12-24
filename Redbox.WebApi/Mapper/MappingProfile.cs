using AutoMapper;
using Redbox.Core.Entities;
using Redbox.ViewModels;

namespace Redbox.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemVM>();
            CreateMap<Cart, CartVM>();
            CreateMap<CartVM, Cart>();
            CreateMap<CartItemVM, CartItem>();
            CreateMap<CartItem, CartItemVM>();
        }
    }
}
