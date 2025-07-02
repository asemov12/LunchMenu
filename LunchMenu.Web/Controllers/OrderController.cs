using LunchMenu.Models;
using LunchMenu.Repository.Helpers.Order;
using LunchMenu.Service.DTOs.Order;
using LunchMenu.Service.Interfaces;
using LunchMenu.Web.Filters;
using LunchMenu.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LunchMenu.Web.Controllers
{
    [UserAuthorization]
    public class OrderController : Controller
    {
        private static readonly List<string> DishTypes = new List<string>
        {
            "appetizer",
            "main",
            "dessert"
        };

        private readonly IOrderService _orderService;
        private readonly IDishService _dishService;

        public OrderController(IOrderService orderService, IDishService dishService)
        {
            _orderService = orderService;
            _dishService = dishService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MyOrders()
        {
            int customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            var ordersResponse = await _orderService.GetCustomerOrdersAsync(customerId); 

            var viewModel = new OrdersListViewModel
            {
                Orders = ordersResponse.Orders
                    .OrderBy(o => o.OrderDate)
                    .Select(o => new OrderViewModel
                    {
                        OrderDate = o.OrderDate,
                        CreatedAt = o.CreatedAt,
                        OrderId = o.OrderId,
                    }).ToList(),
                totalCount = ordersResponse.TotalCount
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int orderId)
        {
            int customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            bool success = await _orderService.CancelOrderAsync(
                new CancelOrderRequest { OrderId = orderId, CustomerId = customerId });

            TempData["CancelMessage"] = success
                ? "Order canceled successfully."
                : "Failed to cancel order.";

            return RedirectToAction("MyOrders");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var appetizers = (await _dishService.GetDishesOfTypeAsync("appetizer")).Dishes;
            var mains = (await _dishService.GetDishesOfTypeAsync("main")).Dishes;
            var desserts = (await _dishService.GetDishesOfTypeAsync("dessert")).Dishes;

            var model = new CreateOrderViewModel
            {
                Appetizers = appetizers,
                MainCourses = mains,
                Desserts = desserts
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {

            var dishIds = new List<int>();
            if (model.SelectedAppetizerId.HasValue)
                dishIds.Add(model.SelectedAppetizerId.Value);

            if (model.SelectedMainCourseId.HasValue)
                dishIds.Add(model.SelectedMainCourseId.Value);

            if (model.SelectedDessertId.HasValue)
                dishIds.Add(model.SelectedDessertId.Value);

            if (!dishIds.Any())
            {
                ModelState.AddModelError("", "Please select at least one dish.");
            }

            if (!ModelState.IsValid)
            {
                model.Appetizers = (await _dishService.GetDishesOfTypeAsync("appetizer")).Dishes;
                model.MainCourses = (await _dishService.GetDishesOfTypeAsync("main")).Dishes;
                model.Desserts = (await _dishService.GetDishesOfTypeAsync("dessert")).Dishes;
                return View(model);
            }

            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0;

            var request = new CreateOrderRequest
            {
                CustomerId = customerId,
                OrderDate = model.OrderDate,
                DishIds = dishIds
            };

            await _orderService.CreateOrderAsync(request);
            TempData["Message"] = "Order placed successfully.";
            return RedirectToAction("MyOrders");
        }
    }
}
