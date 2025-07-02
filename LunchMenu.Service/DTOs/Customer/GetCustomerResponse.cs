using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Customer
{
    public class GetCustomerResponse
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
    }
}
