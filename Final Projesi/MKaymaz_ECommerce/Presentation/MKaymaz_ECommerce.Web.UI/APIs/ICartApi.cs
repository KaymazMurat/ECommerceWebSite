using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{

    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartApi
    {
        [Get("/cart")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> List();

        [Get("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Get(Guid id);

        [Get("/cart/query/{userId}")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetCartsByQuery(Guid userId);

        [Get("/cart/session/{sessionId}")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetCartsBySession(Guid sessionId);

        [Post("/cart")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Post(CartRequestDto request);

        [Put("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Put(Guid id, CartRequestDto request);

        [Delete("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Delete(Guid id);

        [Get("/cart/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/cart/query/active/{userId}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> GetActiveCart(Guid userId);

        [Get("/cart/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetActive();
    }
}
