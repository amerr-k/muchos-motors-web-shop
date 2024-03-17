using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using muchos_motors_api.Utils;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class OrderRepository
    {
        private readonly DataDbContext dataDbContext;

        public OrderRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<Order>> GetAllOrdersAscAsync()
        {
            return await dataDbContext.Order
                .Where(order => order.IsValid)
                .OrderBy(order => order.OrderDate)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await dataDbContext.Order
                .Include(order => order.CustomerShippingCity)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && o.IsValid);
        }

        public void DeleteByObject(Order order)
        {
            order.IsValid = false;
        }

        public async Task<Order> CreateOrderAsync(OrderDTO orderDto, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.Now,
                TotalPrice = orderDto.TotalPrice,
                CustomerEmail = orderDto.CustomerEmail,
                CustomerFirstName = orderDto.CustomerFirstName,
                CustomerLastName = orderDto.CustomerLastName,
                CustomerPhone = orderDto.CustomerPhone,
                CustomerShippingAddress = orderDto.CustomerShippingAddress,
                CustomerShippingCityId = orderDto.CustomerShippingCityId,
                InvoiceCreated = false,
                IsValid = true
            };
            await dataDbContext.AddAsync(order, cancellationToken);
            return order;
        }

        public void UpdateOrder(Order existingOrder, OrderDTO orderDto)
        {
            existingOrder.EmployeeId = orderDto.EmployeeId;
            existingOrder.ShippingDate = orderDto.ShippingDate?.ConvertToCET();
            existingOrder.InvoiceCreatedDate = DateTime.Now;
            existingOrder.InvoiceCreated = true;
        }
    }
}
