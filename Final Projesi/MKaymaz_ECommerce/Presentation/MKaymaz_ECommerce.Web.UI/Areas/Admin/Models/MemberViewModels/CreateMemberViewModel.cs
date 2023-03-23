using MKaymaz_ECommerce.Common.Enums;
using System;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.MemberViewModels
{
    public class CreateMemberViewModel
    {
        public Status Status { get; set; }
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
    }
}
