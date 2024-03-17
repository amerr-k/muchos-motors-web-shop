using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class OrderItemRepository
    {
        private readonly DataDbContext dataDbContext;

        public OrderItemRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAscAsync()
        {
            return await dataDbContext.OrderItem
                .Where(orderItem => orderItem.IsValid)
                .ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await dataDbContext.OrderItem
                .FirstOrDefaultAsync(o => o.OrderItemId == orderItemId && o.IsValid);
        }

        public async Task<List<OrderItem>> GetAllOrderItemByOrderIdAsync(int orderId)
        {
            return await dataDbContext.OrderItem
                .Include(o => o.CarPart)
                .Where(o => o.OrderId == orderId && o.IsValid)
                .ToListAsync();
        }

        public void DeleteByObject(OrderItem orderItem)
        {
            orderItem.IsValid = false;
        }

        public async Task<OrderItem> CreateOrderItemAsync(int orderId, OrderItemDTO orderItemDto)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderId,
                CarPartId = orderItemDto.CarPartId,
                Quantity = orderItemDto.Quantity,
                Price = orderItemDto.Price,
                IsValid = true
            };
            await dataDbContext.AddAsync(orderItem);
            return orderItem;
        }

        public void UpdateOrderItem(OrderItem existingOrderItem, OrderItemDTO orderItemDto)
        {
            existingOrderItem.CarPartId = orderItemDto.CarPartId;
            existingOrderItem.Quantity = orderItemDto.Quantity;
            existingOrderItem.Price = orderItemDto.Price;
        }
    }
}
