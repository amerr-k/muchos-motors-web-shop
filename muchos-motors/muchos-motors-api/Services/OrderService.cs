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
using QuestPDF.Fluent;
using QuestPDF;

namespace muchos_motors_api.Services
{
    public class OrderService
    {
        private readonly DataDbContext dataDbContext;
        private readonly OrderRepository orderRepository;
        private readonly OrderItemRepository orderItemRepository;
        private readonly Mapper mapper;
        private readonly CustomerService customerService;
        private readonly InvoiceService invoiceService;


        public OrderService(DataDbContext dataDbContext, 
            OrderRepository orderRepository, 
            OrderItemRepository orderItemRepository,
            Mapper mapper,
            CustomerService customerService,
            InvoiceService invoiceService)
        {
            this.dataDbContext = dataDbContext;
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
            this.invoiceService = invoiceService;
            this.customerService = customerService;
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orderList = await orderRepository.GetAllOrdersAscAsync();
            return mapper.Map<List<OrderDTO>>(orderList);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new AppException($"Narudžba sa ID: {orderId} nije pronađena", (int)HttpStatusCode.NotFound);
            }

            var ordersDto = mapper.Map<OrderDTO>(order);

            var orderItems = await orderItemRepository.GetAllOrderItemByOrderIdAsync(order.OrderId);
            var orderItemsDto = mapper.Map<List<OrderItemDTO>>(orderItems);

            ordersDto.OrderItems = orderItemsDto;

            return ordersDto;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new AppException($"Narudžba sa ID: {orderId} nije pronađena", (int)HttpStatusCode.NotFound);
            }
            orderRepository.DeleteByObject(order);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<Order> CreateOrderAsync(OrderDTO orderDto, CancellationToken cancellationToken)
        {
            ValidateOrderDto(orderDto);

            //orderDto.CustomerId = await UpdateOrdersCustomer(orderDto, cancellationToken);    

            var createdOrder = await orderRepository.CreateOrderAsync(orderDto, cancellationToken);
            await dataDbContext.SaveChangesAsync(cancellationToken);

            await CreateOrderItems(createdOrder.OrderId, orderDto.OrderItems);

            return createdOrder;
        }



        //private async Task<int> UpdateOrdersCustomer(OrderDTO orderDto, CancellationToken cancellationToken)
        //{
        //    Customer customer = null;
        //    if (orderDto?.CustomerId != null)
        //    {
        //        customer = await customerService.GetCustomerByIdAsync(orderDto.CustomerId.Value);
        //    }
        //    else if (ValidationUtils.IsNotNull(orderDto.Customer.Email))
        //    {
        //        customer = await customerService.GetCustomerByEmailAsync(orderDto.Customer.Email);
        //    }

        //    if (!ValidationUtils.IsNotNull(customer))
        //    {
        //        var newCustomerDto = orderDto.Customer;
        //        customer = await customerService.CreateCustomerAsync(newCustomerDto, cancellationToken);
        //        await dataDbContext.SaveChangesAsync();
        //    }
        //    return customer.UserAccountId;
        //}

        private async Task CreateOrderItems(int orderId, List<OrderItemDTO> orderItems)
        {
            foreach (var item in orderItems)
            {
                await orderItemRepository.CreateOrderItemAsync(orderId, item);
            }
            await dataDbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(OrderDTO orderDto)
        {
            ValidateOrderDto(orderDto);

            var existingOrder = await orderRepository.GetOrderByIdAsync(orderDto.OrderId);
            if (existingOrder == null)
            {
                throw new AppException($"Narudžba sa ID: {orderDto.OrderId} nije pronađena");
            }

            orderRepository.UpdateOrder(existingOrder, orderDto);
            await dataDbContext.SaveChangesAsync();

            await GenerateInvoice(orderDto.OrderId);
        }

        private async Task GenerateInvoice(int orderId)
        {
            Settings.License = LicenseType.Community;
            var model = await invoiceService.GetInvoiceDetails(orderId);
            var document = new InvoiceDocument(model);
            document.GeneratePdf("invoice.pdf");
        }

        private void ValidateOrderDto(OrderDTO orderDto)
        {
            if (!ValidationUtils.IsNotNull(orderDto, orderDto.CustomerFirstName, orderDto.CustomerLastName, orderDto.CustomerShippingAddress, orderDto.CustomerEmail, orderDto.OrderItems, orderDto.TotalPrice))
            {
                throw new AppException("Jedan ili više atributa narudžbe su nevalidni");
            }
        }
    }
}