using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Helpers.Dish;
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

        public async Task<GetAllDishesResponse> GetAllDishesAsync()
        {
            var dishes = await _dishRepository
                .RetrieveCollectionAsync(new DishFilter())
                .ToListAsync();

            return new GetAllDishesResponse
            {
                Dishes = dishes.Select(d => new GetDishResponse
                {
                    DishId = d.DishId,
                    Name = d.Name,
                    Type = d.Type
                }).ToList(),
                TotalCount = dishes.Count
            };
        }

        public async Task<GetDishResponse> GetDishByIdAsync(int dishId)
        {
            var dish = await _dishRepository.RetrieveByIdAsync(dishId);

            if (dish == null)
                return null;

            return new GetDishResponse
            {
                DishId = dish.DishId,
                Name = dish.Name,
                Type = dish.Type
            };
        }

        public async Task<GetDishesOfTypeResponse> GetDishesOfTypeAsync(string type)
        {
            var filter = new DishFilter { Type = type };
            var dishes = await _dishRepository
                .RetrieveCollectionAsync(filter)
                .ToListAsync();

            return new GetDishesOfTypeResponse
            {
                Type = type,
                Count = dishes.Count,
                Dishes = dishes.Select(d => new DishInfo
                {
                    DishId = d.DishId,
                    Name = d.Name
                }).ToList()
            };
        }
    }
}
