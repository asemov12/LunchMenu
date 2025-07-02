using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.OrderDish;
using LunchMenu.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace LunchMenu.Repository.Implementation
{
    public class OrderDishRepository : BaseRepository<OrderDish>, IOrderDishRepository
    {
        protected override string[] GetColumns() => new string[]
        {
            "OrderDishId",
            "OrderId",
            "DishId",
            "Quantity"
        };

        protected override string GetTableName()
        {
            return "OrderDishes";
        }

        protected override OrderDish MapEntity(SqlDataReader reader)
        {
            return new OrderDish
            {
                OrderDishId = Convert.ToInt32(reader["OrderDishId"]),
                OrderId = Convert.ToInt32(reader["OrderId"]),
                DishId = Convert.ToInt32(reader["DishId"]),
                Quantity = Convert.ToInt32(reader["Quantity"])
            };
        }
        public Task<int> CreateAsync(OrderDish entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDish> RetrieveByIdAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<OrderDish> RetrieveCollectionAsync(OrderDishFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, OrderDishUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
