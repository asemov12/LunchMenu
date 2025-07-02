using LunchMenu.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LunchMenu.Web.Controllers
{
    [UserAuthorization]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
