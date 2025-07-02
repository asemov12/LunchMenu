using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Service.DTOs.Customer
{
    public class GetAllCustomersResponse
    {
        public List<GetCustomerResponse> Customers { get; set; } = new List<GetCustomerResponse>();
        public int TotalCount { get; set; }
    }
}
