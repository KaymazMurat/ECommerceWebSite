using MKaymaz_ECommerce.Common.Dtos.Town;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ITownApi
    {
        [Get("/town")]
        Task<ApiResponse<WebApiResponse<List<TownResponseDto>>>> List();

        [Get("/town/{id}")]
        Task<ApiResponse<WebApiResponse<TownResponseDto>>> Get(Guid id);

        [Post("/town")]
        Task<ApiResponse<WebApiResponse<TownResponseDto>>> Post(TownRequestDto request);

        [Put("/town/{id}")]
        Task<ApiResponse<WebApiResponse<TownResponseDto>>> Put(Guid id, TownRequestDto request);

        [Delete("/town/{id}")]
        Task<ApiResponse<WebApiResponse<TownResponseDto>>> Delete(Guid id);

        [Get("/town/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/town/getactive")]
        Task<ApiResponse<WebApiResponse<List<TownResponseDto>>>> GetActive();

        [Get("/town/GetByLocationId/{id}")]
        Task<ApiResponse<WebApiResponse<List<TownResponseDto>>>> GetByLocationId(Guid id);
    }
}
