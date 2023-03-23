using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKaymaz_ECommerce.Common.Dtos.Product;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.BrandViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CategoryViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CurrencyViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductController : Controller
    {
        private readonly IProductApi _productApi;
        private readonly ICategoryApi _categoryApi;
        private readonly IBrandApi _brandApi;
        private readonly ICurrencyApi _currencyApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductController(

            IMapper mapper,
            IWebHostEnvironment env,
            ICategoryApi categoryApi,
            IProductApi productApi,
            IBrandApi brandApi,
            ICurrencyApi currencyApi)
        {
            _mapper = mapper;
            _env = env;
            _categoryApi = categoryApi;
            _productApi=productApi;
            _brandApi=brandApi;
            _currencyApi=currencyApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            ViewBag.Categories = new SelectList(list, "Id", "Name");


            List<BrandViewModel> list1 = new List<BrandViewModel>();
            var listResult1 = await _brandApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<BrandViewModel>>(listResult1.Content.ResultData);
            ViewBag.Brands = new SelectList(list1, "Id", "Name");


            List<CurrencyViewModel> list2 = new List<CurrencyViewModel>();
            var listResult2 = await _currencyApi.List();
            if (listResult2.IsSuccessStatusCode &&
                listResult2.Content.IsSuccess &&
                listResult2.Content.ResultData.Any())
                list2 = _mapper.Map<List<CurrencyViewModel>>(listResult2.Content.ResultData);
            ViewBag.Currencies = new SelectList(list2, "Id", "Label");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductViewModel item, List<IFormFile> files)
        {
            item.UserId = Guid.Parse(User.Claims?.FirstOrDefault(x => x.Type == "Id").Value);
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.Barcode = imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View(item);
                }
                var insertResult = await _productApi.Post(_mapper.Map<ProductRequestDto>(item));
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";


            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            ViewBag.Categories = new SelectList(list, "Id", "Name");

            List<BrandViewModel> list1 = new List<BrandViewModel>();
            var listResult1 = await _brandApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<BrandViewModel>>(listResult1.Content.ResultData);
            ViewBag.Brands = new SelectList(list1, "Id", "Name");

            List<CurrencyViewModel> list2 = new List<CurrencyViewModel>();
            var listResult2 = await _currencyApi.List();
            if (listResult2.IsSuccessStatusCode &&
                listResult2.Content.IsSuccess &&
                listResult2.Content.ResultData.Any())
                list2 = _mapper.Map<List<CurrencyViewModel>>(listResult2.Content.ResultData);
            ViewBag.Currencies = new SelectList(list2, "Id", "Label");

            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            ViewBag.Categories = new SelectList(list, "Id", "Name");

            List<BrandViewModel> list1 = new List<BrandViewModel>();
            var listResult1 = await _brandApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<BrandViewModel>>(listResult1.Content.ResultData);
            ViewBag.Brands = new SelectList(list1, "Id", "Name");

            List<CurrencyViewModel> list2 = new List<CurrencyViewModel>();
            var listResult2 = await _currencyApi.List();
            if (listResult2.IsSuccessStatusCode &&
                listResult2.Content.IsSuccess &&
                listResult2.Content.ResultData.Any())
                list2 = _mapper.Map<List<CurrencyViewModel>>(listResult2.Content.ResultData);
            ViewBag.Currencies = new SelectList(list2, "Id", "Label");

            UpdateProductViewModel model = new UpdateProductViewModel();
            var updateResult = await _productApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel item, List<IFormFile> files)
        {
            item.UserId = Guid.Parse(User.Claims?.FirstOrDefault(x => x.Type == "Id").Value);
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.Barcode= imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View(item);
                }
                var updateResult = await _productApi.Put(item.Id, _mapper.Map<ProductRequestDto>(item));
                if (updateResult.IsSuccessStatusCode &&
                    updateResult.Content.IsSuccess &&
                    updateResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            return View(item);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _productApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _productApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
