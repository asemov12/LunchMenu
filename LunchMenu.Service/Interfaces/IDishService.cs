using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Service.DTOs.Dish;

namespace LunchMenu.Service.Interfaces
{
    public interface IDishService
    {
        Task<GetDishResponse> GetDishByIdAsync(int dishId);
        Task<GetAllDishesResponse> GetAllDishesAsync();
        Task<GetDishesOfTypeResponse> GetDishesOfTypeAsync(string type);
    }
}
