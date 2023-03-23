using MKaymaz_ECommerce.Common.Dtos.Country;
using MKaymaz_ECommerce.Common.Dtos.Location;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ILocationApi
    {
        [Get("/location")]
        Task<ApiResponse<WebApiResponse<List<LocationResponseDto>>>> List();

        [Get("/location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponseDto>>> Get(Guid id);

        [Post("/location")]
        Task<ApiResponse<WebApiResponse<LocationResponseDto>>> Post(LocationRequestDto request);

        [Put("/location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponseDto>>> Put(Guid id, LocationRequestDto request);

        [Delete("/location/{id}")]
        Task<ApiResponse<WebApiResponse<LocationResponseDto>>> Delete(Guid id);

        [Get("/location/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/location/getactive")]
        Task<ApiResponse<WebApiResponse<List<LocationResponseDto>>>> GetActive();

        [Get("/Location/GetByCountryId/{id}")]
        Task<ApiResponse<WebApiResponse<List<LocationResponseDto>>>> GetByCountryId(Guid id);
    }
}
