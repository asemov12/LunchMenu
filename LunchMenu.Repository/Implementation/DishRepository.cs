using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.Dish;
using LunchMenu.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace LunchMenu.Repository.Implementation
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        protected override string[] GetColumns() => new string[]
        {
            "DishId",
            "Name",
            "Type"
        };

        protected override string GetTableName()
        {
            return "Dishes";
        }

        protected override Dish MapEntity(SqlDataReader reader)
        {
            return new Dish
            {
                DishId = Convert.ToInt32(reader["DishId"]),
                Name = reader["Name"].ToString(),
                Type = reader["Type"].ToString()
            };
        }
        public Task<int> CreateAsync(Dish entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Dish> RetrieveByIdAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Dish> RetrieveCollectionAsync(DishFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, DishUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
