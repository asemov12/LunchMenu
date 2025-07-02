using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.Dish;

namespace LunchMenu.Repository.Interfaces
{
    public interface IDishRepository: IBaseRepository<Dish, DishFilter, DishUpdate>
    {
    }
}
