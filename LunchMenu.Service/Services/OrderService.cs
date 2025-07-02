using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Repository.Interfaces;
using LunchMenu.Service.DTOs.Order;
using LunchMenu.Service.Interfaces;

namespace LunchMenu.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDishRepository _orderDishRepository;

        public OrderService(IOrderRepository orderRepository, IOrderDishRepository orderDishRepository)
        {
            _orderRepository = orderRepository;
            _orderDishRepository = orderDishRepository;
        }

        public Task<bool> CancelOrderAsync(CancelOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AllOrdersResponse> GetCustomerOrdersAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<GetOrderByIdResponse> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
