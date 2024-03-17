using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using muchos_motors_api.Utils;
using System.Threading;
using QuestPDF.Infrastructure;
using muchos_motors_api.Invoice;
using System;

namespace muchos_motors_api.Services
{
    public class InvoiceService
    {
        private readonly OrderRepository orderRepository;
        private readonly OrderItemRepository orderItemRepository;

        public InvoiceService(OrderRepository orderRepository,
            OrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public async Task<InvoiceModel> GetInvoiceDetails(int orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);

            var orderItems = await orderItemRepository.GetAllOrderItemByOrderIdAsync(order.OrderId);

            return new InvoiceModel
            {
                InvoiceNumber = orderId,
                IssueDate = order.InvoiceCreatedDate ?? DateTime.Now,
                DueDate = order.ShippingDate ?? DateTime.Now,

                SellerAddress = GenerateSellerAddress(),
                CustomerAddress = GenerateCustomerAddress(order),

                Items = GenerateOrderItems(orderItems),
            };
        }

        private AddressInvoiceModel GenerateSellerAddress()
        {
            return new AddressInvoiceModel
            {
                CompanyName = "Muchos Motors",
                Street = "Ulica Dugi sokak, bb",
                City = "Donji Vakuf",
                State = "Bosna i Hercegovina",
                Email = "info@muchos-motors.ba",
                Phone = "+387 30 123-123"
            };
        }

        private List<OrderItemInvoiceModel> GenerateOrderItems(List<OrderItem> orderItems)
        {
            List<OrderItemInvoiceModel> orderItemInvoiceModels = new List<OrderItemInvoiceModel>();

            foreach (var orderItem in orderItems)
            {
                OrderItemInvoiceModel orderItemInvoiceModel = new OrderItemInvoiceModel
                {
                    Name = orderItem.CarPart.Name,
                    Price = orderItem.CarPart.SellingPrice,
                    Quantity = orderItem.Quantity,
                    TotalPrice = orderItem.Price
                };

                orderItemInvoiceModels.Add(orderItemInvoiceModel);
            }

            return orderItemInvoiceModels;
        }

        private AddressInvoiceModel GenerateCustomerAddress(Order order)
        {
            return new AddressInvoiceModel
            {
                CompanyName = order.CustomerFirstName + " " + order.CustomerLastName,
                Street = order.CustomerShippingAddress,
                City = order.CustomerShippingCity.Name,
                State = "Bosna i Hercegovina",
                Email = order.CustomerEmail,
                Phone = order.CustomerPhone
            };
        }
    }
}


