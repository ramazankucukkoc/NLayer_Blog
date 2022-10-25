using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
