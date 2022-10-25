using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class CompanyTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
