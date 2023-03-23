using MKaymaz_ECommerce.Common.Dtos.OrderDetail;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderDetailApi
    {
        [Get("/orderDetail")]
        Task<ApiResponse<WebApiResponse<List<OrderDetailResponseDto>>>> List();

        [Get("/orderDetail/{id}")]
        Task<ApiResponse<WebApiResponse<OrderDetailResponseDto>>> Get(Guid id);

        [Post("/orderDetail")]
        Task<ApiResponse<WebApiResponse<OrderDetailResponseDto>>> Post(OrderDetailRequestDto request);

        [Put("/orderDetail/{id}")]
        Task<ApiResponse<WebApiResponse<OrderDetailResponseDto>>> Put(Guid id, OrderDetailRequestDto request);

        [Delete("/orderDetail/{id}")]
        Task<ApiResponse<WebApiResponse<OrderDetailResponseDto>>> Delete(Guid id);

        [Get("/orderDetail/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderDetail/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderDetailResponseDto>>>> GetActive();
    }
}
