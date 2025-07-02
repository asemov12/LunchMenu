using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Interfaces;
using LunchMenu.Service.DTOs.Dish;
using LunchMenu.Service.Interfaces;

namespace LunchMenu.Service.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public Task<GetAllDishesResponse> GetAllDishesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetDishResponse> GetDishByIdAsync(int dishId)
        {
            throw new NotImplementedException();
        }

        public Task<GetDishesOfTypeResponse> GetDishesOfTypeAsync(string type)
        {
            throw new NotImplementedException();
        }
    }
}
