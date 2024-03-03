using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Web.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
