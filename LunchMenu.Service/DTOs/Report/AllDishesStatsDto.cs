using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Report
{
    public class AllDishesStatsDto
    {
        public List<DishStatsDto> Dishes { get; set; } = new();
        public int TotalDishes => Dishes.Count;
        public int TotalOrders => Dishes.Sum(d => d.TimesOrdered);
    }
}
