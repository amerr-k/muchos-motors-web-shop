using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.Controllers.AuthenticationController
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpGet("user-info")]
        public UserAuthInfo GetUserAuthInfo()
        {
            return authenticationService.GetUserAuthInfo();
        }

        [HttpPost("login")]
        public async Task<UserAuthInfo> Login([FromBody] UserLoginDTO userLoginDto, CancellationToken cancellationToken)
        {
            return await authenticationService.Login(userLoginDto, cancellationToken);
        }

        [HttpPost("logout")]
        public async Task Logout(CancellationToken cancellationToken)
        {
             await authenticationService.Logout(cancellationToken);
        }

        [HttpPost("register")]
        public async Task Register([FromBody] CustomerDTO customerDTO, CancellationToken cancellationToken)
        {
            await authenticationService.Register(customerDTO, cancellationToken);
        }

    }
}
