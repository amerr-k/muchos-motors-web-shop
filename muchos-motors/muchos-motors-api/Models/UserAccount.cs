using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace muchos_motors_api.Models
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string? UserPicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }

        [JsonIgnore]
        public Customer? Customer => this as Customer;

        [JsonIgnore]
        public Employee? Employee => this as Employee;

        public bool isCustomer => Customer != null;
        public bool isEmployee => Employee != null;
        public bool isAdmin { get; set; }
        public bool IsValid { get; set; }
    }
}
