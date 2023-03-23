using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class Member : CoreEntity
    {
        public Member()
        {
            CurrentAccounts=new HashSet<CurrentAccount>();
            FavouritedProducts= new HashSet<FavouritedProduct>();
            ProductComments=new HashSet<ProductComment>();
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
       
        public Country Country { get; set; }
        public Location Location { get; set; }

        public User CreatedUserMember { get; set; }
        public User ModifiedUserMember { get; set; }

        public ICollection<CurrentAccount> CurrentAccounts { get; set; }
        public ICollection<FavouritedProduct> FavouritedProducts { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }

    }
}
