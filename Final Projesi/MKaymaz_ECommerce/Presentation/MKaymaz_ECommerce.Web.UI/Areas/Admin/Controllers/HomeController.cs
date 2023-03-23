
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            return View();
        }
    }
}
