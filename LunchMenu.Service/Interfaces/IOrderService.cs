using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Service.DTOs.Order;

namespace LunchMenu.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
        Task<bool> CancelOrderAsync(CancelOrderRequest request);
        Task<AllOrdersResponse> GetCustomerOrdersAsync(int customerId);
        Task<GetOrderByIdResponse> GetOrderByIdAsync(int orderId);
    }
}
