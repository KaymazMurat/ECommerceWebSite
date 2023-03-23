using MKaymaz_ECommerce.Common.Dtos.FavouritedProduct;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IFavouritedProductApi
    {
        [Get("/favouritedProduct")]
        Task<ApiResponse<WebApiResponse<List<FavouritedProductResponseDto>>>> List();

        [Get("/favouritedProduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponseDto>>> Get(Guid id);

        [Post("/favouritedProduct")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponseDto>>> Post(FavouritedProductRequestDto request);

        [Put("/favouritedProduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponseDto>>> Put(Guid id, FavouritedProductRequestDto request);

        [Delete("/favouritedProduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponseDto>>> Delete(Guid id);

        [Get("/favouritedProduct/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/favouritedProduct/getactive")]
        Task<ApiResponse<WebApiResponse<List<FavouritedProductResponseDto>>>> GetActive();
    }
}
