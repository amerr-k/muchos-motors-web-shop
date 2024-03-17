using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using muchos_motors_api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace muchos_motors_api.AuthHelper
{
    public class CustomerFilterAttribute : TypeFilterAttribute
    {
        public CustomerFilterAttribute() : base(typeof(CustomerAsyncActionFilter))
        {
        }
    }
    public class CustomerAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
                    ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authService = context.HttpContext.RequestServices.GetService<AuthenticationService>()!;
            //var actionLogService = context.HttpContext.RequestServices.GetService<MyActionLogService>()!;

            if (!authService.IsLoggedIn() || !authService.IsCustomer())
            {
                context.Result = new UnauthorizedObjectResult("Niste logirani na sistem");
                return;
            }

            //MyAuthInfo myAuthInfo = authService.GetAuthInfo();

            //if (myAuthInfo.korisnickiNalog.Is2FActive && !myAuthInfo.autentifikacijaToken.Is2FOtkljucano)
            //{
            //    context.Result = new UnauthorizedObjectResult("niste otkljucali 2f");
            //    return;
            //}

            await next();
            //await actionLogService.Create(context.HttpContext);
        }
    }
}

