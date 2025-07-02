using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.Order;

namespace LunchMenu.Repository.Interfaces
{
    public interface IOrderRepository: IBaseRepository<Order, OrderFilter, OrderUpdate>
    {
    }
}
