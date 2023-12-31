using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UcakRezervasyon.Controllers
{
    [Authorize(Roles ="admin")]
    public class YonetimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
