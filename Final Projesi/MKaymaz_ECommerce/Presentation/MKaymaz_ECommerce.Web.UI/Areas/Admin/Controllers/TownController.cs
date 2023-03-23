using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKaymaz_ECommerce.Common.Dtos.Town;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.LocationViewModels;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.TownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class TownController : Controller
    {
        private readonly ITownApi _townApi;
        private readonly IMapper _mapper;
        private readonly ILocationApi _locationApi;

        public TownController(
            ITownApi townApi,
            IMapper mapper, ILocationApi locationApi)
        {
            _townApi = townApi;
            _mapper = mapper;
            _locationApi=locationApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<TownViewModel> list = new List<TownViewModel>();
            var listResult = await _townApi.List();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<TownViewModel>>(listResult.Content.ResultData);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<LocationViewModel> list = new List<LocationViewModel>();
            var listResult = await _locationApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<LocationViewModel>>(listResult.Content.ResultData);
            ViewBag.Locations = new SelectList(list, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateTownViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _townApi.Post(_mapper.Map<TownRequestDto>(item));
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!... Lütfen alanları kontrol edip tekrar deneyinzi...";
            }
            TempData["Message"] = "İşlem başarısız oldu!... Lütfen alanları kontrol edip tekrar deneyinzi...";

            List<LocationViewModel> list = new List<LocationViewModel>();
            var listResult = await _locationApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<LocationViewModel>>(listResult.Content.ResultData);
            ViewBag.Locations = new SelectList(list, "Id", "Name");


            return View(item);


        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            List<LocationViewModel> list = new List<LocationViewModel>();
            var listResult = await _locationApi.List();
            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<LocationViewModel>>(listResult.Content.ResultData);
            ViewBag.Locations = new SelectList(list, "Id", "Name");


            UpdateTownViewModel model = new UpdateTownViewModel();
            var updateResult = await _townApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateTownViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTownViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _townApi.Put(item.Id, _mapper.Map<TownRequestDto>(item));
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
            var deleteResult = await _townApi.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(Guid id)
        {
            var activateResult = await _townApi.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
