using MKaymaz_ECommerce.Common.Dtos.ProductPrice;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IProductPriceApi
    {
        [Get("/productPrice")]
        Task<ApiResponse<WebApiResponse<List<ProductPriceResponseDto>>>> List();

        [Get("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Get(Guid id);

        [Post("/productPrice")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Post(ProductPriceRequestDto request);

        [Put("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Put(Guid id, ProductPriceRequestDto request);

        [Delete("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Delete(Guid id);

        [Get("/productPrice/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productPrice/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductPriceResponseDto>>>> GetActive();
    }
}
