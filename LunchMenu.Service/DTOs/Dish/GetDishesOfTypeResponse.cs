using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Dish
{
    public class GetDishesOfTypeResponse
    {
        public List<DishInfo> Dishes { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
    }
}
