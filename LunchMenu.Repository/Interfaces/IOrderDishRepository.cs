using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.OrderDish;

namespace LunchMenu.Repository.Interfaces
{
    public interface IOrderDishRepository: IBaseRepository<OrderDish, OrderDishFilter, OrderDishUpdate>
    {
    }
}
