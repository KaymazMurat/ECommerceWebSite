﻿using MKaymaz_ECommerce.Common.Dtos.OrderItem;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderItemApi
    {
        [Get("/orderItem")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> List();

        [Get("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Get(Guid id);

        [Post("/orderItem")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Post(OrderItemRequestDto request);

        [Put("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Put(Guid id, OrderItemRequestDto request);

        [Delete("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Delete(Guid id);

        [Get("/orderItem/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderItem/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> GetActive();
    }
}
