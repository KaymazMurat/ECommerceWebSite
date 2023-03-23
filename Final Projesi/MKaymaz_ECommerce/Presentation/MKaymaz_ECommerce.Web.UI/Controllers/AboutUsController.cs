using Microsoft.AspNetCore.Mvc;

namespace MKaymaz_ECommerce.Web.UI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Faqs()
        {
            return View();
        }
    }
}
