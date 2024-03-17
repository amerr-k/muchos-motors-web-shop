using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.Employee
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [EmployeeFilter]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllEmployees(CancellationToken cancellationToken)
        {
            var employeeList = await employeeService.GetAllEmployeesAsync(cancellationToken);
            return employeeList;
        }

        [HttpGet("{employeeId}")]
        [EmployeeFilter]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById([FromRoute] int employeeId)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(employeeId);
            return employee;
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDao)
        {
            var createdEmployee = await employeeService.CreateEmployeeAsync(employeeDao);
            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = createdEmployee.UserAccountId }, createdEmployee);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDTO employeeDao)
        {
            await employeeService.UpdateEmployeeAsync(employeeDao);
            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteEmployee([FromQuery] int employeeId)
        {
            await employeeService.DeleteEmployeeAsync(employeeId);
            return NoContent();
        }
    }
}
