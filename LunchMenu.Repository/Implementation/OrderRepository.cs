using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers;
using LunchMenu.Repository.Helpers.Order;
using LunchMenu.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace LunchMenu.Repository.Implementation
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        protected override string[] GetColumns() => new string[]
        {
            "OrderId",
            "CustomerId",
            "OrderDate",
            "CreatedAt"
        };

        protected override string GetTableName()
        {
            return "Orders";
        }

        protected override Order MapEntity(SqlDataReader reader)
        {
            return new Order
            {
                OrderId = Convert.ToInt32(reader["OrderId"]),
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
        public Task<int> CreateAsync(Order entity)
        {
            return base.CreateAsync(entity, "OrderId");
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            return base.DeleteAsync("OrderId", objectId);
        }

        public Task<Order> RetrieveByIdAsync(int objectId)
        {
            return base.RetrieveByIdAsync("OrderId", objectId);
        }

        public IAsyncEnumerable<Order> RetrieveCollectionAsync(OrderFilter filter)
        {
            Filter commandFilter = new Filter();

            if (filter.CustomerId is not null)
            {
                commandFilter.AddCondition("CustomerId", filter.CustomerId);
            }
            if (filter.OrderDate is not null)
            {
                commandFilter.AddCondition("OrderDate", filter.OrderDate);
            }

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public Task<bool> UpdateAsync(int objectId, OrderUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
