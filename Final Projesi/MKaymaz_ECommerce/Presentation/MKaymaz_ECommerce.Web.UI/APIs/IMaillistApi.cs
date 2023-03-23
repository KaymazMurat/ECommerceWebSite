using MKaymaz_ECommerce.Common.Dtos.Maillist;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IMaillistApi
    {
        [Get("/maillist")]
        Task<ApiResponse<WebApiResponse<List<MaillistResponseDto>>>> List();

        [Get("/maillist/{id}")]
        Task<ApiResponse<WebApiResponse<MaillistResponseDto>>> Get(Guid id);

        [Post("/maillist")]
        Task<ApiResponse<WebApiResponse<MaillistResponseDto>>> Post(MaillistRequestDto request);

        [Put("/maillist/{id}")]
        Task<ApiResponse<WebApiResponse<MaillistResponseDto>>> Put(Guid id, MaillistRequestDto request);

        [Delete("/maillist/{id}")]
        Task<ApiResponse<WebApiResponse<MaillistResponseDto>>> Delete(Guid id);

        [Get("/maillist/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/maillist/getactive")]
        Task<ApiResponse<WebApiResponse<List<MaillistResponseDto>>>> GetActive();
    }
}
