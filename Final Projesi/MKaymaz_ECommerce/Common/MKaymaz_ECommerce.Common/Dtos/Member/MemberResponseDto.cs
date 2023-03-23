using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Dtos.CurrentAccount;
using MKaymaz_ECommerce.Common.Dtos.FavouritedProduct;
using MKaymaz_ECommerce.Common.Dtos.Location;
using MKaymaz_ECommerce.Common.Dtos.Order;
using MKaymaz_ECommerce.Common.Dtos.ProductComment;
using MKaymaz_ECommerce.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Common.Dtos.Member
{
    public class MemberResponseDto :BaseDto
    {
        public MemberResponseDto()
        {
            CurrentAccounts=new HashSet<CurrentAccountResponseDto>();

            FavouritedProducts= new HashSet<FavouritedProductResponseDto>();

            Orders=new HashSet<OrderResponseDto>();

            ProductComments=new HashSet<ProductCommentResponseDto>();
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string OtherLocation { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string TcId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string ZipCode { get; set; }
        public string CommericalName { get; set; }
        public string TaxOffice { get; set; }
        public Decimal? GainedPointAmount { get; set; }
        public Decimal? SpentPointAmount { get; set; }
        public bool? AllowedToCampaigns { get; set; }
        public string District { get; set; }
        public string DeviceType { get; set; }
        public string DeviceInfo { get; set; }
        public Guid CountryId { get; set; }
        public Guid LocationId { get; set; }

        public CountryResponseDto Country { get; set; }
        public LocationResponseDto Location { get; set; }

        public ICollection<CurrentAccountResponseDto> CurrentAccounts { get; set; }
        public ICollection<FavouritedProductResponseDto> FavouritedProducts { get; set; }
        public ICollection<OrderResponseDto> Orders { get; set; }
        public ICollection<ProductCommentResponseDto> ProductComments { get; set; }
    }
}
