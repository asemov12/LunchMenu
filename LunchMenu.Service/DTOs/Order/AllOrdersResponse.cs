using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Order
{
    public class AllOrdersResponse
    {
        public List<OrderResponse> Orders { get; set; } = new List<OrderResponse>();
        public int TotalCount { get; set; } = 0;
    }
}
