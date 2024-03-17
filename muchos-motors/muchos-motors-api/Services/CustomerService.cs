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
    public class CustomerService
    {
        private readonly DataDbContext dataDbContext;
        private readonly CustomerRepository customerRepository;
        private readonly Mapper mapper;

        public CustomerService(DataDbContext dataDbContext, CustomerRepository customerRepository, Mapper mapper)
        {
            this.dataDbContext = dataDbContext;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            var customerList = await customerRepository.GetAllCustomersAscAsync(cancellationToken);
            return mapper.Map<List<CustomerDTO>>(customerList);
        }

        public async Task<List<SelectListItem>> GetAllSelectListItemCustomersAsync()
        {
            var customerList = await customerRepository.GetAllCustomersAscAsync();
            var customerSelectListItems = mapper.Map<List<SelectListItem>>(customerList);
            return customerSelectListItems;
        }

        public async Task<CustomerDTO> GetCustomerDtoByIdAsync(int customerId)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new AppException($"Customer with ID {customerId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<CustomerDTO>(customer);
        }


        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new AppException($"Customer with ID {customerId} not found");
            }
            customerRepository.DeleteByObject(customer);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDTO customerDto, CancellationToken cancellationToken)
        {
            ValidateCustomerDto(customerDto);

            var createdCustomer = await customerRepository.CreateCustomerAsync(customerDto, cancellationToken);
            await dataDbContext.SaveChangesAsync(cancellationToken);
            return createdCustomer;
        }
        public async Task UpdateCustomerAsync(CustomerDTO customerDto)
        {
            ValidateCustomerDto(customerDto);

            var existingCustomer = await customerRepository.GetCustomerByIdAsync(customerDto.CustomerId);
            if (existingCustomer == null)
            {
                throw new AppException($"Customer with ID {customerDto.CustomerId} not found");
            }

            customerRepository.UpdateCustomer(existingCustomer, customerDto);
            await dataDbContext.SaveChangesAsync();
        }

        private void ValidateCustomerDto(CustomerDTO customerDto)
        {
            if (!ValidationUtils.IsNotNull(customerDto, customerDto.FirstName, customerDto.LastName,
                customerDto.Email))
            {
                throw new AppException("One or more required customer attributes are null");
            }
        }
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await customerRepository.GetCustomerByIdAsync(customerId);  
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await customerRepository.GetCustomerByEmailAsync(email);
        }

    }
}
