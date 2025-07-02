using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Base;
using LunchMenu.Repository.Helpers.Customer;

namespace LunchMenu.Repository.Interfaces
{
    public interface ICustomerRepository: IBaseRepository<Customer, CustomerFilter, CustomerUpdate>
    {
    }
}
