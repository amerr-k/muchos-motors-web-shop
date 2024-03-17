using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace muchos_motors_api.Models
{
    //[Index(nameof(Email), IsUnique = true)]
    //[Index(nameof(Username), IsUnique = true)]
    public class Customer : UserAccount
    {
        //[Key]
        //public int CustomerId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string? Phone { get; set; }
        //public string? Address { get; set; }
        //public string? Note { get; set; }
        //public int? CityId { get; set; }
        //[ForeignKey("CityId")]
        //public City? City{ get; set; }
        //public bool IsRegistered { get; set; }

    }
}
