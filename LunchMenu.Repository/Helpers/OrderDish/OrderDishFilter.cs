using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Repository.Helpers.OrderDish
{
    public class OrderDishFilter
    {
        public SqlInt32? OrderId { get; set; }
        public SqlInt32? DishId { get; set; }
    }
}
