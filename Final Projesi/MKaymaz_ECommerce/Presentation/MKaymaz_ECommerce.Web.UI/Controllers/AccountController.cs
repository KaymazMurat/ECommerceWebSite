using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Dtos.Login;
using MKaymaz_ECommerce.Common.Dtos.User;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers;
using MKaymaz_ECommerce.Web.UI.Models.AccountViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IUserApi _userApi;


        public AccountController(IAccountApi accountApi, IMapper mapper, ICartApi cartApi, ICartItemApi cartItemApi, IUserApi userApi)
        {
            _accountApi = accountApi;
            _mapper = mapper;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _userApi = userApi;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = await _accountApi.Login(_mapper.Map<LoginRequestDto>(request));
                if (loginRequest.IsSuccessStatusCode && loginRequest.Content.IsSuccess)
                {
                    UserResponseDto user = loginRequest.Content.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("Id",user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Surname,user.LastName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim("IsAdmin",user.IsAdmin.ToString())
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    var cookieModel = new CookieModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        ImagePath = user.ImageUrl,
                        AcceessToken = user.AcceessToken
                    };

                    HttpContext.Response.Cookies.Append("MKaymaz_ECommerceAccessToken", JsonConvert.SerializeObject(cookieModel).Encrypt());
                    await HttpContext.SignInAsync(principal);

                    if (HttpContext.Request.Cookies.ContainsKey("MKaymaz_ECommerceSession"))
                    {
                        var cookieStr = HttpContext.Request.Cookies["MKaymaz_ECommerceSession"].Decrypt();
                        var sessionId = JsonConvert.DeserializeObject<Guid>(cookieStr);

                        var existingCart = await _cartApi.GetCartsBySession(sessionId);

                        if (existingCart.IsSuccessStatusCode && existingCart.Content.IsSuccess)
                        {
                            var activeCart = existingCart.Content.ResultData.FirstOrDefault();
                            var existingCartUser = await _cartApi.GetCartsByQuery(user.Id);
                            if (existingCartUser.IsSuccessStatusCode && existingCartUser.Content.IsSuccess)
                            {
                                var activeCartUser = existingCartUser.Content.ResultData.FirstOrDefault();
                                foreach (var item in activeCart.Cartİtems)
                                {
                                    CartItemRequestDto cartItem = new CartItemRequestDto { CartId = activeCartUser.Id, ProductId = item.ProductId, Quantity = item.Quantity };
                                    var cartItemRequest = await _cartItemApi.Post(cartItem);
                                }

                                CartRequestDto putRequest = new CartRequestDto
                                {
                                    Id = activeCart.Id,
                                    Locked = "locked",
                                    SessionId = sessionId,
                                    Status = activeCart.Status,
                                    UserId = user.Id
                                };
                                await _cartApi.Put(activeCart.Id, putRequest);

                            }
                            else
                            {
                                CartRequestDto putRequest = new CartRequestDto
                                {
                                    Id = activeCart.Id,
                                    Locked = activeCart.Locked,
                                    SessionId = sessionId,
                                    Status = activeCart.Status,
                                    UserId = user.Id
                                };
                                await _cartApi.Put(activeCart.Id, putRequest);
                            }
                        }
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("Hata", "Böyle bir kullanıcı bulunmamaktadır.");
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            if (ModelState.IsValid)
            {
                var existsUser = await _userApi.ExistsUser(request.Email);

                if (existsUser.IsSuccessStatusCode &&
                   existsUser.Content.IsSuccess &&
                   existsUser?.Content?.ResultData != null && existsUser.Content.ResultData)
                {
                    ModelState.AddModelError("Hata", "Bu Email Kullanılmaktadır....");
                    return View();
                }


                UserRequestDto item = new UserRequestDto
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.SurName,
                    Password = request.Password,
                };
                var insertResult = await _userApi.Post(item);
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("Hata", "İşlem Tamamlanamadı....");

                return View();


            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("MKaymaz_ECommerceAccessToken");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
