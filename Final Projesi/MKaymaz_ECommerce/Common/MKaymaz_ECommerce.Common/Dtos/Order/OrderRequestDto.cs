using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.OrderItem;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.Order
{
    public class OrderRequestDto :BaseDto
    {
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentProviderCode { get; set; }
        public string PaymentProviderName { get; set; }
        public string PaymentGatewayCode { get; set; }
        public string PaymentGatewayName { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string Currency { get; set; }
        public string CurrencyRates { get; set; }
        public Decimal? Amount { get; set; }
        public Decimal? CouponDiscount { get; set; }
        public Decimal? TaxAmount { get; set; }
        public Decimal? PromotionDiscount { get; set; }
        public Decimal? GeneralAmount { get; set; }
        public Decimal? ShippingAmount { get; set; }
        public Decimal? AdditionalServiceAmount { get; set; }
        public Decimal? FinalAmount { get; set; }
        public Decimal? SumOfGainedPoints { get; set; }
        public int? Installment { get; set; }
        public Decimal? InstallmentRate { get; set; }
        public int? ExtraInstallment { get; set; }
        public string TransactionId { get; set; }
        public bool? HasUserNote { get; set; }
        public string PaymentStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string DeviceType { get; set; }
        public string Referrer { get; set; }
        public int? InvoicePrintCount { get; set; }
        public string UseGiftPackage { get; set; }
        public string GiftNote { get; set; }
        public string MemberGroupName { get; set; }
        public string UsePromotion { get; set; }
        public string ShippingProviderCode { get; set; }
        public string ShippingProviderName { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingPaymentType { get; set; }
        public string Source { get; set; }

        public Guid MaillistId { get; set; }

        public Guid OrderDetailId { get; set; }

        public Guid OrderItemId { get; set; }

        public Guid UserId { get; set; }

        public Guid ShippingAddresId { get; set; }

        public List<OrderItemRequestDto> OrderItems { get; set; }
        //public ShippingAddres ShippingAddress { get; set; }
    }
}
