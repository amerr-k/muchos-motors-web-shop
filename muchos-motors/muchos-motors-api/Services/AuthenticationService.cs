using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using muchos_motors_api.AuthHelper;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.Services
{
    public class AuthenticationService
    {
        private readonly DataDbContext dataDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly CustomerService customerService;

        public AuthenticationService(DataDbContext dataDbContext, 
            IHttpContextAccessor httpContextAccessor,
            CustomerService customerService)
        {
            this.dataDbContext = dataDbContext;
            this.httpContextAccessor = httpContextAccessor;
            this.customerService = customerService;
        }

        public async Task<UserAuthInfo> Login([FromBody] UserLoginDTO userLoginDto, CancellationToken cancellationToken)
        {
            var existingUserAccount = await dataDbContext.UserAccount
                .FirstOrDefaultAsync(user =>
                    user.Username == userLoginDto.Username && user.Password == userLoginDto.Password, cancellationToken: cancellationToken);

            if (existingUserAccount == null)
            {
                return new UserAuthInfo(null);
            }
            string randomString = TokenGenerator.Generate(10);

            var noviToken = new AuthenticationToken()
            {
                //ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Value = randomString,
                UserAccount = existingUserAccount,
                CreatedDate = DateTime.Now
            };

            dataDbContext.Add(noviToken);
            await dataDbContext.SaveChangesAsync(cancellationToken);

            return new UserAuthInfo(noviToken);
        }

        public async Task Register(CustomerDTO customerDTO, CancellationToken cancellationToken)
        {
            await customerService.CreateCustomerAsync(customerDTO, cancellationToken);
        }

        public async Task Logout(CancellationToken cancellationToken)
        {
            var authenticationToken = GetUserAuthInfo().AuthenticationToken;

            if (authenticationToken == null) return;

            dataDbContext.Remove(authenticationToken);
            await dataDbContext.SaveChangesAsync(cancellationToken);
        }

        public bool IsLoggedIn()
        {
            return GetUserAuthInfo().IsLoggedIn;
        }

        public bool IsAdmin()
        {
            return GetUserAuthInfo().UserAccount?.isAdmin ?? false;
        }

        public bool IsCustomer()
        {
            return GetUserAuthInfo().UserAccount?.isCustomer ?? false;
        }

        public bool IsEmployee()
        {
            return GetUserAuthInfo().UserAccount?.isEmployee ?? false;
        }

        public UserAuthInfo GetUserAuthInfo()
        {
            var headerAuthToken = httpContextAccessor.HttpContext.Request.Headers["my-auth-token"].ToString();

            var authToken = dataDbContext.AuthenticationToken
                .Include(x => x.UserAccount)
                .SingleOrDefault(x => x.Value == headerAuthToken);

            return new UserAuthInfo(authToken);
        }
    }
}