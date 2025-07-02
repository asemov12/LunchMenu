using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Order
{
    public class GetOrderByIdResponse
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<int> DishIds { get; set; } = new List<int>();
    }
}
