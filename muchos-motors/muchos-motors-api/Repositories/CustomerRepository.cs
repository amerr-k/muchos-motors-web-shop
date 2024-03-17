using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class CustomerRepository
    {
        private readonly DataDbContext dataDbContext;

        public CustomerRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAscAsync(CancellationToken cancellationToken = default)
        {
            return await dataDbContext.Customer
                .Where(customer => customer.IsValid)
                .OrderBy(customer => customer.LastName)
                .ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            //return await dataDbContext.Customer
            //    .FirstOrDefaultAsync(e => e.CustomerId == customerId && e.IsValid);
            return await dataDbContext.Customer
                .FirstOrDefaultAsync(e => 1 == customerId && e.IsValid);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await dataDbContext.Customer
                .FirstOrDefaultAsync(e => e.Email == email && e.IsValid);
        }

        public void DeleteByObject(Customer customer)
        {
            customer.IsValid = false;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDTO customerDto, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Address = customerDto.Address,
                Phone = customerDto.Phone,
                CityId = customerDto.CityId,
                Password = customerDto.Password,
                Username = customerDto.Username,
                IsValid = true,
            };
            await dataDbContext.AddAsync(customer, cancellationToken);
            return customer;
        }

        public void UpdateCustomer(Customer existingCustomer, CustomerDTO customerDto)
        {
            existingCustomer.FirstName = customerDto.FirstName;
            existingCustomer.LastName = customerDto.LastName;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.Address = customerDto.Address;
            existingCustomer.Phone = customerDto.Phone;
        }
    }
}
