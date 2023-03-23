using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.ViewComponents
{
    public class TrendingViewComponent : ViewComponent
    {
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public TrendingViewComponent(IProductApi productApi, IMapper mapper)
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
                    listResult.Content.ResultData.OrderByDescending(x => x.ViewCount).Take(5).ToList());

            return View(list);
        }
    }
}
