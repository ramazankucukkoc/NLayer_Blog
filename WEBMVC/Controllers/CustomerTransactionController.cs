using Microsoft.AspNetCore.Mvc;

namespace WEBMVC.Controllers
{
    public class CustomerTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
