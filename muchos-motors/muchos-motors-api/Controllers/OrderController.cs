using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.Order
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [EmployeeFilter]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders()
        {
            return await orderService.GetAllOrdersAsync();
        }

        [HttpGet("{orderId}")]
        [EmployeeFilter]
        public async Task<ActionResult<OrderDTO>> GetOrderById([FromRoute] int orderId)
        {
            return await orderService.GetOrderByIdAsync(orderId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDTO orderDto, CancellationToken cancellationToken)
        {
            var createdOrder = await orderService.CreateOrderAsync(orderDto, cancellationToken);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = createdOrder.OrderId }, createdOrder);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDTO orderDto)
        {
            await orderService.UpdateOrderAsync(orderDto);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteOrder([FromQuery] int orderId)
        {
            await orderService.DeleteOrderAsync(orderId);
            return NoContent();
        }
    }
}
