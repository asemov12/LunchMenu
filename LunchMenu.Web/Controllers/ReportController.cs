using Microsoft.AspNetCore.Mvc;

namespace LunchMenu.Web.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
