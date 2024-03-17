using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Linq;
using System.Text.Json.Serialization;

namespace muchos_motors_api.AuthHelper
{

    public class UserAuthInfo
    {
        [JsonIgnore]
        public UserAccount? UserAccount => AuthenticationToken?.UserAccount;
        public AuthenticationToken? AuthenticationToken { get; set; }
        public bool IsLoggedIn => UserAccount != null;

        public UserAuthInfo(AuthenticationToken? authenticationToken)
        {
            this.AuthenticationToken = authenticationToken;
        }

    }
}
