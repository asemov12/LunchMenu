using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Helpers.Customer;
using LunchMenu.Repository.Helpers.Dish;
using LunchMenu.Repository.Helpers.Order;
using LunchMenu.Repository.Helpers.OrderDish;
using LunchMenu.Repository.Interfaces;
using LunchMenu.Service.DTOs.Report;
using LunchMenu.Service.Interfaces;

namespace LunchMenu.Service.Services
{
    public class ReportService: IReportService
    {
        private readonly IOrderDishRepository _orderDishRepo;
        private readonly IDishRepository _dishRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;

        public ReportService(
            IOrderDishRepository orderDishRepo,
            IDishRepository dishRepo,
            IOrderRepository orderRepo,
            ICustomerRepository customerRepo)
        {
            _orderDishRepo = orderDishRepo;
            _dishRepo = dishRepo;
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
        }

        public async Task<AllDishesStatsDto> GetMostOrderedDishesAsync()
        {
            var orderDishes = await _orderDishRepo.RetrieveCollectionAsync(new OrderDishFilter()).ToListAsync(); // Get all order dishes
            var dishes = await _dishRepo.RetrieveCollectionAsync(new DishFilter()).ToListAsync(); // Get all dishes

            var grouped = orderDishes
                .GroupBy(od => od.DishId)
                .Select(g =>
                {
                    var dish = dishes.FirstOrDefault(d => d.DishId == g.Key);
                    return new DishStatsDto
                    {
                        DishId = dish?.DishId ?? 0,
                        Name = dish?.Name ?? "(Unknown)",
                        Type = dish?.Type ?? "(Unknown)",
                        TimesOrdered = g.Sum(od => od.Quantity)
                    };
                })
                .OrderByDescending(d => d.TimesOrdered)
                .ToList();

            return new AllDishesStatsDto
            {
                Dishes = grouped
            };
        }

        public async Task<AllDishesStatsDailyDto> GetDailyDishReportAsync(DateTime day)
        {
            var orders = await _orderRepo.RetrieveCollectionAsync(new OrderFilter { OrderDate = day }).ToListAsync();
            var orderIds = orders.Select(o => o.OrderId).ToList();
            var orderDishes = await _orderDishRepo.RetrieveCollectionAsync(new OrderDishFilter()).ToListAsync();
            var dishes = await _dishRepo.RetrieveCollectionAsync(new DishFilter()).ToListAsync();
            var customers = await _customerRepo.RetrieveCollectionAsync(new CustomerFilter()).ToListAsync();
            orderDishes = orderDishes.Where(od => orderIds.Contains(od.OrderId))
                .ToList(); // Filter order dishes by the orders of the specified day
            var dishGroups = orderDishes
                .GroupBy(od => od.DishId)
                .Select(g =>
                {
                    var dish = dishes.FirstOrDefault(d => d.DishId == g.Key);
                    var customerNames = g
                        .SelectMany(od => orders
                            .Where(o => o.OrderId == od.OrderId)
                            .Select(o => customers.FirstOrDefault(c => c.CustomerId == o.CustomerId)?.Name ?? "(Unknown)"))
                        .Distinct()
                        .ToList();

                    return new DailyDishStatDto
                    {
                        DishId = dish?.DishId ?? 0,
                        Name = dish?.Name ?? "(Unknown)",
                        Type = dish?.Type ?? "(Unknown)",
                        TimesOrdered = g.Sum(x => x.Quantity),
                        CustomerNames = customerNames
                    };
                })
                .OrderByDescending(r => r.TimesOrdered)
                .ToList();

            return new AllDishesStatsDailyDto
            {
                Date = day,
                Dishes = dishGroups
            };
        }
    }
}
