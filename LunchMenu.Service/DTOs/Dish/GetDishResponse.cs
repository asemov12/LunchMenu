using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Dish
{
    public class GetDishResponse
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
