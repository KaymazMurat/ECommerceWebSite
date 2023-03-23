using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class CartItemMapperProfile : Profile
    {
        public CartItemMapperProfile()
        {
            CreateMap<CartItem, CartItemRequestDto>() // CartItem İle CartItemRequest arasında
                .ReverseMap() //Tam terside olabilir
                .IgnoreAllNonExisting()// hepsini görmezden gel
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CartItem, CartItemResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
