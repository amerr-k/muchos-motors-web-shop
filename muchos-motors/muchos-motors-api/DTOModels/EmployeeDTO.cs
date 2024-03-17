using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? CityId { get; set; }
    }
}
