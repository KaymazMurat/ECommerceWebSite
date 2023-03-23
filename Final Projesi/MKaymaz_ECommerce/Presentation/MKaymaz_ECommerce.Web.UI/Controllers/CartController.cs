using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.CartItem;
using MKaymaz_ECommerce.Common.Extensions;
using MKaymaz_ECommerce.Common.Models;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Views.Product;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        public CartController(ICartApi cartApi, ICartItemApi cartItemApi)
        {
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
        }
        public async Task<IActionResult> Index()
        {

            Guid? sessionId = null;
            Guid? userId = null;
            ApiResponse<WebApiResponse<List<CartResponseDto>>> existingCart = new ApiResponse<WebApiResponse<List<CartResponseDto>>>(
                new System.Net.Http.HttpResponseMessage(), new WebApiResponse<List<CartResponseDto>>(), new RefitSettings());

            if (User != null && User.Claims != null && User.Claims.Any(x => x.Type == "Id"))
            {
                userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                existingCart = await _cartApi.GetCartsByQuery(userId.Value);
            }
            else
            {
                if (HttpContext.Request.Cookies.ContainsKey("MKaymaz_ECommerceSession"))
                {
                    var cookieStr = HttpContext.Request.Cookies["MKaymaz_ECommerceSession"].Decrypt();
                    sessionId = JsonConvert.DeserializeObject<Guid>(cookieStr);
                }
                else
                {
                    sessionId = Guid.NewGuid();
                    HttpContext.Response.Cookies.Append("MKaymaz_ECommerceSession", JsonConvert.SerializeObject(sessionId).Encrypt());

                }
                existingCart = await _cartApi.GetCartsBySession(sessionId.Value);
            }

            if (existingCart.IsSuccessStatusCode && existingCart.Content.IsSuccess)
            {
                var cart = existingCart.Content.ResultData.FirstOrDefault();
                var cartItemsResult = await _cartItemApi.GetCartItemQuery(cart.Id);
                if (cartItemsResult.IsSuccessStatusCode && cartItemsResult.Content.IsSuccess)
                {
                    var cartItems = cartItemsResult.Content.ResultData.Select(x => new CartItemViewModel
                    {
                        Id = x.Id,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Product = new ProductViewModel
                        {
                            Name = x.Product.Name,
                            Barcode = x.Product.Barcode,
                            FullName = x.Product.FullName,
                            Price1 = x.Product.Price1,
                        }
                    }).ToList();
                    return View(cartItems);

                }
            }

            return View(new List<CartItemViewModel>());
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductViewModel item)
        {
            Guid? sessionId = null;
            Guid? userId = null;
            ApiResponse<WebApiResponse<List<CartResponseDto>>> existingCart = new ApiResponse<WebApiResponse<List<CartResponseDto>>>(
                new HttpResponseMessage(), new WebApiResponse<List<CartResponseDto>>(), new RefitSettings());

            if (User != null && User.Claims != null && User.Claims.Any(x => x.Type == "Id"))
            {
                userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                existingCart = await _cartApi.GetCartsByQuery(userId.Value);
            }
            else
            {
                if (HttpContext.Request.Cookies.ContainsKey("MKaymaz_ECommerceSession"))
                {
                    var cookieStr = HttpContext.Request.Cookies["MKaymaz_ECommerceSession"].Decrypt();
                    sessionId = JsonConvert.DeserializeObject<Guid>(cookieStr);
                }
                else
                {
                    sessionId = Guid.NewGuid();
                    HttpContext.Response.Cookies.Append("MKaymaz_ECommerceSession", JsonConvert.SerializeObject(sessionId).Encrypt());

                }
                existingCart = await _cartApi.GetCartsBySession(sessionId.Value);
            }

            if (existingCart.IsSuccessStatusCode)
            {
                var existingCartData = existingCart.Content.ResultData;
                if (!existingCart.Content.IsSuccess || existingCartData == null || existingCartData.Count == 0)
                {

                    CartRequestDto cart = new CartRequestDto { UserId = userId, SessionId = sessionId, Locked = "" };
                    var cartRequest = await _cartApi.Post(cart);
                    if (cartRequest.IsSuccessStatusCode && cartRequest.Content.IsSuccess)
                    {
                        var cartResponseDto = cartRequest.Content.ResultData;

                        CartItemRequestDto cartItem = new CartItemRequestDto { CartId = cartResponseDto.Id, ProductId = item.Id, Quantity = 1 };
                        var cartItemRequest = await _cartItemApi.Post(cartItem);
                    }
                }
                else
                {
                    var existingCartItem = existingCartData.FirstOrDefault().Cartİtems.FirstOrDefault(x => x.ProductId == item.Id && x.Status!= Common.Enums.Status.Deleted);
                    if (existingCartItem != null)
                    {
                        await _cartItemApi.Put(existingCartItem.Id, new CartItemRequestDto
                        {
                            CartId = existingCartItem.CartId,
                            ProductId = item.Id,
                            Quantity = existingCartItem.Quantity + 1,
                            CategoryId = existingCartItem.CategoryId,
                            Id = existingCartItem.Id,
                            Status = existingCartItem.Status,
                            ParentProductId = existingCartItem.ParentProductId,
                        });
                    }
                    else
                    {
                        CartItemRequestDto cartItem = new CartItemRequestDto { CartId = existingCartData.FirstOrDefault().Id, ProductId = item.Id, Quantity = 1 };
                        var cartItemRequest = await _cartItemApi.Post(cartItem);
                    }

                }

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityViewModel item)
        {
            var existingCartItemResult = await _cartItemApi.Get(item.CartItemId);

            if (existingCartItemResult.IsSuccessStatusCode)
            {
                var existingCartItem = existingCartItemResult.Content.ResultData;
                if (existingCartItemResult.Content.IsSuccess && existingCartItem != null)
                {
                    var Quantity = existingCartItem.Quantity + item.Quantity;
                    try
                    {
                        if (Quantity <= 0)
                        {
                            await _cartItemApi.Delete(item.CartItemId);
                        }
                        else if (existingCartItem != null)
                        {
                            await _cartItemApi.Put(existingCartItem.Id, new CartItemRequestDto
                            {
                                CartId = existingCartItem.CartId,
                                ProductId = existingCartItem.ProductId,
                                Quantity = (int)Quantity,
                                CategoryId = existingCartItem.CategoryId,
                                Id = existingCartItem.Id,
                                Status = existingCartItem.Status,
                                ParentProductId = existingCartItem.ParentProductId,
                            });
                        }
                    }
                    catch (Exception)
                    {

                        return Json(new { success = false }); ;
                    }

                }

            }
            return Json(new { success = true });//Anonim oldu
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _cartItemApi.Delete(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess)
            {
                var cartResponseDto = result.Content.ResultData;

            }
            return RedirectToAction("Index", "Cart");
        }
    }

}

