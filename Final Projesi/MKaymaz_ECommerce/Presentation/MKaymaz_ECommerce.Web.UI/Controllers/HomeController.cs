using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Common.Dtos.Product;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductApi _productApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;
        private readonly IProductImageApi _productImageApi;

        public HomeController(
            IUserApi userApi,
            IMapper mapper,
            IProductApi productApi, IProductImageApi productImageApi)
        {
            _userApi = userApi;
            _mapper = mapper;
            _productApi=productApi;
            _productImageApi=productImageApi;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
            {
                List<ProductResponseDto> listData = listResult.Content.ResultData
                    .OrderByDescending(x => x.ViewCount)    
                    .Take(12)
                    .ToList();
                list = _mapper.Map<List<ProductViewModel>>(listData);
            }
            return View(list);
        }

        public async Task<IActionResult> Posts(Guid id)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetByCategoryId(id);
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        public async Task<IActionResult> Brands(Guid id)
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetByBrandId(id);
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        public async Task<IActionResult> Post(Guid id)
        {
            var getProductResult = await _productApi.ProductDetail(id);
            if (getProductResult.IsSuccessStatusCode && getProductResult.Content.IsSuccess && getProductResult.Content.ResultData != null)
            {
                ProductViewModel updateProduct = _mapper.Map<ProductViewModel>(getProductResult.Content.ResultData);
                var getUserResult = await _userApi.Get(updateProduct.UserId);
                if (getUserResult.IsSuccessStatusCode && getUserResult.Content.IsSuccess && getUserResult.Content.ResultData != null)
                {
                    UserViewModel userViewModel = _mapper.Map<UserViewModel>(getUserResult.Content.ResultData);
                    return View(updateProduct);
                }
            }
            return View();

        }

        public async Task<IActionResult> PostsProductImage(Guid id)
        {
            List<ProductImageViewModel> list = new List<ProductImageViewModel>();
            var listResult = await _productImageApi.GetByProductId(id);
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductImageViewModel>>(listResult.Content.ResultData);
            return View(list);
        }
    }
}
 