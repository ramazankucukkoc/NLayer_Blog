using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
