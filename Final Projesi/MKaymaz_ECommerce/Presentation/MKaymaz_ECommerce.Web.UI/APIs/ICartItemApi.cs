using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{

    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartItemApi
    {
        [Get("/cartItem")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> List();

        [Get("/cartItem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Get(Guid id);

        [Post("/cartItem")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Post(CartItemRequestDto request);

        [Put("/cartItem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Put(Guid id, CartItemRequestDto request);

        [Delete("/cartItem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Delete(Guid id);

        [Get("/cartItem/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/cartItem/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> GetActive();

        [Get("/cartItem/query/{cartId}")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> GetCartItemQuery(Guid cartId);

        [Get("/cartItem/GetByProductId/{id}")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> GetByProductId(Guid id);
    }
}

