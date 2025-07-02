using LunchMenu.Service.Interfaces;
using LunchMenu.Web.Filters;
using LunchMenu.Web.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace LunchMenu.Web.Controllers
{
    [UserAuthorization]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> PopularDishes()
        {
            var dto = await _reportService.GetMostOrderedDishesAsync();

            var model = new PopularDishesViewModel
            {
                TotalOrders = dto.TotalOrders,
                TotalDishes = dto.TotalDishes,
                Dishes = dto.Dishes.Select(d => new PopularDishViewModel
                {
                    Name = d.Name,
                    Type = d.Type,
                    TimesOrdered = d.TimesOrdered
                }).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult DailyStats()
        {
            return View(new DailyStatsViewModel
            {
                SelectedDate = DateTime.Today
            });
        }

        [HttpPost]
        public async Task<IActionResult> DailyStats(DailyStatsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var report = await _reportService.GetDailyDishReportAsync(model.SelectedDate.Value);

            model.Date = report.Date;
            model.TotalOrders = report.TotalOrders;
            model.TotalDishes = report.TotalDishes;
            model.TotalUniqueCustomers = report.TotalUniqueCustomers;
            model.Dishes = report.Dishes.Select(d => new DailyDishStatViewModel
            {
                Name = d.Name,
                Type = d.Type,
                TimesOrdered = d.TimesOrdered,
                CustomerNames = d.CustomerNames
            }).ToList();

            return View(model);
        }
    }
}
