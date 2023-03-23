using AutoMapper;
using MKaymaz_ECommerce.Common.Dtos.ProductComment;
using MKaymaz_ECommerce.Common.Dtos.ProductImage;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.API.Infrastructer.Mapper
{
    public class ProductImageMapperProfile : Profile
    {
        public ProductImageMapperProfile()
        {
            CreateMap<ProductImage, ProductImageRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductImage, ProductImageResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

