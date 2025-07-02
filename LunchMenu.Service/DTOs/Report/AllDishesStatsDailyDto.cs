using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Report
{
    public class AllDishesStatsDailyDto
    {
        public DateTime Date { get; set; }
        public List<DailyDishStatDto> Dishes { get; set; } = new();
        public int TotalDishes => Dishes.Count;
        public int TotalOrders => Dishes.Sum(d => d.TimesOrdered);
        public int TotalUniqueCustomers =>
            Dishes.SelectMany(d => d.CustomerNames).Distinct().Count();
    }
}
