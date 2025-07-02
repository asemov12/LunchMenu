using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Service.DTOs.Customer;

namespace LunchMenu.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<GetCustomerResponse> GetCustomerByIdAsync(int customerId);
        Task<GetAllCustomersResponse> GetAllCustomersAsync();
    }
}
