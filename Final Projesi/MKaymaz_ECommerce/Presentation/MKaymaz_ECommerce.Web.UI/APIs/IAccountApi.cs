using MKaymaz_ECommerce.Common.Dtos.Login;
using MKaymaz_ECommerce.Common.Dtos.User;
using MKaymaz_ECommerce.Common.Models;
using Refit;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IAccountApi
    {
        [Get("/account")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Login(LoginRequestDto request);

        [Get("/account/refreshtoken")]
        Task<ApiResponse<WebApiResponse<GetAcceessTokenDto>>> RefreshToken(RefreshToken request);
    }
}
