using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKaymaz_ECommerce.Common.Dtos.Member;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.CountryViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.MemberViewModels;
using MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberApi _memberApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly ICountryApi _countryApi;
        private readonly ILocationApi _locationApi;
        public MemberController(
            IMemberApi memberApi,
            IMapper mapper,
            IWebHostEnvironment env,
            ICountryApi countryApi, 
            ILocationApi locationApi)
        {
            _memberApi = memberApi;
            _mapper = mapper;
            _env=env;
            _countryApi=countryApi;
            _locationApi=locationApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<MemberViewModel> list = new List<MemberViewModel>();
            var listResult = await _memberApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<MemberViewModel>>(listResult.Content.ResultData);
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


            List<LocationViewModel> list1 = new List<LocationViewModel>();
            var listResult1 = await _locationApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<LocationViewModel>>(listResult1.Content.ResultData);
            ViewBag.Locations = new SelectList(list1, "Id", "Name");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateMemberViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _memberApi.Post(_mapper.Map<MemberRequestDto>(item));
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

            List<LocationViewModel> list1 = new List<LocationViewModel>();
            var listResult1 = await _locationApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<LocationViewModel>>(listResult1.Content.ResultData);
            ViewBag.Locations = new SelectList(list1, "Id", "Name");

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

            List<LocationViewModel> list1 = new List<LocationViewModel>();
            var listResult1 = await _locationApi.List();
            if (listResult1.IsSuccessStatusCode &&
                listResult1.Content.IsSuccess &&
                listResult1.Content.ResultData.Any())
                list1 = _mapper.Map<List<LocationViewModel>>(listResult1.Content.ResultData);
            ViewBag.Locations = new SelectList(list1, "Id", "Name");


            UpdateMemberViewModel model = new UpdateMemberViewModel();
            var updateResult = await _memberApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateMemberViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMemberViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _memberApi.Put(item.Id, _mapper.Map<MemberRequestDto>(item));
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
            var deleteResult = await _memberApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _memberApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
