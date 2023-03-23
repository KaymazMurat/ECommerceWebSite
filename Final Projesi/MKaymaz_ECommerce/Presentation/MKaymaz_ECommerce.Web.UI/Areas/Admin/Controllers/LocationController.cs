using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKaymaz_ECommerce.Common.Dtos.Location;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationApi _locationApi;
        private readonly ICountryApi _countryApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public LocationController(
            ILocationApi locationApi,
            IMapper mapper,
            ICountryApi countryApi, IWebHostEnvironment env)
        {
            _locationApi = locationApi;
            _mapper = mapper;
            _countryApi=countryApi;
            _env=env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<LocationViewModel> list = new List<LocationViewModel>();
            var listResult = await _locationApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<LocationViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<CountryViewModel> list = new List<CountryViewModel>();
            var listResult = await _countryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CountryViewModel>>(listResult.Content.ResultData);
            ViewBag.Countries = new SelectList(list, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateLocationViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _locationApi.Post(_mapper.Map<LocationRequestDto>(item));
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";

            List<CountryViewModel> list = new List<CountryViewModel>();
            var listResult = await _countryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CountryViewModel>>(listResult.Content.ResultData);
            ViewBag.Countries = new SelectList(list, "Id", "Name");


            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<CountryViewModel> list = new List<CountryViewModel>();
            var listResult = await _countryApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CountryViewModel>>(listResult.Content.ResultData);
            ViewBag.Countries = new SelectList(list, "Id", "Name");


            UpdateLocationViewModel model = new UpdateLocationViewModel();
            var updateResult = await _locationApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateLocationViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _locationApi.Put(item.Id, _mapper.Map<LocationRequestDto>(item));
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
            var deleteResult = await _locationApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _locationApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
