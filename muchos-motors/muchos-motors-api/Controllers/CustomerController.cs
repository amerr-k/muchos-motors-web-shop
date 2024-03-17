using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.Customer
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [EmployeeFilter]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers(CancellationToken cancellationToken)
        {
            return await customerService.GetAllCustomersAsync(cancellationToken);
        }

        [HttpGet("{customerId}")]
        [LoginFilter]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById([FromRoute] int customerId)
        {
            return await customerService.GetCustomerDtoByIdAsync(customerId);  
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerDTO customerDao, CancellationToken cancellationToken)
        {
            var createdCustomer = await customerService.CreateCustomerAsync(customerDao, cancellationToken);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = createdCustomer.UserAccountId }, createdCustomer);
        }

        [HttpPut]
        [LoginFilter]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO customerDao)
        {
            await customerService.UpdateCustomerAsync(customerDao);
            return NoContent();
        }

        [HttpDelete("{customerId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteCustomer([FromQuery] int customerId)
        {
            await customerService.DeleteCustomerAsync(customerId);
            return NoContent();
        }
    }
}
