using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Repository.Helpers.Order
{
    public class OrderFilter
    {
        public SqlInt32? CustomerId { get; set; }
        public SqlDateTime? OrderDate { get; set; }
    }
}
