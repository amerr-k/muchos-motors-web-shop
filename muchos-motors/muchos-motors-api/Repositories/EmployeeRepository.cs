using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataDbContext dataDbContext;

        public EmployeeRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<Employee>> GetAllEmployeesAscAsync(CancellationToken cancellationToken = default)
        {
            return await dataDbContext.Employee
                .Where(employee => employee.IsValid)
                .OrderBy(employee => employee.LastName)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            //return await dataDbContext.Employee
            //    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.IsValid);
            return await dataDbContext.Employee
                .FirstOrDefaultAsync(e => 1 == employeeId && e.IsValid);
        }

        public void DeleteByObject(Employee employee)
        {
            employee.IsValid = false;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeDTO employeeDao)
        {
            var employee = new Employee
            {
                FirstName = employeeDao.FirstName,
                LastName = employeeDao.LastName,
                Email = employeeDao.Email,
                Username = employeeDao.Username ?? employeeDao.Email,
                Password = employeeDao.Password,
                Address = employeeDao.Address,
                Phone = employeeDao.Phone,
                IsValid = true
            };
            await dataDbContext.AddAsync(employee);
            return employee;
        }

        public void UpdateEmployee(Employee existingEmployee, EmployeeDTO employeeDao)
        {
            existingEmployee.FirstName = employeeDao.FirstName;
            existingEmployee.LastName = employeeDao.LastName;
            existingEmployee.Email = employeeDao.Email;
            existingEmployee.Username = employeeDao.Username;
            existingEmployee.Password = employeeDao.Password;
            existingEmployee.Address = employeeDao.Address;
            existingEmployee.Phone = employeeDao.Phone;
        }
    }
}
