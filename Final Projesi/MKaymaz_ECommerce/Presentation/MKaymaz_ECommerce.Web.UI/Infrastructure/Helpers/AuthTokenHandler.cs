using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Web.UI.APIs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountApi _accountApi;

        public AuthTokenHandler(
            IHttpContextAccessor httpContextAccessor,
            IAccountApi accountApi)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountApi = accountApi;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("MKaymaz_ECommerceAccessToken"))
            {
                var cookieStr = _httpContextAccessor.HttpContext.Request.Cookies["MKaymaz_ECommerceAccessToken"].Decrypt();
                var cookieModel = JsonConvert.DeserializeObject<CookieModel>(cookieStr);
                if (cookieModel.AcceessToken.Expires <= DateTime.Now.ToUnixTime())
                {
                    var getAccessTokenResult = await _accountApi.RefreshToken(new RefreshToken
                    {
                        Email = cookieModel.Email,
                        Refresh_Token = cookieModel.AcceessToken.RefreshToken
                    });
                    if (getAccessTokenResult.IsSuccessStatusCode && getAccessTokenResult.Content.IsSuccess)
                    {
                        var getAccessToken = getAccessTokenResult.Content.ResultData;
                        var claims = new List<Claim>()
                        {
                            new Claim("Id",cookieModel.Id.ToString()),
                            new Claim(ClaimTypes.Name,cookieModel.FirstName),
                            new Claim(ClaimTypes.Surname,cookieModel.LastName),
                            new Claim(ClaimTypes.Email,cookieModel.Email),
                            new Claim("Image",cookieModel.ImagePath)
                        };

                        var userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        cookieModel.AcceessToken = getAccessToken;

                        _httpContextAccessor.HttpContext.Response.Cookies.Append("MKaymaz_ECommerceAccessToken", JsonConvert.SerializeObject(cookieModel).Encrypt());
                        await _httpContextAccessor.HttpContext.SignInAsync(principal);

                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", cookieModel.AcceessToken.AccessToken);
                    }
                }
                else
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", cookieModel.AcceessToken.AccessToken);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
