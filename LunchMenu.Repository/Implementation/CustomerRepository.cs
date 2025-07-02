using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers;
using LunchMenu.Repository.Helpers.Customer;
using LunchMenu.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace LunchMenu.Repository.Implementation
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        protected override string[] GetColumns() => new string[]
        {
            "CustomerId",
            "Name",
            "Username",
            "PasswordHash",
            "Type"
        };

        protected override string GetTableName()
        {
            return "Customers";
        }

        protected override Customer MapEntity(SqlDataReader reader)
        {
            return new Customer
            {
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                Name = reader["Name"].ToString(),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Type = reader["Type"].ToString()
            };
        }
        public Task<int> CreateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RetrieveByIdAsync(int objectId)
        {
            return base.RetrieveByIdAsync("CustomerId", objectId);
        }

        public IAsyncEnumerable<Customer> RetrieveCollectionAsync(CustomerFilter filter)
        {
            Filter commandFilter = new Filter();

            if (filter.Username is not null)
            {
                commandFilter.AddCondition("Username", filter.Username);
            }

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public Task<bool> UpdateAsync(int objectId, CustomerUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
