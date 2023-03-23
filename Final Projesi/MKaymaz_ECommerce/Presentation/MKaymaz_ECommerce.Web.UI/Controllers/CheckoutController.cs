using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.Order;
using MKaymaz_ECommerce.Common.Dtos.OrderItem;
using MKaymaz_ECommerce.Common.Dtos.ShippingAddres;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CreateCartItemViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ShippingAddressViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly IOrderApi _orderApi;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IShippingAddressApi _shippingAddressApi;
        private readonly IMapper _mapper;

        public CheckoutController(ICartApi cartApi, ICartItemApi cartItemApi, IOrderApi ordertApi, IShippingAddressApi shippingAddressApi, IMapper mapper)
        {
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _orderApi = ordertApi;
            _shippingAddressApi = shippingAddressApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // Diğer kısımlarada uygulanacak....
            if (User != null && User.Claims != null && User.Claims.Any(x => x.Type == "Id"))
            {

                var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var activeCart = await _cartApi.GetActiveCart(userId);
                var cartItems = new List<CartItemViewModel>();
                if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
                {
                    var cart = activeCart.Content.ResultData;
                    var cartItemsResult = await _cartItemApi.GetCartItemQuery(cart.Id);
                    if (cartItemsResult.IsSuccessStatusCode && cartItemsResult.Content.IsSuccess)
                    {
                        cartItems = cartItemsResult.Content.ResultData.Select(x => new CartItemViewModel
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
                    }
                }
                ShippingAddresViewModel model = new ShippingAddresViewModel
                {
                    CartItems = cartItems
                };
                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Create(ShippingAddresViewModel model)
        {
            if (User != null && User.Claims != null && User.Claims.Any(x => x.Type == "Id"))
            {
                var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var activeCart = await _cartApi.GetActiveCart(userId);
                if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
                {
                    var cart = activeCart.Content.ResultData;
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

                        ShippingAddresRequestDto shippRequest = new ShippingAddresRequestDto
                        {
                            Address = model.Address,
                            Country = model.Country,
                            Firstname = model.FirstName,
                            Surname = model.SurName,
                            Location = model.Location,
                            SubLocation = model.SubLocation,
                            PhoneNumber = model.PhoneNumber,
                            MobilePhoneNumber = model.MobilePhoneNumber

                        };
                        var shippAddrResult = await _shippingAddressApi.Post(shippRequest);
                        if (shippAddrResult.IsSuccessStatusCode && shippAddrResult.Content.IsSuccess)
                        {
                            var newShippAddr = shippAddrResult.Content.ResultData;

                            var orderItems = new List<OrderItemRequestDto>();
                            foreach (var item in cartItems)
                            {
                                orderItems.Add(new OrderItemRequestDto
                                {
                                    ProductQuantity = item.Quantity,
                                    ProductBarcode = item.Product.Barcode,
                                    ProductName = item.Product.Name,
                                    ProductSku = "",
                                    ProductPrice = item.Product.Price1,
                                    ProductCurrency = "",
                                    ProductTax = 0,
                                    ProductDiscount = 0,
                                    ProductWeight = 0,
                                    ProductStockTypeLabel = "",
                                    Discount = 0,
                                    ProductId = item.ProductId
                                });
                            };

                            OrderRequestDto orderRequest = new OrderRequestDto
                            {
                                Amount = cartItems.Sum(x => x.Product.Price1),
                                Currency = "USD",
                                UserId = userId,
                                ShippingAddresId = newShippAddr.Id,
                                OrderItems = orderItems,
                                CustomerFirstname = model.FirstName,
                                CustomerSurname = model.SurName,
                                CustomerEmail = ""
                            };


                            var orderResult = await _orderApi.Post(orderRequest);
                            if (orderResult.IsSuccessStatusCode && orderResult.Content.IsSuccess)
                            {
                                var newOrder = orderResult.Content.ResultData;
                                cart.Locked = "Ok";
                                CartRequestDto cartRequest = new CartRequestDto
                                {
                                    Id = cart.Id,
                                    Locked = cart.Locked,
                                    SessionId = cart.SessionId,
                                    Status = cart.Status,
                                    UserId = cart.UserId
                                };
                                await _cartApi.Put(cart.Id, cartRequest);
                            }
                        }

                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
