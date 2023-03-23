using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.ViewComponents
{
    public class RecommendedViewComponent : ViewComponent
    {
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public RecommendedViewComponent(IProductApi productApi, IMapper mapper)
        {
            _productApi=productApi;
            _mapper=mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(
                    listResult.Content.ResultData.OrderBy(x => Guid.NewGuid()).Take(3).ToList());

            return View(list);
        }
    }
}
