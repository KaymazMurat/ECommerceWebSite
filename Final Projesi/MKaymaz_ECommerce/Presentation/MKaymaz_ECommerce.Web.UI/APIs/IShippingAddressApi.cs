using MKaymaz_ECommerce.Common.Dtos.ShippingAddres;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IShippingAddressApi
    {
        [Get("/shippingAddress")]
        Task<ApiResponse<WebApiResponse<List<ShippingAddresResponseDto>>>> List();

        [Get("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddresResponseDto>>> Get(Guid id);

        [Post("/shippingAddress")]
        Task<ApiResponse<WebApiResponse<ShippingAddresResponseDto>>> Post(ShippingAddresRequestDto request);

        [Put("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddresResponseDto>>> Put(Guid id, ShippingAddresRequestDto request);

        [Delete("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddresResponseDto>>> Delete(Guid id);

        [Get("/shippingAddress/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/shippingAddress/getactive")]
        Task<ApiResponse<WebApiResponse<List<ShippingAddresResponseDto>>>> GetActive();
    }
}
