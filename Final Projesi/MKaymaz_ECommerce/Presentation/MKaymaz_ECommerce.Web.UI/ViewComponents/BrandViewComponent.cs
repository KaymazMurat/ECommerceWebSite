using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MKaymaz_ECommerce.Web.UI.APIs;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.BrandViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKaymaz_ECommerce.Web.UI.ViewComponents
{
    public class BrandViewComponent:ViewComponent
    {
        private readonly IBrandApi _brandApi;
        private readonly IMapper _mapper;

        public BrandViewComponent(IMapper mapper, IBrandApi brandApi)
        {
            _mapper = mapper;
            _brandApi=brandApi;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BrandViewModel> list = new List<BrandViewModel>();
            var listResult = await _brandApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<BrandViewModel>>(listResult.Content.ResultData);

            return View(list);
        }
    }
}
