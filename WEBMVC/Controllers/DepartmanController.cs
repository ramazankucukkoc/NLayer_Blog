using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class DepartmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
