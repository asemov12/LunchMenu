using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Dish
{
    public class GetAllDishesResponse
    {
        public List<GetDishResponse> Dishes { get; set; } = new List<GetDishResponse>();
        public int TotalCount { get; set; }
    }
}
