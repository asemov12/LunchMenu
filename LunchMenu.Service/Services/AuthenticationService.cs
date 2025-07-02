using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Helpers.Customer;
using LunchMenu.Repository.Interfaces;
using LunchMenu.Service.DTOs.Authentication;
using LunchMenu.Service.Helpers;
using LunchMenu.Service.Interfaces;

namespace LunchMenu.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository _customerRepo;

        public AuthenticationService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginRequest loginRequest)
        {
            var filter = new CustomerFilter
            {
                Username = new SqlString(loginRequest.Username)
            };

            var customers = await _customerRepo.RetrieveCollectionAsync(filter).ToListAsync();
            var customer = customers.FirstOrDefault();

            if (customer == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid username or password."
                };
            }

            var hashedPassword = PasswordHasher.Hash(loginRequest.Password);

            if (customer.PasswordHash != hashedPassword)
            {
                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid username or password."
                };
            }

            return new LoginResponse
            {
                Success = true,
                CustomerId = customer.CustomerId,
                Name = customer.Name,
            };
        }
    }
}
