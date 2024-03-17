using muchos_motors_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
