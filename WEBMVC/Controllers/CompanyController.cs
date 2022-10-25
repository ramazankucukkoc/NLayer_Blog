using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
