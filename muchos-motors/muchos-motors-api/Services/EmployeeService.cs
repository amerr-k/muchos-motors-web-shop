using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using muchos_motors_api.Utils;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace muchos_motors_api.Services
{
    public class EmployeeService
    {
        private readonly DataDbContext dataDbContext;
        private readonly EmployeeRepository employeeRepository;
        private readonly Mapper mapper;

        public EmployeeService(DataDbContext dataDbContext, EmployeeRepository employeeRepository, Mapper mapper)
        {
            this.dataDbContext = dataDbContext;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var employeeList = await employeeRepository.GetAllEmployeesAscAsync(cancellationToken);
            return mapper.Map<List<EmployeeDTO>>(employeeList);
        }

        public async Task<List<SelectListItem>> GetAllSelectListItemEmployeesAsync()
        {
            var employeeList = await employeeRepository.GetAllEmployeesAscAsync();
            var employeeSelectListItems = mapper.Map<List<SelectListItem>>(employeeList);
            return employeeSelectListItems;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                throw new AppException($"Employee with ID {employeeId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<EmployeeDTO>(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                throw new AppException($"Employee with ID {employeeId} not found");
            }
            employeeRepository.DeleteByObject(employee);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeDTO employeeDto)
        {
            ValidateEmployeeDto(employeeDto);

            var createdEmployee = await employeeRepository.CreateEmployeeAsync(employeeDto);
            await dataDbContext.SaveChangesAsync();
            return createdEmployee;
        }
        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDto)
        {
            ValidateEmployeeDto(employeeDto);

            var existingEmployee = await employeeRepository.GetEmployeeByIdAsync(employeeDto.EmployeeId);
            if (existingEmployee == null)
            {
                throw new AppException($"Employee with ID {employeeDto.EmployeeId} not found");
            }

            employeeRepository.UpdateEmployee(existingEmployee, employeeDto);
            await dataDbContext.SaveChangesAsync();
        }

        private void ValidateEmployeeDto(EmployeeDTO employeeDto)
        {
            if (!ValidationUtils.IsNotNull(employeeDto, employeeDto.FirstName, employeeDto.LastName,
                employeeDto.Email, employeeDto.Password, employeeDto.Username))
            {
                throw new AppException("One or more required employee attributes are null");
            }
        }

    }
}
