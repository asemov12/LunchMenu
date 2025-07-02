using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Interfaces;
using LunchMenu.Service.DTOs.Customer;
using LunchMenu.Service.Interfaces;

namespace LunchMenu.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<GetAllCustomersResponse> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCustomerResponse> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
