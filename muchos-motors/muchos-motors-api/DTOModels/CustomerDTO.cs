using muchos_motors_api.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public bool? IsRegistered { get; set; }
        public bool? IsValid { get; set; }

    }
}
