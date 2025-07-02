using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Helpers.Customer;
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

        public async Task<GetAllCustomersResponse> GetAllCustomersAsync()
        {
            var customers = await _customerRepository
                .RetrieveCollectionAsync(new CustomerFilter())
                .ToListAsync();

            var response = new GetAllCustomersResponse
            {
                Customers = customers.Select(c => new GetCustomerResponse
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Username = c.Username,
                    Type = c.Type
                }).ToList(),
                TotalCount = customers.Count
            };

            return response;
        }

        public async Task<GetCustomerResponse> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.RetrieveByIdAsync(customerId);

            if (customer == null)
                return null;

            return new GetCustomerResponse
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Username = customer.Username,
                Type = customer.Type
            };
        }
    }
}
