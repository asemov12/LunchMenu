using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Repository.Helpers.Dish
{
    public class DishFilter
    {
        public SqlString? Type { get; set; }
    }
}
