using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchMenu.Models;
using LunchMenu.Repository.Helpers.Order;
using LunchMenu.Repository.Helpers.OrderDish;
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

        public async Task<bool> CancelOrderAsync(CancelOrderRequest request)
        {
            var order = await _orderRepository.RetrieveByIdAsync(request.OrderId);

            if (order == null || order.CustomerId != request.CustomerId)
                return false;

            await _orderRepository.DeleteAsync(order.OrderId); 

            return true;
        }

        public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            // Check if order already exists for the same day
            await foreach (var existing in _orderRepository.RetrieveCollectionAsync(new OrderFilter { CustomerId = request.CustomerId, OrderDate = request.OrderDate }))
            {
                throw new InvalidOperationException("Customer already has an order for this date.");
            }

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                CreatedAt = DateTime.Now
            };

            var createdOrderId = await _orderRepository.CreateAsync(order);
            var createdOrder = await _orderRepository.RetrieveByIdAsync(createdOrderId);

            foreach (var dishId in request.DishIds)
            {
                var orderDish = new OrderDish
                {
                    OrderId = createdOrder.OrderId,
                    DishId = dishId,
                    Quantity = 1 // Assumes 1 per dish ID
                };

                await _orderDishRepository.CreateAsync(orderDish);
            }

            return new OrderResponse
            {
                OrderId = createdOrder.OrderId,
                CustomerId = createdOrder.CustomerId,
                OrderDate = createdOrder.OrderDate,
                CreatedAt = createdOrder.CreatedAt
            };
        }

        public async Task<AllOrdersResponse> GetCustomerOrdersAsync(int customerId)
        {
            var orders = new List<Order>();
            await foreach (var o in _orderRepository.RetrieveCollectionAsync(new OrderFilter { CustomerId = customerId }))
            {
                orders.Add(o);
            }

            var response = new AllOrdersResponse
            {
                Orders = orders.Select(o => new OrderResponse
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    CreatedAt = o.CreatedAt
                }).ToList(),
                TotalCount = orders.Count
            };

            return response;
        }

        public async Task<GetOrderByIdResponse> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.RetrieveByIdAsync(orderId);
            if (order == null)
                throw new ValidationException("There is no existing order with this id!");

            var dishes = new List<OrderDish>();
            await foreach (var od in _orderDishRepository.RetrieveCollectionAsync(new OrderDishFilter { OrderId = orderId }))
            {
                dishes.Add(od);
            }

            return new GetOrderByIdResponse
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                CreatedAt = order.CreatedAt,
                DishIds = dishes.Select(d => d.DishId).ToList()
            };
        }
    }
}
