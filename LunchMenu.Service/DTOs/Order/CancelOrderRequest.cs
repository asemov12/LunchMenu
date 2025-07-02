using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Order
{
    public class CancelOrderRequest
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}
